using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstrandTest.Tests
{
    public class AstrandPeriod
    {
        // This variable will be set during the period
        public int requestedPower { get; set; }
        public int actualPower { get; set; }
        // How long will this period last?
        public TimeSpan PeriodLength { get; set; }
        public int distance { get; set; }
        public int energy { get; set; }
        public int pulse { get; set; }
        public int rpm { get; set; } = 60;
        public int speed { get; set; }
        public int id { get; set; }
        
        public int AllowedOffset { get; set; }
        // 
        public bool AdjustPower { get; set; } = false;
        
        public bool UseMeasurements = false;

        public AstrandPeriod()
        {

        }
        

    }
}
