using Lab7Ex1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7Ex1.Models
{
    public class MobilePhone:IContactLessPayment
    {
        public void PutCardCloseToPayStation()
        {
            Console.WriteLine("\r\nMobile Phone Has Been Taken Near The Pay Station\r\n");
        }

        public void PerformPayment(decimal paymentValue)
        {
            Console.WriteLine("\r\nThe Payment Was Performed Using Mobile Phone. Payment Value: " + paymentValue.ToString() + " c.u." + "\r\n");
        }
    }
}
