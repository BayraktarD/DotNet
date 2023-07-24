using Lab5Ex2.Enums;
using Lab5Ex2.Models;
using System;
using System.Threading;

namespace Lab5Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializare tren...\r\n---------------------------------------------------");

            Train train = new Train();

            train.Locomotive.PowerInKw = 600;

            train.AddCargoWagon((int)CargoTypes.Cereals, 1000,1953,140);

            train.AddCargoWagon((int)CargoTypes.Coal, 150, 1953, 140);
            train.AddCargoWagon((int)CargoTypes.Steel, 130, 1953, 140);

            train.AddPassengerWagon(50, 1993, 150);
            train.AddFirstClassPassengerWagon(25, 2005, 160);

            train.DepartureFromTheRailwayStation();

            Thread.Sleep(5000);
            train.StopAtRailwayStation();

            Console.WriteLine("Train Info:");
            Console.WriteLine(train.ToString()); 
            Console.ReadLine();
        }
    }
}
