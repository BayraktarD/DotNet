using Lab7Ex1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7Ex1.Models
{
    public class ContactlessCard :IContactFullPayment,IContactLessPayment
    {
        public void InsertCard()
        {
            Console.WriteLine("\r\nContact Less Card Was Inserted\r\n");
        }

        public void PerformPayment(decimal paymentValue)
        {
            Console.WriteLine("\r\nThe Payment Was Performed Using Contact Less Card. Payment Value: " + paymentValue.ToString() + " c.u." + "\r\n");

        }

        public void ExtractCard()
        {
            Console.WriteLine("\r\nContact Less Card Was Extracted\r\n");
        }

        public void PutCardCloseToPayStation()
        {
            Console.WriteLine("\r\nContact Less Card Has Been Taken Near The Pay Station\r\n");
        }
    }
}
