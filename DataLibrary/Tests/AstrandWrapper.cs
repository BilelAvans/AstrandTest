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

        public event EventHandler Handler, Done;
        

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
                
                while (RequirementsSheets.Count > 0)
                {
 
                    // Get a requirement until timeline requires new one
                    AstrandPeriod req = RequirementsSheets.Dequeue();
                    //TurboBike.SetPower(req.requestedPower);

                    DateTime now = DateTime.Now;
                    DateTime end = now + req.PeriodLength;
                                     

                    while (DateTime.Now < end && Status != RunStatus.STOPPED) {
                        while (Paused) { this.Status = RunStatus.PAUSED; }
                        TurboBike.SetPower(req.requestedPower);
                        // Create measurement from bike
                        Measurement m = TurboBike.GetMeasurement();
                        Measurements.Add(m);
                        Event(m);

                        if (req.AdjustPower)
                        {

                            Debug.WriteLine("M List is null? : " + Measurements.Last() != null);
                            Debug.WriteLine("M pulse is null? : " + Measurements.Last().Rpm != null);


                            int offset = req.rpm - Measurements.Last().Rpm;
                            int totalOffset = Math.Abs(offset);

                            try
                            {
                                if (!(totalOffset > (req.rpm / (100 / req.AllowedOffset))))
                                {
                                    if (Measurements.Last().Pulse < 130)
                                    {
                                        // Heart rate needs to be higher (so increase friction on the bike)
                                        TurboBike.SetPower(++req.requestedPower);
                                    }

                                    //Thread.Sleep(200);
                                }
                            }
                            catch (ArithmeticException e)
                            {
                                //Console.WriteLine("You're not moving?");

                            }
                        }

                        if (req.UseMeasurements)
                        {
                            if (DateTime.Now > now + req.PeriodLength.Subtract(TimeSpan.FromMinutes(2)) && LastMeasurementTakenAt < DateTime.Now.Subtract(TimeSpan.FromSeconds(15)))
                            {
                                MeasurementsDuringDataLibrary.Add(Measurements.Last());
                                LastMeasurementTakenAt = DateTime.Now;
                            }
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

        public AstrandResults endTest(int age, int weight, bool isFemale)
        {
            this.Stop();

            double averagePulse = MeasurementsDuringDataLibrary.Average(m => m.Pulse);
            double averagePower = MeasurementsDuringDataLibrary.Average(m => m.Act_power);

            return new AstrandResults()
            {
                score = AstrandLibrary.getFactor(age, averagePower, averagePulse) * AstrandLibrary.GetCorrectieFactor(100, 130, isFemale)
            };
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
            public double score;
        }

        ~AstrandWrapper()
        {
            if (Handler != null)
                Handler.GetInvocationList().ToList().ForEach(del => Handler -= (EventHandler)del);
            if (Done != null)
                Done.GetInvocationList().ToList().ForEach(del => Done -= (EventHandler)del);

            Console.WriteLine("AstrandWrapper gone");
        }


    }
}
