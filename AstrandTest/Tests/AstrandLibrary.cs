using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstrandTest.Tests
{
    public static class AstrandLibrary
    {
        //public int getVo2MAX(int leeftijd)
        //{
        //    return 0;
        //}

        public static double getFactor(int leeftijd, double belasting, double HFss)
        {
            //VO2max[ml / kg / min] =
            return (0.00212 * belasting + 0.299) / (0.769 * HFss -48.5) * 1000;
        }
    }
}
