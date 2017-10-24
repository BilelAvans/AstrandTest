using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataLibrary
{
    public class Bike
    {
        public SerialPort BikePort;

        public virtual bool IsConnected { get { return (bool)BikePort?.IsOpen; } }
        

        public Bike()
        {
            BikePort = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
        }

        public virtual bool Connect()
        {
            try
            {
                if (!IsConnected)
                    BikePort.Open();
            }
            catch (Exception)
            {
                return false;
            }

            return true;

        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public virtual string GetID()
        {
            BikePort.WriteLine("ID");

            // Wait for results
            Thread.Sleep(250);
            // Read results

            return BikePort.ReadLine();
        }

        public virtual Measurement GetMeasurement()
        {
            // Send "ST" command
            BikePort.WriteLine("ST");

            // Wait for results
            Thread.Sleep(100);

            // Read results

            Measurement message = Measurement.FromReading(BikePort.ReadLine());
            if (message != null)
            {
                Console.WriteLine(message.ToString());
            }

            return message;
        }

        public virtual string GetVersion()
        {
            BikePort.WriteLine("VE");

            Thread.Sleep(250);

            return BikePort.ReadLine();
        }

        public void Reset()
        {
            BikePort.WriteLine("RS");
        }

        public virtual void SetDistance(int distance)
        {
            BikePort.WriteLine("CM");
            BikePort.WriteLine("PD " + distance);
        }

        public virtual void SetEnergy(int energy)
        {
            BikePort.WriteLine("CM");
            BikePort.WriteLine("PE " + energy);
        }

        public virtual void SetPower(int power)
        {
            BikePort.WriteLine("CM");
            BikePort.WriteLine("PW " + power);
        }

        public virtual void SetTime(int time)
        {
            BikePort.WriteLine("CM");
            BikePort.WriteLine("PT " + time);
        }
    }
}
