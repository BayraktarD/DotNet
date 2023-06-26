using System;

namespace Lab1Ex2
{
    class Program
    {
        //Scrieti un program care va calcula media aritmetica a trei numere citite de la tastatura
        static void Main(string[] args)
        {
            Console.WriteLine("Calcul medie aritmetica a trei numere.");
            decimal numer1 = HandleUserInput("PRIMUL");
            decimal numer2 = HandleUserInput("al DOILEA");
            decimal numer3 = HandleUserInput("al TREILEA");

            decimal[] numbers = new decimal[3]
            {
                numer1,
                numer2,
                numer3
            };

            decimal mean = ComputeArithmeticMean(numbers);

            Console.WriteLine("Media aritmetica este de: "+mean.ToString());
            Console.ReadLine();

        }

        private static decimal ComputeArithmeticMean(decimal[] numbers)
        {
            int denominator = numbers.Length;

            decimal sum = 0;

            foreach (decimal number in numbers)
            {
                sum += number;
            }

            return sum / denominator;
        }

        private static decimal HandleUserInput(string numberOrder)
        {
            Console.WriteLine("Introduceti " + numberOrder + " numar:");

            decimal output;
            string input = Console.ReadLine().Trim().Replace(".",",");

            bool parseResult = decimal.TryParse(input, out output);

            while (!parseResult)
            {
                Console.WriteLine("Introduceti un numar real!");
                input = Console.ReadLine();
                parseResult = decimal.TryParse(input, out output);
            }

            return output;

        }
    }
}
