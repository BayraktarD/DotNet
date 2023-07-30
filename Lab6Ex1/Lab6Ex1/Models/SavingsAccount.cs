using Lab6Ex1.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6Ex1.Models
{
    class SavingsAccount : BankAccount
    {
        public SavingsAccount(decimal interestRate)
        {
            Console.WriteLine("_______________________________________________________________________\r\n\tDeschidere cont de economii\r\n_______________________________________________________________________");

            this.AccountType = (int)AccountTypes.SavingAccount;
            this.InterestRate = interestRate;
            this.CurrentBalance = 0;
        }

        public override void DepositMoney(decimal depositValue)
        {
            this.CurrentBalance += depositValue;

            this.CurrentBalance = this.CurrentBalance * (1 + this.InterestRate);

            Console.WriteLine("Depunere "+depositValue.ToString()+" RON ...\r\n\tDepunerea a trecut cu success. Sold curent: " + this.CurrentBalance.ToString());
        }

        public void GetSavingsAccountInfo()
        {
            string accountInfo = GetAccountInfo();

            accountInfo += "\r\n\tRata dobanzii: " + this.InterestRate.ToString();

            Console.WriteLine(accountInfo);

        }


    }
}
