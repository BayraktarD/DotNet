using Lab7Ex1.Interfaces;
using Lab7Ex1.Models;
using System;

namespace Lab7Ex1
{
    //    Instantiati casa, carduri, telefoane, efectuati plati.
    //Scrieti clasa, apelati metodele, efectuati plati.Pentru verificarea functionarii programului, metodele descrise vor
    //afisa pe ecran mesaje adecvate.

    class Program
    {

        static void Main(string[] args)
        {
            IPOS pos = new POS();

            IContactLessPayment contactlessCard = new ContactlessCard();
            pos.PayUsingContactLessPaymentMethod(120.5m, contactlessCard);
            Console.WriteLine("__________________________________________________________________________________________");

            IContactLessPayment mobilePhone = new MobilePhone();
            pos.PayUsingContactLessPaymentMethod(54.99m, mobilePhone);
            Console.WriteLine("__________________________________________________________________________________________");

            IContactFullPayment contactFullCard = new ClassicCard();
            pos.PayUsingContactFullPaymentMethod(249.99m, contactFullCard);
            Console.WriteLine("__________________________________________________________________________________________");
        }
    }
}
