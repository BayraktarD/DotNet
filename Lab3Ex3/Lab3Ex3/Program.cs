using System;

namespace Lab3Ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti un sir de caractere.");
            string initialString = Console.ReadLine();

            char[] inputArray = initialString.ToCharArray();
            Array.Reverse(inputArray);

            string invertedString = new string(inputArray);
            if (initialString.Equals(invertedString))
            {
                Console.WriteLine("Sirul de caractere introdus ESTE palindrom!");
            }
            else
            {
                Console.WriteLine("Sirul de caractere introdus NU ESTE palindrom!");
            }
        }
    }
}
