using Lab6Ex1.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6Ex1.Models
{
    class CurrentAccount : BankAccount
    {
        public CurrentAccount()
        {

            Console.WriteLine("_______________________________________________________________________\r\n\tDeschidere cont curent\r\n_______________________________________________________________________");
            this.AccountType = (int)AccountTypes.CurrentAccount;
            this.InterestRate = 0;
            this.CurrentBalance = 0;
            this.OverdraftValue = 0;

        }
        private int OverdraftLimit = 5000;
        public decimal OverdraftValue { get; set; }

        public override void DepositMoney(decimal depositValue)
        {
            Console.WriteLine("Depunere " + depositValue.ToString() + " RON...");
            if (this.OverdraftValue > 0)
            {
                if (depositValue > this.OverdraftValue)
                {
                    this.CurrentBalance = depositValue - this.OverdraftValue;
                    this.OverdraftValue = 0;

                    Console.WriteLine("\tDepunerea s-a realizat cu success.\r\n\tValoarea actuala a contului curent este: " + this.CurrentBalance.ToString() + "\r\n\tValoarea descoperirii de cont actuale este: " + this.OverdraftValue.ToString());

                }
                else
                {

                    this.OverdraftValue -= depositValue;
                    Console.WriteLine("\tDepunerea s-a realizat cu success.\r\n\tValoarea actuala a contului curent este: " + this.CurrentBalance.ToString() + "\r\n\tValoarea descoperirii de cont actuale este: " + this.OverdraftValue.ToString());

                }
            }
            else
            {
                this.CurrentBalance += depositValue;
                Console.WriteLine("\tDepunerea s-a realizat cu success.\r\n\tValoarea actuala a contului curent este: " + this.CurrentBalance.ToString());
            }

        }
        public bool WithdrawMoney(decimal withdrawValue)
        {
            Console.WriteLine("Retragere suma: " + withdrawValue.ToString());
            bool withdrawalResult = false;
            if (withdrawValue > this.CurrentBalance)
            {
                decimal overdraft = withdrawValue - this.CurrentBalance;
                if (overdraft > this.OverdraftLimit)
                {
                    Console.WriteLine("\tSuma dorita pentru retragere depaseste valoarea soldului curent (" + this.CurrentBalance.ToString() + ") + descoperirea de 5000 lei disponibila!");
                    return withdrawalResult;
                }
                else if (this.OverdraftValue + overdraft > OverdraftLimit)
                {
                    Console.WriteLine("\tRetragerea nu se poate realiza din cauza faptului ca ati depasit limita descoperirii de cont actuale (5000 RON)! \r\nValoarea descoperirii actuale: " + this.OverdraftValue.ToString());
                    return withdrawalResult;
                }
                else
                {

                    this.OverdraftValue = overdraft;
                    this.CurrentBalance = 0;
                    Console.WriteLine("\tRetragerea s-a realizat cu success.\r\n\tSold curent: " + this.CurrentBalance.ToString() + "\r\n\tValoarea descoperirii actuale: " + this.OverdraftValue.ToString());

                }
            }
            else
            {
                this.CurrentBalance -= withdrawValue;
                Console.WriteLine("\tRetragerea s-a realizat cu success.\r\n\tSold curent: " + this.CurrentBalance.ToString());
            }
            return withdrawalResult;
        }

        public void ChangeOverdraftLimit(int newOverdraftLimit)
        {
            this.OverdraftLimit = newOverdraftLimit;
        }

        public void GetCurrentAccountInfo()
        {
            string accountInfo = GetAccountInfo();

            accountInfo += "\r\n\tValoare descoperire de cont: " + this.OverdraftValue.ToString();

            Console.WriteLine(accountInfo);
        }


    }
}
