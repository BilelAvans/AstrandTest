using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AstrandTest.Tests
{
    public class AstrandWrapper: BackgroundWorker
    {

        public Bike TurboBike { get; set; }

        private List<Measurement> Measurements = new List<Measurement>();

        private List<Measurement> MeasurementsDuringAstrandTest = new List<Measurement>();

        private DateTime LastMeasurementTakenAt;

        private Queue<AstrandPeriod> RequirementsSheets = new Queue<AstrandPeriod>();

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
        }
        

        public void DoWorkMethod(object sender, DoWorkEventArgs args)
        {
            while (!args.Cancel)
            {
                //getMeasurementFromBike();
                Console.WriteLine("In Test");
                while (RequirementsSheets.Count > 0)
                {
                    
                    // Get a requirement until timeline requires new one
                    AstrandPeriod req = RequirementsSheets.Dequeue();
                    TurboBike.SetPower(req.requestedPower);

                    DateTime now = DateTime.Now;
                    DateTime end = now + req.PeriodLength;

                    while (DateTime.Now < end) {
                        while (Paused) { }
                        // Create measurement from bike
                        

                        if (req.AdjustPower)
                        {
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

                                    Thread.Sleep(200);
                                }
                            } catch (ArithmeticException e)
                            {
                                //Console.WriteLine("You're not moving?");
                                
                            }

                            // Wait a second
                            Thread.Sleep(1000);
                        }

                        if (req.UseMeasurements)
                            MeasurementsDuringAstrandTest.Add(Measurements.Last());
  
                    }
                    
                }
                CancelAsync();

            }

            Console.WriteLine("Test done, Bye!");
        }

        public AstrandResults endTest(int age, int weight, bool isFemale)
        {
            this.Stop();
            
            double averagePulse = MeasurementsDuringAstrandTest.Average(m => m.Pulse);
            double averagePower = MeasurementsDuringAstrandTest.Average(m => m.Act_power);

            return new AstrandResults()
            {
                score = AstrandLibrary.getFactor(age, averagePower, averagePulse)
            };
        }

        private bool getMeasurementFromBike()
        {
            try
            {
                Measurement createdMeasurement = TurboBike.GetMeasurement();
                Measurements.Add(createdMeasurement);
                LastMeasurementTakenAt = DateTime.Now;

                return true;
            } catch (NullReferenceException ex)
            {
                
            }

            return false;
        }





        public struct AstrandResults
        {
            public double score;
        }


    }
}
