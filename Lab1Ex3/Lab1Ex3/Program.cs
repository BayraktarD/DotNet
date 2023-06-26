using System;

namespace Lab1Ex3
{
    class Program
    {
        //Scrieti un program care va afisa ultima cifra a unui numar intreg citit de la tastaura
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti un numar INTREG:");
           string input =  ValidateUserInput();

            string lastDigit = ExtractLastDigit(input);

            Console.WriteLine("Ultima cifra a numarului intreg introdus este : "+lastDigit);
            Console.ReadLine();

        }

        private static string ValidateUserInput()
        {
            string input = Console.ReadLine().Trim().Replace(".", ",");

            bool parseResult = int.TryParse(input, out int output);

            while (!parseResult)
            {
                Console.WriteLine("Introduceti un numar INTREG!");
                input = Console.ReadLine().Trim().Replace(".", ",");
                parseResult = int.TryParse(input, out output);
            }

            return input;
        }

        private static string ExtractLastDigit(string input)
        {
            return input.Substring(input.Length - 1, 1);
        }
    }
}
