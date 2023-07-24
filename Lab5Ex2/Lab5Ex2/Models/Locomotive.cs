using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5Ex2.Models
{
    class Locomotive
    {
        public int PowerInKw { get; set; }

        public void Start()
        {
            Console.WriteLine("\t\tLocomotive has started!\r\n___________________________________"); 
        }

        public void Stop()
        {
            Console.WriteLine("\t\tLocomotive has stopped!\r\n___________________________________");
        }

        public override string ToString()
        {
            return "Locomotiva putere "+PowerInKw+"kW";
        }
    }
}
