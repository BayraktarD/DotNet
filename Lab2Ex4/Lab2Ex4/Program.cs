using System;

namespace Lab2Ex4
{
    class Program
    {
        //Scrieti o functie care va determina daca un numar este sau nu patrat perfect. Apelati-o si afisati-i rezultatu
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti un numar");

            int number = HandleUserInput(Console.ReadLine());

            if (CheckIfNumberIsPerfectSquare(number))
            {
                Console.WriteLine("Numarul introdus este patrat perfect");
            }
            else
            {
                Console.WriteLine("Numarul introdus NU este patrat perfect");
            }
        }

        static bool CheckIfNumberIsPerfectSquare(int numberToCheck)
        {
            double result = Math.Sqrt(numberToCheck);
            bool isSquare = result % 1 == 0;
            return isSquare;
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
    }
}
