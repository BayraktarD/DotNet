using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti dimensiunea vectorului:");
            int arrayLenght = ValidateUserInput();
            int[] numbers = new int[arrayLenght];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = ValidateUserInput();
            }


            DisplayLargestValue(numbers);
            DisplayLowestValue(numbers);
            List<int> numbersDivisibleWith3 = GetNumbersDivisibleWithN(numbers, 3);
            Console.WriteLine("Numerele divizibile cu 3 sunt:");
            Console.WriteLine("[{0}]", string.Join(", ", numbersDivisibleWith3));


            Array.Reverse(numbers);
            Console.WriteLine("Vectorul inversat este:");
            Console.WriteLine("[{0}]", string.Join(", ", numbers));

            List<int> primeNumbers = GetPrimeNumbers(numbers);
            Console.WriteLine("Numerele Prime sunt:");
            Console.WriteLine("[{0}]", string.Join(", ", primeNumbers));

            Console.ReadLine();
        }

        static void DisplayLargestValue(int[] numbers)
        {
            Console.WriteLine("Cel mai mare numar din vector este: " + numbers.Max().ToString());
        }

        static void DisplayLowestValue(int[] numbers)
        {
            Console.WriteLine("Cel mai mic numar din vector este: " + numbers.Min().ToString());
        }

        static List<int> GetNumbersDivisibleWithN(int[] numbers, int n)
        {
            List<int> numbersDivisibleWithN = new List<int>();

            foreach (var number in numbers)
            {
                if (number % n == 0)
                {
                    numbersDivisibleWithN.Add(number);
                }
            }

            return numbersDivisibleWithN;
        }

        static List<int> GetPrimeNumbers(int[] numbers)
        {
            List<int> primeNumbers = new List<int>();
            foreach (var number in numbers)
            {
                int divisorsCount = 0;
                for (int i = 1; i <= number; i++)
                {
                    if (number % i == 0)
                    {
                        divisorsCount++;
                        if (divisorsCount > 2)
                        {
                            break;
                        }
                    }
                }
                if (divisorsCount == 2)
                {
                    primeNumbers.Add(number);
                }

            }

            return primeNumbers;
        }

        static int ValidateUserInput()
        {
            string input = Console.ReadLine().Trim().Replace(".", ",");

            bool parseResult = int.TryParse(input, out int output);

            while (!parseResult)
            {
                Console.WriteLine("Introduceti un numar INTREG!");
                input = Console.ReadLine().Trim().Replace(".", ",");
                parseResult = int.TryParse(input, out output);
            }

            return output;
        }

    }
}
