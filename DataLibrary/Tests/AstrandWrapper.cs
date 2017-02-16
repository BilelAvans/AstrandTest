using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataLibrary.Tests
{
    [Serializable]
    public class AstrandWrapper: BackgroundWorker
    {

        public Bike TurboBike { get; set; }

        private List<Measurement> Measurements = new List<Measurement>();

        private List<Measurement> MeasurementsDuringDataLibrary = new List<Measurement>();

        private DateTime LastMeasurementTakenAt;

        private Queue<AstrandPeriod> RequirementsSheets = new Queue<AstrandPeriod>();

        public event EventHandler Handler, NewRequirements, Done;
        

        public  RunStatus Status { get; set; }

        public bool Paused { get; set; }
        // bike must be connected before using it
        public AstrandWrapper(Bike TurboBike, Queue<AstrandPeriod> requirements)
        {
            this.TurboBike = TurboBike;
            RequirementsSheets = requirements;

            this.WorkerReportsProgress = true;
            this.WorkerSupportsCancellation = true;
        }

        public void Start()
        {
            this.DoWork += DoWorkMethod;
            this.RunWorkerAsync();
        }

        public void Stop()
        {
            this.CancelAsync();
            this.DoWork -= DoWorkMethod;
            this.Status = RunStatus.STOPPED;
        }
        

        public void DoWorkMethod(object sender, DoWorkEventArgs args)
        {
            TimeSpan span = TimeSpan.FromSeconds(0);

            while (!args.Cancel)
            {
                this.Status = RunStatus.RUNNING;
                // Set bike time to 0
                TurboBike.SetTime(0);
                Debug.WriteLine("Set bike running");
                while (RequirementsSheets.Count > 0)
                {
 
                    // Get a requirement until timeline requires new one
                    AstrandPeriod req = RequirementsSheets.Dequeue();
                    NewRequirement(req);
                    // Set power of the bike to the new requested power
                    TurboBike.SetPower(req.requestedPower);

                    BikeSim simBike = TurboBike as BikeSim;
                    if (simBike != null)
                        simBike.setAveragePulse(req.pulse + new Random().Next(20));

                    //TurboBike.SetPower(req.requestedPower);
                    Debug.WriteLine("set requirements");

                    DateTime now = DateTime.Now;
                    DateTime end = now + req.PeriodLength;
                                     

                    while (DateTime.Now < end && Status != RunStatus.STOPPED) {
                        while (Paused) { this.Status = RunStatus.PAUSED; Thread.Sleep(1000); now = now + TimeSpan.FromSeconds(1); }

                        Debug.WriteLine("Running not paused");

                        // Create measurement from bike
                        try
                        {
                            Measurement m = TurboBike.GetMeasurement();
                            Measurements.Add(m);
                            Event(m);
                            Debug.WriteLine("got measuremenent");

                            if (req.AdjustPower)
                            {
                                Debug.WriteLine("Adjusting power, going towards {0}", req.pulse.ToString());

                                //int offset = req.rpm - Measurements.Last().Rpm;
                                //int totalOffset = Math.Abs(offset);

                                try
                                {
                                    //if (!(totalOffset > (req.rpm / (100 / req.AllowedOffset))))
                                    //{
                                        while (Measurements.Last().Pulse < req.pulse)
                                        {
                                        // Heart rate needs to be higher (so increase friction on the bike)

                                        if (Measurements.Last().Pulse != 0)
                                            TurboBike.SetPower(++req.requestedPower);
                                        else
                                            Debug.WriteLine("Got no pulse, waiting..");

                                            // Get a new measurement to see if it is corrected
                                            Debug.WriteLine("Corrected power to {0}", req.requestedPower.ToString());

                                            try
                                            {
                                                Measurement mes = TurboBike.GetMeasurement();
                                                // Replace last indexed list item with new one
                                                Measurements.RemoveAt(Measurements.Count - 1);
                                                Measurements.Add(mes);

                                                Debug.WriteLine("Pulse is now {0} according to bike and power is {1}", Measurements.Last().Pulse.ToString(), Measurements.Last().Rpm.ToString());
                                            
                                                // Wait 5 seconds so the user can adjust his heartrate to the new set power
                                                req.PeriodLength += TimeSpan.FromSeconds(3);
                                                Thread.Sleep(3000);
                                            }
                                            catch (FormatException fEx)
                                            {
                                                Debug.WriteLine("Wrong measurement");

                                                Debug.WriteLine(fEx.Message);
                                            }

                                        }

                                        //Thread.Sleep(200);
                                    //}
                                }
                                catch (ArithmeticException e)
                                {
                                    Console.WriteLine(e.Message);

                                }
                            }

                            if (req.UseMeasurements)
                            {
                                TimeSpan measurementInterval = TimeSpan.FromSeconds(15);
                                // Only do this once per 'x' seconds
                                // Removed code: is this needed? DateTime.Now > now + req.PeriodLength.Subtract(TimeSpan.FromMinutes(2)) && 
                                if (LastMeasurementTakenAt < DateTime.Now.Subtract(measurementInterval))
                                {
                                    MeasurementsDuringDataLibrary.Add(Measurements.Last());
                                    // 1
                                    LastMeasurementTakenAt = DateTime.Now;
                                }
                            }
                        } catch (FormatException fEx)
                        {
                            Debug.WriteLine(fEx.Message);
                        }

                        Thread.Sleep(1000);
                    }
                
                }
                
                args.Cancel = true;
                CancelAsync();
            }


            Done(this, new EventArgs());
            Paused = false;
            this.Status = RunStatus.STOPPED;
        }

        private void NewRequirement(AstrandPeriod req)
        {
            if (NewRequirements != null)
                NewRequirements.Invoke(req, new EventArgs());
        }

        public AstrandResults endTest(int age, int weight, bool isFemale)
        {
            this.Stop();

            int averagePulse = (int)MeasurementsDuringDataLibrary.Average(m => m.Pulse);
            int averagePower = (int)MeasurementsDuringDataLibrary.Average(m => m.Act_power);

            //Debug.WriteLine("We have values. age: {0}, weight: {1}, isFemale: {2}", age.ToString(), weight.ToString(), isFemale);

            return new AstrandResults(isFemale, weight, averagePulse, averagePower, age);
        }
        

        public enum RunStatus
        {
            RUNNING,
            PAUSED,
            STOPPED
        }

        private void Event(object sender)
        {
            Handler?.Invoke(sender, new EventArgs());
        }

        [Serializable]
        public struct AstrandResults
        {

            public AstrandResults(bool isFemale, int weight, int pulse, int watts, int age)
            {
                this.isFemale = isFemale;
                this.weight = weight;
                this.pulse = pulse;
                this.watts = watts;
                this.age = age;
            }
            // Auto property: Score formula function calculation
            public double score { get { return AstrandLibrary.getVO2Max(this.watts, this.pulse, this.age, this.isFemale, this.weight); } }

            public bool isFemale;
            public int  weight;
            public int  pulse;
            public int  watts;
            public int  age;

            public override string ToString()
            {
                return score.ToString() + " ( " + AstrandLibrary.scoreToScoreStringConverter((int)score, age, isFemale) + " )";
            }
        }

        ~AstrandWrapper()
        {
            if (Handler != null)
                Handler.GetInvocationList().ToList().ForEach(del => Handler -= (EventHandler)del);
            if (Done != null)
                Done.GetInvocationList().ToList().ForEach(del => Done -= (EventHandler)del);
            
        }


    }
}
