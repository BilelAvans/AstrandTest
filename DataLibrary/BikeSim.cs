using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class BikeSim: Bike
    {

        public int Dest_power { get; set; }
        public int Act_power { get; set; }
        public int Pulse { get; set; }
        public int Rpm { get; set; }
        public int Speed { get; set; }
        public int Distance { get; set; }
        public int Energy { get; set; }
        
        public TimeSpan Time { get; set; }

        public override bool IsConnected { get { return true; } }


        public BikeSim()
        {

        }

        public override void SetPower(int power)
        {
            this.Act_power = power;
        }

        public override void SetDistance(int distance)
        {
            this.Distance = distance;
            
        }
        
        public override void SetTime(int time)
        {
            this.Time = TimeSpan.FromSeconds(time);
        }

        public override void SetEnergy(int energy)
        {
            this.Energy = energy;
        }

        public override string GetID()
        {
            return "SimmedBike";
        }

        public override Measurement GetMeasurement()
        {
            Measurement m = new Measurement(Pulse, Rpm, Speed, Distance, Act_power, Energy, Time, Dest_power);

            Time += TimeSpan.FromSeconds(1);

            if (new Random().Next(3) < 2)
                setAveragePulse(this.Pulse++);
            else
                setAveragePulse(this.Pulse--);

            return m;
        }

        public override bool Connect()
        {
            // do nothing
            return true;
        }

        internal void setAveragePulse(int pulse)
        {
            this.Pulse = pulse;
        }
    }
}
