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

        private bool LastMeasurementWasUsed = true;

        private Queue<AstrandPeriod> RequirementsSheets = new Queue<AstrandPeriod>();

        public event EventHandler Handler, NewRequirements, Done;

        private BackgroundWorker MeasurementsSideThread = new BackgroundWorker();

        private async void setSideThread()
        {
            
            MeasurementsSideThread.RunWorkerAsync();
        }

        private async void stopSideThread()
        {

            MeasurementsSideThread.CancelAsync();
        }

        private void MeasurementsSideThread_DoWork(object sender, DoWorkEventArgs e)
        {
            while (Status == RunStatus.RUNNING && !e.Cancel)
            {
                try
                {
                    DateTime now = DateTime.Now;
                    Measurement m = TurboBike.GetMeasurement();

                    Measurements.Add(m);
                    LastMeasurementWasUsed = false;
                    Thread.Sleep((int)(1000 - (DateTime.Now - now).TotalMilliseconds));
                    Event(m);
                } catch (Exception ef)
                {
                    Debug.WriteLine(ef.Message);
                }

            }
            
            Debug.WriteLine(Status.ToString());
            Debug.WriteLine(e.Cancel);
        }

        public RunStatus Status { get; set; }

        public bool Paused { get; set; }
        // bike must be connected before using it
        public AstrandWrapper(Bike TurboBike, Queue<AstrandPeriod> requirements)
        {
            this.TurboBike = TurboBike;
            RequirementsSheets = requirements;

            this.WorkerReportsProgress = true;
            this.WorkerSupportsCancellation = true;

            MeasurementsSideThread.WorkerSupportsCancellation = true;

            MeasurementsSideThread.DoWork += MeasurementsSideThread_DoWork;
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
                setSideThread();

                bool needNewRequirement = true;
                AstrandPeriod req = null;

                while (RequirementsSheets.Count > 0)
                {
                    Debug.WriteLine("Que pasa?"+ needNewRequirement);
                    // Get a requirement until timeline requires new one
                    if (needNewRequirement)
                    {
                        req = RequirementsSheets.Dequeue();
                        NewRequirement(req);
                        needNewRequirement = false;

                    }

                    // Set power of the bike to the new requested power

                    BikeSim simBike = TurboBike as BikeSim;
                    if (simBike != null)
                        simBike.setAveragePulse(req.pulse + new Random().Next(20));

                    //TurboBike.SetPower(req.requestedPower);

                    DateTime now = DateTime.Now;
                    DateTime end = now + req.PeriodLength;

                    DateTime thisIsItStartTime = new DateTime(1999, 1, 1);

                    while (DateTime.Now < end && Status != RunStatus.STOPPED)
                    {
                        while (Paused) { this.Status = RunStatus.PAUSED; Thread.Sleep(1000); now = now + TimeSpan.FromSeconds(1); }

                        try
                        {
                            Measurement m = waitForNewMeasurement();
                            // Create measurement from bike
                            Debug.WriteLine(req.CurrentStatus);
                            switch (req.CurrentStatus)
                            {
                                case AstrandPeriod.TestStatus.WARMING_UP:
                                    if (m.Rpm > 49 && m.Rpm < 61)
                                    {
                                        TurboBike.SetPower(m.Act_power++);
                                        Debug.WriteLine("Warming up");
                                    } else
                                    {
                                        Debug.WriteLine("RPM not between 49 and 61!");
                                    }
                                    break;
                                case AstrandPeriod.TestStatus.THIS_IS_IT:
                                    if (thisIsItStartTime.Year == 1999) { thisIsItStartTime = DateTime.Now; }
                                    if (LastMeasurementTakenAt != null && LastMeasurementTakenAt < DateTime.Now + TimeSpan.FromSeconds(15))
                                    {
                                        
                                        if (DateTime.Now - thisIsItStartTime > TimeSpan.FromMinutes(4))
                                        {
                                            if (DateTime.Now - LastMeasurementTakenAt > TimeSpan.FromSeconds(59))
                                            {
                                                MeasurementsDuringDataLibrary.Add(m);
                                                LastMeasurementTakenAt = DateTime.Now;
                                            }
                                        } else
                                        {
                                            if (DateTime.Now - LastMeasurementTakenAt > TimeSpan.FromSeconds(15))
                                            {
                                                MeasurementsDuringDataLibrary.Add(m);
                                                LastMeasurementTakenAt = DateTime.Now;
                                            }
                                        }
                                    }
                                    break;
                                case AstrandPeriod.TestStatus.COOL_DOWN:

                                    break;
                                    
                            }
                            // Are we done checking per mode
                            if (req.CurrentStatus == AstrandPeriod.TestStatus.WARMING_UP && DateTime.Now - now > TimeSpan.FromSeconds(15) && m.Rpm > 49 && m.Rpm < 61)
                            {
                                needNewRequirement = true;
                            }
                            else if (req.CurrentStatus == AstrandPeriod.TestStatus.THIS_IS_IT)
                            {
                                Debug.WriteLine("THIS IS IT!!!");
                                if (DateTime.Now - thisIsItStartTime > TimeSpan.FromMinutes(6))
                                {
                                    needNewRequirement = true;
                                }
                            }
                            else if (req.CurrentStatus == AstrandPeriod.TestStatus.COOL_DOWN)
                            {
                                TurboBike.SetPower(--Measurements.Last().Rpm);

                                if (Measurements.Last().Rpm == 0)
                                {
                                    throw new Exception("Test is done");
                                }
                            }
                            
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e.Message);
                        }

                    }

                    args.Cancel = true;
                    CancelAsync();
                }

                stopSideThread();
                Done(this, new EventArgs());
                Paused = false;
                //this.Status = RunStatus.STOPPED;
            }
        }

        private Measurement waitForNewMeasurement()
        {
            while (LastMeasurementWasUsed)
            {
                // Just wait it out
            }
            LastMeasurementWasUsed = true;
            return Measurements.Last();
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

            public void setWatts(int v)
            {
                this.watts = v;
                Console.WriteLine(this.watts.ToString() + " now");
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
