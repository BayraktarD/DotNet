using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5Ex2.Models
{
    class FirstClassPassengerWagon : PassengerWagon
    {
        public void StartAirConditioning()
        {
            Console.WriteLine("Air conditioning on!\r\n___________________________________");
        }

        public void StopAirConditioning()
        {
            Console.WriteLine("Air conditioning off!\r\n___________________________________");
        }
    }
}
