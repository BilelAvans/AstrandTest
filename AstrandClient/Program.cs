﻿using DataLibrary.Tests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static DataLibrary.Tests.AstrandWrapper;
using System.Windows.Forms;
using DataLibrary;

namespace AstrandClient
{
    class Program
    {

        public Bike Bike { get; set; } = new Bike();

        public Program()
        {

        }

        public void App()
        {
            Application.EnableVisualStyles();
            Application.Run(new Login());
            //// Run astrand test
            //Console.WriteLine("Welcome to the test application:");
            //Console.WriteLine("Press enter to start...");
            //ConsoleKey c = ConsoleKey.A;

            //while (c != ConsoleKey.Enter)
            //{
            //    c = Console.ReadKey().Key;
            //}

            //Console.WriteLine("Connecting to bike...");
            //Bike.Connect();

            //while (!Bike.BikePort.IsOpen)
            //{
            //    Bike.Connect();
            //    Console.WriteLine("Attempting bike connect attempt...");
            //    Thread.Sleep(1000);
            //}

            //Console.WriteLine("Bike is connected");
            //Console.WriteLine("Press enter to start AstrandClient");

            //ConsoleKey b = ConsoleKey.A;

            //while (b != ConsoleKey.Enter)
            //{
            //    b = Console.ReadKey().Key;
            //}


            //// Generate test
            //AstrandWrapper astrand = new AstrandWrapper(Bike, AstrandWrapper.CreateAstrandClientOne());
            //// Start test
            //astrand.Start();

            //while (!astrand.CancellationPending) { }

            //AstrandResults results = astrand.endTest();

            //Console.WriteLine("Your blabla is :" + results.score);

        }

        static void Main(string[] args)
        {
            new Program().App();            
        }
    }
}
