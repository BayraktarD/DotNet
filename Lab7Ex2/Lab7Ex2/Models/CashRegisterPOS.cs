using Lab7Ex1.Models;
using Lab7Ex2.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7Ex2.Models
{

    //    In cazul platii cu cardul, casa de marcat
    //          1. Va trimite POS-ului suma de plata
    //                  ▪ Comunicarea cu POS-ul va fi realizata prin intermediul unei interfete
    //          2. va pune la dispozitia clientului POS-ul.
    //                  ▪ Pos-ul pus la dispozitia clientului va avea “incarcata” suma de plata
    //                  ▪ Clientul(functia main) va decide modalitatea de plata prin intermediul cardului (contactless/contactfull)


    /// <summary>
    /// CashRegisterPOS se comporta ca un POS din partea 1, dar mai are o functionalitate in plus: Pos-ul pus la dispozitia clientului va avea “incarcata” suma de plata
    /// </summary>
    class CashRegisterPOS : POS, ICashRegisterPOS
    {
        public void UploadPaymentAmount(decimal paymentAmount)
        {
            Console.WriteLine("\r\nYou have payed " + paymentAmount.ToString() + " c.u.\r\n");
        }
    }
}
