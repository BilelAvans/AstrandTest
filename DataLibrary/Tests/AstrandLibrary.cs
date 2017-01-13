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

        //public static double getFactor(int leeftijd, double belasting, double HFss)
        //{
        //    //VO2max[ml / kg / min] =
        //    return (0.00212 * belasting + 0.299) / (0.769 * HFss -48.5) * 1000;
        //}

        public enum ScoreToStringEnum
        {
            Zeer_slecht,
            Slecht,
            Redelijk,
            Gemiddeld,
            Goed,
            Zeer_goed,
            Uitstekend
        }

        public static string scoreToScoreStringConverter(int score, int leeftijd, bool isFemale)
        {
            if (isFemale)
                return scoreToStringConverterFemale(score, leeftijd);
            else
                return scoreToStringConverterMale(score, leeftijd);
        }

        public static string scoreToStringConverterMale(int score, int leeftijd)
        {
            if (leeftijd > 19 && leeftijd < 25)
            {
                if (score < 32)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_slecht);
                else if (score > 31 && score < 39)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Slecht);
                else if (score > 38 && score < 44)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Redelijk);
                else if (score > 43 && score < 51)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Gemiddeld);
                else if (score > 50 && score < 57)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Goed);
                else if (score > 56 && score < 63)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_goed);
                else if (score > 62)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Uitstekend);
            }
            else if (leeftijd > 24 && leeftijd < 30)
            {
                if (score < 31)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_slecht);
                else if (score > 30 && score < 36)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Slecht);
                else if (score > 35 && score < 43)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Redelijk);
                else if (score > 42 && score < 49)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Gemiddeld);
                else if (score > 48 && score < 54)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Goed);
                else if (score > 53 && score < 60)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_goed);
                else if (score > 59)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Uitstekend);
            }
            else if (leeftijd > 29 && leeftijd < 35)
            {
                if (score < 29)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_slecht);
                else if (score > 28 && score < 35)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Slecht);
                else if (score > 34 && score < 41)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Redelijk);
                else if (score > 40 && score < 46)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Gemiddeld);
                else if (score > 45 && score < 52)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Goed);
                else if (score > 51 && score < 57)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_goed);
                else if (score > 56)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Uitstekend);
            }
            // 4
            else if (leeftijd > 34 && leeftijd < 40)
            {
                if (score < 28)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_slecht);
                else if (score > 27 && score < 33)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Slecht);
                else if (score > 32 && score < 39)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Redelijk);
                else if (score > 38 && score < 44)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Gemiddeld);
                else if (score > 43 && score < 49)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Goed);
                else if (score > 48 && score < 55)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_goed);
                else if (score > 54)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Uitstekend);
            }
            // 5
            else if (leeftijd > 39 && leeftijd < 45)
            {
                if (score < 26)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_slecht);
                else if (score > 25 && score < 32)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Slecht);
                else if (score > 31 && score < 36)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Redelijk);
                else if (score > 35 && score < 42)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Gemiddeld);
                else if (score > 41 && score < 47)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Goed);
                else if (score > 46 && score < 52)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_goed);
                else if (score > 51)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Uitstekend);
            }
            else if (leeftijd > 44 && leeftijd < 50)
            {
                if (score < 25)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_slecht);
                else if (score > 24 && score < 30)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Slecht);
                else if (score > 29 && score < 35)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Redelijk);
                else if (score > 34 && score < 40)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Gemiddeld);
                else if (score > 39 && score < 44)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Goed);
                else if (score > 43 && score < 49)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_goed);
                else if (score > 48)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Uitstekend);
            }
            // 7
            else if (leeftijd > 49 && leeftijd < 55)
            {
                if (score < 24)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_slecht);
                else if (score > 23 && score < 28)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Slecht);
                else if (score > 27 && score < 33)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Redelijk);
                else if (score > 32 && score < 37)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Gemiddeld);
                else if (score > 36 && score < 42)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Goed);
                else if (score > 41 && score < 47)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_goed);
                else if (score > 46)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Uitstekend);
            }
            else if (leeftijd > 54 && leeftijd < 60)
            {
                if (score < 22)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_slecht);
                else if (score > 21 && score < 27)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Slecht);
                else if (score > 26 && score < 31)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Redelijk);
                else if (score > 30 && score < 35)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Gemiddeld);
                else if (score > 34 && score < 40)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Goed);
                else if (score > 39 && score < 44)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_goed);
                else if (score > 43)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Uitstekend);
            }
            else if (leeftijd > 60)
            {
                if (score < 21)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_slecht);
                else if (score > 20 && score < 25)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Slecht);
                else if (score > 24 && score < 29)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Redelijk);
                else if (score > 28 && score < 33)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Gemiddeld);
                else if (score > 32 && score < 37)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Goed);
                else if (score > 36 && score < 41)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_goed);
                else if (score > 40)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Uitstekend);
            }

            return "";

        }


        public static string scoreToStringConverterFemale(int score, int leeftijd)
        {

            if (leeftijd > 19 && leeftijd < 25)
            {
                if (score < 27)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_slecht);
                else if (score > 26 && score < 32)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Slecht);
                else if (score > 31 && score < 37)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Redelijk);
                else if (score > 36 && score < 42)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Gemiddeld);
                else if (score > 41 && score < 47)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Goed);
                else if (score > 46 && score < 52)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_goed);
                else if (score > 51)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Uitstekend);
            }
            else if (leeftijd > 24 && leeftijd < 30)
            {
                if (score < 26)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_slecht);
                else if (score > 25 && score < 31)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Slecht);
                else if (score > 30 && score < 36)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Redelijk);
                else if (score > 35 && score < 41)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Gemiddeld);
                else if (score > 40 && score < 45)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Goed);
                else if (score > 44 && score < 50)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_goed);
                else if (score > 49)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Uitstekend);
            }
            else if (leeftijd > 29 && leeftijd < 35)
            {
                if (score < 25)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_slecht);
                else if (score > 24 && score < 30)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Slecht);
                else if (score > 29 && score < 34)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Redelijk);
                else if (score > 33 && score < 38)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Gemiddeld);
                else if (score > 37 && score < 43)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Goed);
                else if (score > 42 && score < 47)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_goed);
                else if (score > 46)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Uitstekend);
            }
            // 4
            else if (leeftijd > 34 && leeftijd < 40)
            {
                if (score < 24)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_slecht);
                else if (score > 23 && score < 28)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Slecht);
                else if (score > 27 && score < 32)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Redelijk);
                else if (score > 31 && score < 36)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Gemiddeld);
                else if (score > 35 && score < 41)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Goed);
                else if (score > 40 && score < 45)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_goed);
                else if (score > 44)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Uitstekend);
            }
            // 5
            else if (leeftijd > 39 && leeftijd < 45)
            {
                if (score < 22)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_slecht);
                else if (score > 21 && score < 26)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Slecht);
                else if (score > 25 && score < 30)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Redelijk);
                else if (score > 29 && score < 34)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Gemiddeld);
                else if (score > 33 && score < 38)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Goed);
                else if (score > 37 && score < 42)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_goed);
                else if (score > 41)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Uitstekend);
            }
            else if (leeftijd > 44 && leeftijd < 50)
            {
                if (score < 21)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_slecht);
                else if (score > 20 && score < 24)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Slecht);
                else if (score > 23 && score < 28)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Redelijk);
                else if (score > 27 && score < 32)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Gemiddeld);
                else if (score > 31 && score < 36)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Goed);
                else if (score > 35 && score < 39)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_goed);
                else if (score > 38)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Uitstekend);
            }
            // 7
            else if (leeftijd > 49 && leeftijd < 55)
            {
                if (score < 19)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_slecht);
                else if (score > 18 && score < 23)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Slecht);
                else if (score > 22 && score < 26)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Redelijk);
                else if (score > 25 && score < 30)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Gemiddeld);
                else if (score > 29 && score < 33)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Goed);
                else if (score > 32 && score < 37)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_goed);
                else if (score > 36)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Uitstekend);
            }
            else if (leeftijd > 54 && leeftijd < 60)
            {
                if (score < 18)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_slecht);
                else if (score > 17 && score < 21)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Slecht);
                else if (score > 20 && score < 24)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Redelijk);
                else if (score > 23 && score < 28)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Gemiddeld);
                else if (score > 27 && score < 31)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Goed);
                else if (score > 30 && score < 34)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_goed);
                else if (score > 33)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Uitstekend);
            }
            else if (leeftijd > 60)
            {
                if (score < 16)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_slecht);
                else if (score > 15 && score < 19)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Slecht);
                else if (score > 18 && score < 22)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Redelijk);
                else if (score > 21 && score < 25)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Gemiddeld);
                else if (score > 24 && score < 28)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Goed);
                else if (score > 27 && score < 31)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Zeer_goed);
                else if (score > 30)
                    return Enum.GetName(typeof(ScoreToStringEnum), ScoreToStringEnum.Uitstekend);
            }

            return "";
        }

        public static double getVO2Max(int watts, int hf, int age, bool isFemale, int weight)
        {
            if (hf > 119 && hf < 171)
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
                                                        1.8  };

                        double result = powers[hf - 120];
                        return (result * correctionFactorByAge(age) * 1000) / weight;

                    } else
                    {
                        powers = new double[] {         4.1, 4.0, 3.9, 3.9, 3.8, 3.7, 3.6, 3.5, 3.5, 3.4,
                                                        3.4, 3.4, 3.3, 3.2, 3.2, 3.1, 3.1, 3.0, 3.0, 2.9,
                                                        2.8, 2.8, 2.8, 2.7, 2.7, 2.7, 2.6, 2.6, 2.6, 2.6,
                                                        2.5, 2.5, 2.5, 2.4, 2.4, 2.4, 2.3, 2.3, 2.3, 2.2,
                                                        2.2, 2.2, 2.2, 2.2, 2.1, 2.1, 2.1, 2.1, 2.0, 2.0,
                                                        2.0 };

                        double result = powers[hf - 120];
                        return (result * correctionFactorByAge(age) * 1000) / weight;
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
                requestedPower = 50,
                pulse = 60,
            });

            reqs.Enqueue(new AstrandPeriod()
            {
                PeriodLength = TimeSpan.FromSeconds(1),
                requestedPower = 75,
                pulse = 80
            });
            // Test phase

            reqs.Enqueue(new AstrandPeriod()
            {
                PeriodLength = TimeSpan.FromSeconds(6),
                requestedPower = 100,
                AdjustPower = true,
                pulse = 120,
                AllowedOffset = 10,
                UseMeasurements = true
            });
            // Cooling down
            reqs.Enqueue(new AstrandPeriod()
            {
                PeriodLength = TimeSpan.FromSeconds(1),
                requestedPower = 75,
                pulse = 80
            });

            reqs.Enqueue(new AstrandPeriod
            {
                PeriodLength = TimeSpan.FromSeconds(1),
                requestedPower = 50,
                pulse = 60
            });

            return reqs;
        }

        public static Queue<AstrandPeriod> CreateDataLibraryOne()
        {
            Queue<AstrandPeriod> reqs = new Queue<AstrandPeriod>();
            // Warming up
            reqs.Enqueue(new AstrandPeriod
            {
                PeriodLength = TimeSpan.FromSeconds(10),
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
                PeriodLength = TimeSpan.FromMinutes(1),
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
                PeriodLength = TimeSpan.FromSeconds(10),
                requestedPower = 50
            });

            return reqs;
        }
    }
}
