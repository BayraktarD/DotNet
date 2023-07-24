using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5Ex2.Models
{
    class PassengerWagon : Wagon
    {
        public int NumberOfSeats { get; set; }

        public void CloseDoors()
        {
            Console.WriteLine("Doors are closed!\r\n___________________________________");
        }
        public void OpenDoors()
        {
            Console.WriteLine("Doors are opened!\r\n___________________________________");
        }

        public override string ToString()
        {
            return "Vagon de persoane.Numar de locuri : " + this.NumberOfSeats + ". Anul fabricatiei: " + this.YearOfManufacture.ToString() + ". Masa totala: " + this.Weight.ToString();
        }
    }
}
