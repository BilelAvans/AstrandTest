using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Tests
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

        public static double getCorrectieFactor(int watts, int hf, bool isFemale)
        {
            if (hf > 120 && hf < 170)
            {
                double[] powers;

                if (watts == 100)
                {
                    if (!isFemale)
                    {
                        powers = new double[] {         3.4, 3.4, 3.4, 3.4, 3.3, 3.2, 3.2, 3.1, 3.1, 3.0,
                                                        3.0, 2.9, 2.9, 2.8, 2.8, 2.8, 2.7, 2.7, 2.7, 2.6,
                                                        2.6, 2.6, 2.5, 2.5, 2.5, 2.4, 2.4, 2.4, 2.4, 2.3,
                                                        2.3, 2.3, 2.3, 2.2, 2.2, 2.2, 2.2, 2.1, 2.1, 2.1,
                                                        2.1, 2.0, 2.0, 2.0, 2.0, 2.0, 1.9, 1.9, 1.9, 1.9,
                                                        1.8 };

                        return powers[hf - 120];
                    } else
                    {
                        powers = new double[] {         4.1, 4.0, 3.9, 3.9, 3.8, 3.7, 3.6, 3.5, 3.5, 3.4,
                                                        3.4, 3.4, 3.3, 3.2, 3.2, 3.1, 3.1, 3.0, 3.0, 2.9,
                                                        2.8, 2.8, 2.8, 2.7, 2.7, 2.7, 2.6, 2.6, 2.6, 2.6,
                                                        2.5, 2.5, 2.5, 2.4, 2.4, 2.4, 2.3, 2.3, 2.3, 2.2,
                                                        2.2, 2.2, 2.2, 2.2, 2.1, 2.1, 2.1, 2.1, 2.0, 2.0,
                                                        2.0 };

                        return powers[hf - 120];
                    }
                }
                
            }

            throw new NullReferenceException("hartrate must be between 120 and 170");
        }

        public static double correctionFactorByAge(int age)
        {
            if (age >= 15 && age < 25)
                return 1.1;
            if (age >= 25 && age < 35)
                return 1.0;
            if (age >= 35 && age < 40)
                return 0.87;
            if (age >= 40 && age < 45)
                return 0.78;
            if (age >= 45 && age < 50)
                return 0.75;
            if (age >= 50 && age < 55)
                return 0.71;
            if (age >= 55 && age < 60)
                return 0.68;
            if (age >= 60 && age < 65)
                return 0.65;

            throw new NullReferenceException("Age must be between 15 and 65");
        }

        public static Queue<AstrandPeriod> CreateDataLibraryOneShort()
        {
            Queue<AstrandPeriod> reqs = new Queue<AstrandPeriod>();
            // Warming up
            reqs.Enqueue(new AstrandPeriod
            {
                PeriodLength = TimeSpan.FromSeconds(1),
                requestedPower = 50
            });

            reqs.Enqueue(new AstrandPeriod()
            {
                PeriodLength = TimeSpan.FromSeconds(1),
                requestedPower = 75
            });
            // Test phase

            reqs.Enqueue(new AstrandPeriod()
            {
                PeriodLength = TimeSpan.FromSeconds(6),
                requestedPower = 100,
                AdjustPower = true,
                AllowedOffset = 10,
                UseMeasurements = true
            });
            // Cooling down
            reqs.Enqueue(new AstrandPeriod()
            {
                PeriodLength = TimeSpan.FromSeconds(1),
                requestedPower = 75
            });

            reqs.Enqueue(new AstrandPeriod
            {
                PeriodLength = TimeSpan.FromSeconds(1),
                requestedPower = 50
            });

            return reqs;
        }

        public static Queue<AstrandPeriod> CreateDataLibraryOne()
        {
            Queue<AstrandPeriod> reqs = new Queue<AstrandPeriod>();
            // Warming up
            reqs.Enqueue(new AstrandPeriod
            {
                PeriodLength = TimeSpan.FromMinutes(1),
                requestedPower = 50
            });

            //reqs.Enqueue(new AstrandPeriod()
            //{
            //    PeriodLength = TimeSpan.FromMinutes(1),
            //    requestedPower = 75
            //});
            // Test phase

            reqs.Enqueue(new AstrandPeriod()
            {
                PeriodLength = TimeSpan.FromMinutes(2),
                requestedPower = 100,
                AdjustPower = true,
                AllowedOffset = 5,
                UseMeasurements = true
            });
            // Cooling down
            //reqs.Enqueue(new AstrandPeriod()
            //{
            //    PeriodLength = TimeSpan.FromMinutes(1),
            //    requestedPower = 75
            //});

            reqs.Enqueue(new AstrandPeriod
            {
                PeriodLength = TimeSpan.FromMinutes(1),
                requestedPower = 50
            });

            return reqs;
        }
    }
}
