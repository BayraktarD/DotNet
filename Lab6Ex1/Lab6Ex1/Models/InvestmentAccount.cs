using Lab6Ex1.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6Ex1.Models
{
    class InvestmentAccount : BankAccount
    {
        public InvestmentAccount(int drawingDeadline)
        {
            Console.WriteLine("_______________________________________________________________________\r\n\tDeschidere cont de investitii\r\n_______________________________________________________________________");

            this.AccountType = (int)AccountTypes.InvestmentAccount;
            this.InterestRate = 0;
            this.CurrentBalance = 0;

            if (drawingDeadline >= 1 && drawingDeadline <= 31)
            {
                this.WithdrawalDay = drawingDeadline;
            }
            else
            {
                this.WithdrawalDay = 15;
            }
        }
        public int WithdrawalDay { get; set; }

        public bool WithdrawMoney(int withdrawValue)
        {
            int currentDayDate = DateTime.Now.Date.Day;

            if (currentDayDate < this.WithdrawalDay)
            {
                Console.WriteLine("\tRetragerea a esuat. Ziua termen de retragere este: " + WithdrawalDay.ToString());
                return false;
            }

            return Withdraw(withdrawValue);
        }

        public void GetInvestmentAccountInfo()
        {
            string accountInfo = GetAccountInfo();

            accountInfo += "\r\n\tZiua termen de extragere: " + this.WithdrawalDay.ToString();

            Console.WriteLine(accountInfo);
        }

    }
}
