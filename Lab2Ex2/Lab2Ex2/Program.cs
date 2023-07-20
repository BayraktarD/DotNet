using System;

namespace Lab2Ex2
{
    //Scrieti o functie care va determina daca un numar este sau nu palindrom.

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti de la tastatura un Numar");
            int number = HandleUserInput(Console.ReadLine().Trim());
            string inputNumber = number.ToString();
            var array = inputNumber.ToCharArray();
            Array.Reverse(array);
            string reverseNumber = string.Empty;
            for (int i = 0; i < array.Length; i++)
            {
                reverseNumber += array[i];
            }

            if (inputNumber == reverseNumber)
            {
                Console.WriteLine("Numarul introdus este PALINDROM");
            }
            else
            {
                Console.WriteLine("Numarul introdus NU este PALINDROM");
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
    }
}
