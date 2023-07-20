using System;
using System.Collections.Generic;

namespace Lab2Ex2
{
    class Program
    {
        //Scrieti o functie care afisa piramida numerelor pare, intre 2 si n, n fiind citit de la tastatura
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti limita piramidei de numere");

            int n = HandleUserInput(Console.ReadLine());

            DisplayNumberPyramidHelper(n, 2);

            
        }

        static void DisplayNumberPyramidHelper(int n, int current)
        {
            if (current > n)
                return;

            DisplayNumbers(current, current);
            Console.WriteLine();

            DisplayNumberPyramidHelper(n, current + 1);
        }

        static void DisplayNumbers(int num, int count)
        {
            if (count == 0)
                return;

            Console.Write(num + " ");
            DisplayNumbers(num, count - 1);
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
