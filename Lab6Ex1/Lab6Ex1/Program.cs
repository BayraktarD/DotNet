using Lab6Ex1.Models;
using System;

namespace Lab6Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount bankAccount = new BankAccount();


            CurrentAccount currentAccount = new CurrentAccount();
            currentAccount.CurrentBalance = 0;
            Console.WriteLine("Tranzactii cont curent:");
            Console.WriteLine("____________________________________________________________________________");
            currentAccount.DepositMoney(500);
            currentAccount.WithdrawMoney(240);
            currentAccount.WithdrawMoney(10);
            currentAccount.DepositMoney(200);
            currentAccount.WithdrawMoney(104);
            currentAccount.WithdrawMoney(1000);
            currentAccount.DepositMoney(500);
            currentAccount.DepositMoney(150);
            currentAccount.DepositMoney(10);


            CurrentAccount currentAccount1 = new CurrentAccount();
            CurrentAccount currentAccount2 = new CurrentAccount();

            Console.WriteLine("----------------------------------------------------------------------------");


            SavingsAccount savingsAccount = new SavingsAccount(0.015m);
            Console.WriteLine("Tranzactii cont de economii:");
            Console.WriteLine("____________________________________________________________________________");
            savingsAccount.DepositMoney(2000);
            savingsAccount.DepositMoney(100);
            savingsAccount.DepositMoney(550);

            SavingsAccount savingsAccount1 = new SavingsAccount(0.001m);
            Console.WriteLine("----------------------------------------------------------------------------");



            InvestmentAccount investmentAccount = new InvestmentAccount(12);
            Console.WriteLine("Tranzactii cont de investitii:");
            Console.WriteLine("____________________________________________________________________________");

            investmentAccount.DepositMoney(3000);
            investmentAccount.WithdrawMoney(1000);
            investmentAccount.WithdrawMoney(5000);


            Console.WriteLine("____________________________________________________________________________");

            Console.WriteLine("Informatii conturi curente:");
            Console.WriteLine("----------------------------------------------------------------------------");
            currentAccount.GetCurrentAccountInfo();
            currentAccount1.GetCurrentAccountInfo();
            currentAccount2.GetCurrentAccountInfo();

            Console.WriteLine("____________________________________________________________________________");

            Console.WriteLine("Informatii conturi de economii:");
            Console.WriteLine("----------------------------------------------------------------------------");
            savingsAccount.GetSavingsAccountInfo();
            savingsAccount1.GetSavingsAccountInfo();

            Console.WriteLine("____________________________________________________________________________");

            Console.WriteLine("Informatii conturi de investitii:");
            Console.WriteLine("----------------------------------------------------------------------------");
            investmentAccount.GetInvestmentAccountInfo();

            Console.WriteLine("Numar de conturi de economii deschise: " + bankAccount.GetNumberOfOpenedAccounts());
            Console.ReadLine();

        }
    }
}
