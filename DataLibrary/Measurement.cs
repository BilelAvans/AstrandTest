using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataLibrary
{
    [Serializable]
    public class Measurement
    {
        public int Dest_power { get; set; }
        public int Act_power { get; set; }
        public int Pulse { get; set; }
        public int Rpm { get; set; }
        public int Speed { get; set; }
        public int Distance { get; set; }
        public int Energy { get; set; }

        [XmlIgnore]
        public TimeSpan Time { get; set; }
                      
        public string XmlTimeSpan
        {
            get { return Time.ToString(); }
            set { Time = TimeSpan.Parse(value); }
        }

        public Measurement(int pulse, int rpm, int speed, int distance, int act_power, int energy, TimeSpan time, int dest_power)
        {
            this.Dest_power = dest_power;
            this.Act_power = act_power;
            this.Pulse = pulse;
            this.Rpm = rpm;
            this.Speed = speed;
            this.Distance = distance / 10;
            this.Energy = energy;
            this.Time = time;
        }

        public Measurement()
        {
            // For XML
        }

        public static Measurement FromReading(string bikestring)
        {
            

            string[] splitMeasurementWhitespace = bikestring.Split(' ');
            string[] splitMeasurementTab = bikestring.Split('\t');
            // Do we have 8 values?
            if (splitMeasurementTab.Length == 8)
            {
                try
                {
                    return new Measurement(Int32.Parse(splitMeasurementTab[0]), Int32.Parse(splitMeasurementTab[1]), Int32.Parse(splitMeasurementTab[2]), Int32.Parse(splitMeasurementTab[3]),
                                           Int32.Parse(splitMeasurementTab[4]), Int32.Parse(splitMeasurementTab[5]),
                                           TimeSpan.Parse("00:"+splitMeasurementTab[6]),
                                           Int32.Parse(splitMeasurementTab[7]));
                }
                catch (FormatException f)
                {
                    

                }
            }

            throw new FormatException("Reading is not valid");
        }

        public override string ToString()
        {
            return " Dest Power: " + Dest_power + " - Act power:  " + Act_power + " - Pulse: " + Pulse + " - Rpm: " + Rpm + " - Speed: " + Speed + " - Distance: " + Distance + " - Energy: " + Energy + " - Time: " + Time.ToString("mm") + ":" + Time.ToString("ss");
        }

        public dynamic ToJSON(string Id)
        {
            return new
            {
                command = "measurement",
                id = Id,
                dest_Power = Dest_power,
                act_Power = Act_power,
                pulse = Pulse,
                rpm = Rpm,
                speed = Speed,
                distance = Distance,
                energy = Energy,
                time = Time
            };
        }
    }
}
