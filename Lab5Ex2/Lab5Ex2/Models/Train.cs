using Lab5Ex2.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5Ex2.Models
{
    class Train
    {
        public Train()
        {
            Locomotive = new Locomotive();
            FreightWagons = new List<FreightWagon>();
            PassengerWagons = new List<PassengerWagon>();
            FirstClassPassengerWagons = new List<FirstClassPassengerWagon>();
        }

        public string Name { get; set; }
        public Locomotive Locomotive { get; set; }
        public List<FreightWagon> FreightWagons { get; set; }
        public List<PassengerWagon> PassengerWagons { get; set; }
        public List<FirstClassPassengerWagon> FirstClassPassengerWagons { get; set; }

        public override string ToString()
        {
            string ret = this.Name + " \r\nLocomotiva: " + this.Locomotive.ToString();

            if (FreightWagons.Count > 0)
            {
                ret = GetFreightWagonsInfo(ret);
            }
            if (PassengerWagons.Count > 0)
            {
                ret = GetPassengerWagonsInfo(ret);
            }

            if (FirstClassPassengerWagons.Count > 0)
            {
                ret = GetFirstClassPassengerWagonsInfo(ret);
            }


            return ret;
        }

        private string GetFirstClassPassengerWagonsInfo(string ret)
        {
            ret += "\r\nVagoane de calatorie clasa 1: ";
            foreach (var firstClassPassengerWagon in FirstClassPassengerWagons)
            {
                ret += "\r\n\t" + firstClassPassengerWagon.ToString();
            }
            ret += "\r\n__________________________________________________";

            return ret;
        }

        private string GetPassengerWagonsInfo(string ret)
        {
            ret += "\r\nVagoane de persoane: ";
            foreach (var passengerWagon in PassengerWagons)
            {
                ret += "\r\n\t" + passengerWagon.ToString();
            }
            ret += "\r\n__________________________________________________";

            return ret;
        }

        private string GetFreightWagonsInfo(string ret)
        {
            ret += "\r\nVagoane de marfa: ";
            foreach (var freightWagon in FreightWagons)
            {
                ret += "\r\n\t" + freightWagon.ToString();
            }
            ret += "\r\n__________________________________________________";
            return ret;
        }

        public void DepartureFromTheRailwayStation()
        {
            if (PassengerWagons.Count > 0 || FirstClassPassengerWagons.Count > 0)
            {
                foreach (var passengerWagon in PassengerWagons)
                {
                    passengerWagon.CloseDoors();
                }

                foreach (var firstClassPassengerWagon in FirstClassPassengerWagons)
                {
                    firstClassPassengerWagon.CloseDoors();
                }
            }

            this.Locomotive.Start();

        }

        public void StopAtRailwayStation()
        {
            this.Locomotive.Stop();

            if (PassengerWagons.Count > 0 || FirstClassPassengerWagons.Count > 0)
            {
                foreach (var passengerWagon in PassengerWagons)
                {
                    passengerWagon.OpenDoors();
                }

                foreach (var firstClassPassengerWagon in FirstClassPassengerWagons)
                {
                    firstClassPassengerWagon.OpenDoors();
                    firstClassPassengerWagon.StopAirConditioning();
                }
            }
        }

        public void AddCargoWagon(int cargoType, decimal capacityInTons, int yarOfManufacturing, decimal weight)
        {
            FreightWagon freightWagon = new FreightWagon();
            freightWagon.SetCargoType(cargoType);
            freightWagon.CapacityInTons = capacityInTons;
            freightWagon.YearOfManufacture = yarOfManufacturing;
            freightWagon.Weight = weight;

            this.FreightWagons.Add(freightWagon);
        }

        public void AddPassengerWagon(int numberOfSeats, int yarOfManufacturing, decimal weight)
        {
            PassengerWagon passengerWagon = new PassengerWagon();
            passengerWagon.NumberOfSeats = numberOfSeats;
            passengerWagon.YearOfManufacture = yarOfManufacturing;
            passengerWagon.Weight = weight;


            this.PassengerWagons.Add(passengerWagon);
        }

        public void AddFirstClassPassengerWagon(int numberOfSeats, int yarOfManufacturing, decimal weight)
        {
            FirstClassPassengerWagon firstClassPassengerWagon = new FirstClassPassengerWagon();
            firstClassPassengerWagon.NumberOfSeats = numberOfSeats;
            firstClassPassengerWagon.YearOfManufacture = yarOfManufacturing;
            firstClassPassengerWagon.Weight = weight;


            this.FirstClassPassengerWagons.Add(firstClassPassengerWagon);
        }

    }
}
