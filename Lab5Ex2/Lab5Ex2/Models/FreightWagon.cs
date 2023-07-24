using Lab5Ex2.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5Ex2.Models
{
    class FreightWagon : Wagon
    {
        private int CargoType;

        public decimal CapacityInTons { get; set; }

        public void SetCargoType(int cargoType)
        {
            CargoType = cargoType;
        }
        public string GetCargoType()
        {
            switch (CargoType)
            {
                case (int)CargoTypes.Cereals:
                    return "Cereale";
                case (int)CargoTypes.Coal:
                    return "Carbuni";
                case (int)CargoTypes.Steel:
                    return "Otel";
                default:
                    return null;
            }
        }

        decimal TotalWeight()
        {
            return this.CapacityInTons + this.Weight;
        }

        public override string ToString()
        {
            return "Vagon de marfa. Tipul marfii: " + this.GetCargoType().ToUpper() + ". Cantitatea marfii: " + this.CapacityInTons.ToString() + ". Anul fabricatiei: " + this.YearOfManufacture.ToString() + ". Masa totala: " + TotalWeight().ToString();
        }

    }
}
