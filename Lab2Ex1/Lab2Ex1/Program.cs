using System;
using System.Collections.Generic;

namespace Lab2Ex1
{

    //Scrieti o functie care citeşte de la tastatură un şir de n numere naturale şi
    // determină media aritmetică a celor pare, n fiind citit de la tastatra
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti lungimea sirului de numere:");
            int lenght = HandleUserInput(Console.ReadLine());
            Console.WriteLine("Introduceti numerele din sir cate unul pe rand");
            List<int> numbers = new List<int>();
            for (int i = 1; i <= lenght; i++)
            {
                numbers.Add(HandleUserInput(Console.ReadLine()));
            }

            var evenNumbers = GetEvenNumbers(numbers);
            if (evenNumbers.Count > 0)
            {
                Console.WriteLine("Media aritmetica a numerelor pare este "+ComputeArithmeticMean(evenNumbers).ToString());
            }
        }

        private static decimal ComputeArithmeticMean(List<int> evenNumbers)
        {
            int sum = 0;
            foreach (var evenNumber in evenNumbers)
            {
                sum += evenNumber;
            }

            decimal ret = sum / evenNumbers.Count;
            return ret;
        }

        private static List<int> GetEvenNumbers(List<int> numbers)
        {
            List<int> evenNumbers = new List<int>();
            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    evenNumbers.Add(number);
                }
            }
            return evenNumbers;
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
