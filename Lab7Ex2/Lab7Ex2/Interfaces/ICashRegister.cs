using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7Ex2.Interfaces
{
    //    Casa de marcat va oferi metode de plata cash sau prin intermediul unui POS.
    //              • In cazul platii cash, casa de marcat
    //                  1. va deschide un seif
    //                  2. va introduce suma in seif
    //                  3. va inchide seif-ul
    //                  4. Va elibera chitanta
    //                                    Aceasta functionalitate va fi modelata printr-o metoda care va primi un singur parametru, suma de plata.
    //                                    La fiecare dintre operatiunile de mai sus, un mesaj corespunzator va fi afisat pe ecran

    public interface ICashRegister
    {
        void OpenSafe();
        void EnterAmountInSafe(decimal paymentAmount);
        void CloseSafe();
        void PrintReceipt(decimal goodsValue);
        decimal GetLastEnteredAmount();
    }
}
