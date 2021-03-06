﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Tests
{
    [Serializable]
    public class AstrandPeriod
    {
        // This variable will be set during the period
        public int requestedPower { get; set; }
        // How long will this period last?
        public TimeSpan PeriodLength { get; set; }
        public int distance { get; set; }

        public int pulse { get; set; }
        public int rpm { get; set; } = 60;
        
        public enum TestStatus { WARMING_UP, THIS_IS_IT, COOL_DOWN };

        public TestStatus CurrentStatus;

        public AstrandPeriod()
        {

        }
        

    }
}
