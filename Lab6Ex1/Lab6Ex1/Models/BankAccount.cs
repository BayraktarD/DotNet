using Lab6Ex1.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6Ex1.Models
{
    public class BankAccount
    {
        private static int CountOfOpenedAccounts = 0;

        public Guid Id { get; set; }
        public decimal CurrentBalance { get; set; }
        public decimal InterestRate { get; set; }
        protected int AccountType { get; set; }

        public BankAccount()
        {
            this.Id = Guid.NewGuid();
            CountOfOpenedAccounts++;
        }

        public virtual void DepositMoney(decimal depositValue)
        {
            this.CurrentBalance += depositValue;
            Console.WriteLine("Depunere numerar...");
            Console.WriteLine("\tSuma depusa: " + depositValue.ToString()+"\r\n\tSold Curent: "+this.CurrentBalance.ToString());
        }

        protected bool Withdraw (decimal withdrawValue)
        {
            Console.WriteLine("Retragere suma: "+withdrawValue.ToString());
            if (withdrawValue > this.CurrentBalance)
            {
                Console.WriteLine("\tSuma de retragere depeseste suma disponibila!");
                return false;
            }
            else
            {
                this.CurrentBalance -= withdrawValue;
                Console.WriteLine("\tRetragerea a trecut cu success.\r\n\t Sold ramas: " + this.CurrentBalance.ToString());

                return true;
            }
        }

        protected string GetAccountInfo()
        {
            string accountType = GetAccountType();

            string accountInfo = "Informatii cont bancar:\r\n\tId cont bancare:" + this.Id.ToString() + "\r\n\tTip cont: " + accountType + "\r\n\tRata dobanzii: " + this.InterestRate+ " %\r\n\tSold curent: " + CurrentBalance.ToString();

            return accountInfo;
        }

        private string GetAccountType()
        {
            string accountType = string.Empty;
            switch (this.AccountType)
            {
                case (int)AccountTypes.CurrentAccount:
                    accountType = "Cont Curent";
                    break;
                case (int)AccountTypes.InvestmentAccount:
                    accountType = "Cont de Investitii";
                    break;
                case (int)AccountTypes.SavingAccount:
                    accountType = "Cont de Economii";
                    break;
            }
            return accountType;
        }

        public virtual int GetNumberOfOpenedAccounts()
        {
            return CountOfOpenedAccounts - 1;
        }

    }
}
