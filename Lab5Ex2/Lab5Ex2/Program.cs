using Lab5Ex2.Enums;
using Lab5Ex2.Models;
using System;
using System.Threading;

namespace Lab5Ex2
{
    class Program
    {

        //        Ex 2 – mostenire
        //• Un tren este compus din: o locomotiva si mai multe
        //vagoane de mai multe tipuri.
        // Locomotiva va avea
        // Putere : puterea exprimata in kw
        // O metoda de pornire, la apelul careia, aceasta va confirma
        //faptul ca a pornit printr-un mesaj afisat in consola,
        // O metoda de oprire, la apelul careia, aceasta va confirma
        //faptul ca a oprit printr-un mesaj afisat in consola,
        // Vagoanele vor avea masa si anul fabricatiei si vor fi de
        //mai multe tipuri
        // Vagoane de marfa, care vor avea
        // tipul marfii (cereale/carbuni/otel) precum si
        //capacitatea in tone
        // Vagoane pentru persoane, care vor avea
        // numar de locuri
        // O metoda care va inchide usile si va confirma in consola
        //inchiderea usilor
        // O metoda care va deschide usile si va confirma in
        //consola deschiderea usilor
        // Vagoane clasa I, pentru persoane
        // O metoda de pornire a aerului conditionat care va afisa
        //acest lucru pe ecran
        // O metoda de oprire a aerului conditionat care va afisa
        //acest lucru pe ecran
        //• Trenul va avea un nume precum si urmatoarele
        //metode
        // Adauga vagon
        // Aceasta metoda va permite adaugarea vagoanelor la tren
        // Pleaca din gara
        // La aceasta comanda, trenul va inchide usile vagoanelor de
        //persoane si va porni locomotiva
        // Opreste in gara
        // La aceasta comanda, trenul va opri locomotiva, va deschide
        //usile vagoanelor de persoane si va opri aerul conditionat in
        //vagoanele clasa 1
        //Proiectati clasele, initializati un tren, adaugati-i
        //vagoane si apelati metodele.Realizati diagrama UML
        //a claselor


        //Optional

//        Trenul, locomotiva si vagoanele vor suprascrie metoda “ToString” astfel:
// Toate vagoanele vor returna pe metoda ToString si informatiile despre masa si anul
//de fabricatie.
// Vagoanele de marfa vor returna tipul marfii si cantitatea
// Ex : Vagon de marfa.Tipul combustibilului: otel.Cantitatea marfii 130t.Anul fabricatiei
//1953. Masa totala: 140t
// Vagoanele de persoane numarul de locuri
// Ex : Vagon de persoane.Numar de locuri : 60. Anul fabricatiei 1953. Masa totala: 140t
// Locomotiva va returna puterea putere
// Ex : Locomotiva putere 6000kW
// Trenul
// Va returna numele trenului precum si toate informatiile despre locomotiva si vagoane.
//• Apelati metoda ToString si afisati rezultatul.


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
