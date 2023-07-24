using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5Ex2.Models
{
    class Wagon
    {
        public decimal Weight { get; set; }
        public int YearOfManufacture { get; set; }

        public override string ToString()
        {
            return "Masa: " + this.Weight.ToString() + "\r\nAnul Fabricatiei: " + this.YearOfManufacture.ToString();
        }

    }
}
