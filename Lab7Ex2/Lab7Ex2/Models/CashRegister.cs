using Lab7Ex2.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7Ex2.Models
{
    //    Casa de marcat va oferi metode de plata cash sau prin intermediul unui POS.
    //              • In cazul platii cash, casa de marcat
    //                  1. va deschide un seif
    //                  2. va introduce suma in seif
    //                  3. va inchide seif-ul
    //                  4. Va elibera chitanta
    //                                    Aceasta functionalitate va fi modelata printr-o metoda care va primi un singur parametru, suma de plata.
    //                                    La fiecare dintre operatiunile de mai sus, un mesaj corespunzator va fi afisat pe ecran

    public class CashRegister: ICashRegister
    {

        private decimal LastEnteredAmount;
        public void OpenSafe()
        {
            Console.WriteLine("The Safe Was Opened\r\n");
        }
        public void CloseSafe()
        {
            Console.WriteLine("The Safe Was Closed\r\n");
        }

        public void EnterAmountInSafe(decimal paymentAmount)
        {
            this.LastEnteredAmount = paymentAmount;
            Console.WriteLine("The Amount of "+ paymentAmount.ToString()+ " Was Entered In Safe\r\n");
        }

        public void PrintReceipt(decimal goodsValue)
        {
            Console.WriteLine("\t\t\tReceipt\r\n\t\tValue of goods: " + goodsValue.ToString()+ " c.u.\r\n");
        }

        public decimal GetLastEnteredAmount()
        {
            return this.LastEnteredAmount;
        }
    }
}
