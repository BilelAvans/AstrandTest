using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstrandTest.Tests
{
    public class AstrandWrapper: BackgroundWorker
    {

        public Bike TurboBike { get; set; }

        public List<Measurement> Measurements = new List<Measurement>();

        public Queue<WhileAstrandRequirements> RequirementsSheets = new Queue<WhileAstrandRequirements>();
        
        public AstrandWrapper(Bike TurboBike, params WhileAstrandRequirements[] requirements)
        {

            TurboBike = TurboBike;
            RequirementsSheets = new Queue<WhileAstrandRequirements>(requirements);

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

                while (RequirementsSheets.Count > 0)
                {
                    WhileAstrandRequirements req = RequirementsSheets.Dequeue();

                    DateTime now = DateTime.Now;
                    DateTime end = now + req.sessionTime;

                    while (DateTime.Now < end)
                    {
                        Measurement createdMeasurement = TurboBike.GetMeasurement();
                        Measurements.Add(createdMeasurement);  
                    }
                    

                }
            }
        }

        public static Queue<WhileAstrandRequirements> CreateAstrandTestOne()
        {
            Queue<WhileAstrandRequirements> reqs = new Queue<WhileAstrandRequirements>();

            reqs.Enqueue(new WhileAstrandRequirements
            {
                sessionTime = TimeSpan.FromMinutes(1),
                requestedPower = 50
            });


            reqs.Enqueue(new WhileAstrandRequirements()
            {
                sessionTime = TimeSpan.FromMinutes(1),
                requestedPower = 75
            });

            reqs.Enqueue(new WhileAstrandRequirements()
            {
                sessionTime = TimeSpan.FromMinutes(2),
                requestedPower = 100,
                AdjustPower = true
            });

            return reqs;

        }


    }
}
