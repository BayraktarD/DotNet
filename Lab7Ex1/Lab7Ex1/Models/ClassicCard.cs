using Lab7Ex1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7Ex1.Models
{
    public class ClassicCard :IContactFullPayment
    {
        public void InsertCard()
        {
            Console.WriteLine("\r\nContact Full Card Was Inserted\r\n");

        }

        public void PerformPayment(decimal paymentValue)
        {
            Console.WriteLine("\r\nThe Payment Was Performed Using Contact Full Card. Payment Value: " + paymentValue.ToString() + " c.u." + "\r\n");

        }

        public void ExtractCard()
        {
            Console.WriteLine("\r\nContact Full Card Was Extracted\r\n");
        }
    }
}
