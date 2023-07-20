using System;

namespace Lab2Ex3
{
    //Scrieti o functie care va determina daca un numar este sau nu numar prim. Apelati-o si afisati-i rezultatul

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti un numar");
            int number = HandleUserInput(Console.ReadLine());
            if (IsPrimeNumber(number))
            {
                Console.WriteLine("Numarul este prim");
            }
            else
            {
                Console.WriteLine("Numarul NU este prim");
            }
        }

        private static int HandleUserInput(string input)
        {
            input = input.Trim().Replace(".", ",");

            bool parseResult = int.TryParse(input, out int output);

            while (!parseResult)
            {
                Console.WriteLine("Introduceti un numar real!");
                input = Console.ReadLine();
                parseResult = int.TryParse(input, out output);
            }

            return output;

        }

        static bool IsPrimeNumber(int number)
        {
            int divisorsCount = 0;
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    divisorsCount++;
                    if (divisorsCount > 2)
                    {
                        return false;
                    }
                }
            }
            if (divisorsCount == 2)
            {
                return true;
            }
            return false;
        }
    }
}
