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

        public List<Measurement> Measurements = new List<Measurement>();

        public DateTime LastMeasurementTakenAt;

        public Queue<WhileAstrandRequirements> RequirementsSheets = new Queue<WhileAstrandRequirements>();
        
        public AstrandWrapper(Bike TurboBike, Queue<WhileAstrandRequirements> requirements)
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
                Console.WriteLine("In Test");
                while (RequirementsSheets.Count > 0)
                {
                    // Create measurement from bike
                    getMeasurementFromBike();
                    
                    WhileAstrandRequirements req = RequirementsSheets.Dequeue();

                    DateTime now = DateTime.Now;
                    DateTime end = now + req.sessionTime;

                    while (DateTime.Now < end) { 
                    
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
                                        // Not properly doing the test, going too slow or fast
                                        TurboBike.SetPower(++req.requestedPower);
                                    }

                                    Thread.Sleep(200);
                                    getMeasurementFromBike();
                                }
                                else
                                {
                                    Console.WriteLine("Total offset is " + offset.ToString());
                                    getMeasurementFromBike();
                                }
                            } catch (ArithmeticException e)
                            {
                                Console.WriteLine("You're not moving?");
                                getMeasurementFromBike();
                            }
                            Thread.Sleep(1000);
                        }
                    }
                }
            }

            Console.WriteLine("Test done, Bye!");
        }

        public AstrandResults endTest()
        {
            this.Stop();

            int leeftijd = 20;
            double averagePulse = Measurements.Average(m => m.Pulse);
            double averagePower = Measurements.Average(m => m.Act_power);

            AstrandResults results = new AstrandResults();
            results.score = AstrandLibrary.getFactor(leeftijd, averagePower, averagePulse);

            return results;

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

        public static Queue<WhileAstrandRequirements> CreateAstrandTestOne()
        {
            Queue<WhileAstrandRequirements> reqs = new Queue<WhileAstrandRequirements>();

            reqs.Enqueue(new WhileAstrandRequirements
            {
                sessionTime = TimeSpan.FromMinutes(1),
                requestedPower = 50,
                AdjustPower = true,
                AllowedOffset = 5
            });

            reqs.Enqueue(new WhileAstrandRequirements()
            {
                sessionTime = TimeSpan.FromMinutes(1),
                requestedPower = 75
            });

            reqs.Enqueue(new WhileAstrandRequirements()
            {
                sessionTime = TimeSpan.FromMinutes(6),
                requestedPower = 100,
                AdjustPower = true
            });

            reqs.Enqueue(new WhileAstrandRequirements()
            {
                sessionTime = TimeSpan.FromMinutes(1),
                requestedPower = 75
            });

            reqs.Enqueue(new WhileAstrandRequirements
            {
                sessionTime = TimeSpan.FromMinutes(1),
                requestedPower = 50
            });

            return reqs;
        }

        public struct AstrandResults
        {
            public double score;
        }


    }
}
