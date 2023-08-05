using System;
using Lab7Ex1;
using Lab7Ex1.Interfaces;
using Lab7Ex1.Models;
using Lab7Ex2.Interfaces;
using Lab7Ex2.Models;

namespace Lab7Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("___________________________________Paying with Cash___________________________________\r\n");
            ICashRegister cashRegister = new CashRegister();
            cashRegister.OpenSafe();
            cashRegister.EnterAmountInSafe(499.99m);
            cashRegister.CloseSafe();
            cashRegister.PrintReceipt(cashRegister.GetLastEnteredAmount());

            Console.WriteLine("___________________________________Paying Using POS___________________________________\r\n");
            ICashRegisterPOS cashRegisterPOS = new CashRegisterPOS();

            Console.WriteLine("-----------------------------------Classic Card-----------------------------------\r\n");
            IContactFullPayment classicCard = new ClassicCard();
            cashRegisterPOS.PayUsingContactFullPaymentMethod(54.99m, classicCard);
            cashRegisterPOS.UploadPaymentAmount(54.99m);

            Console.WriteLine("-----------------------------------Contactless Card-----------------------------------\r\n");
            IContactLessPayment contactLessCard = new ContactlessCard();
            cashRegisterPOS.PayUsingContactLessPaymentMethod(129.99m, contactLessCard);
            cashRegisterPOS.UploadPaymentAmount(129.99m);

            Console.WriteLine("-----------------------------------Mobile Phone-----------------------------------\r\n");
            IContactLessPayment mobilePhone = new MobilePhone();
            cashRegisterPOS.PayUsingContactLessPaymentMethod(499.99m, mobilePhone);
            cashRegisterPOS.UploadPaymentAmount(499.99m);

        }
    }
}
