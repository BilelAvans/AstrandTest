using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AstrandTest
{
    public class Bike
    {
        public SerialPort BikePort;

        public Bike()
        {

        }

        public void Connect()
        {
            try
            {
                BikePort = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
                BikePort.Open();
            }
            catch (IOException ex)
            {
            }

        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public string GetID()
        {
            BikePort.WriteLine("ID");

            // Wait for results
            Thread.Sleep(250);
            // Read results

            return BikePort.ReadLine();
        }

        public Measurement GetMeasurement()
        {
            // Send "ST" command
            BikePort.WriteLine("ST");

            // Wait for results
            Thread.Sleep(250);

            // Read results

            Measurement message = Measurement.FromReading(BikePort.ReadLine());
            if (message != null)
            {
                Console.WriteLine(message.ToString());
            }

            return message;
        }

        public string GetVersion()
        {
            BikePort.WriteLine("VE");

            Thread.Sleep(250);

            return BikePort.ReadLine();
        }

        public void Reset()
        {
            BikePort.WriteLine("RS");
        }

        public void SetDistance(int distance)
        {
            BikePort.WriteLine("CM");
            BikePort.WriteLine("PD " + distance);
        }

        public void SetEnergy(int energy)
        {
            BikePort.WriteLine("CM");
            BikePort.WriteLine("PE " + energy);
        }

        public void SetPower(int power)
        {
            BikePort.WriteLine("CM");
            BikePort.WriteLine("PW " + power);
        }

        public void SetTime(int time)
        {
            BikePort.WriteLine("CM");
            BikePort.WriteLine("PT " + time);
        }
    }
}
