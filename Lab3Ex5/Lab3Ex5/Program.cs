using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3Ex5
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
            Console.WriteLine("Introduceti un sir de caractere.");
            string input = Console.ReadLine();
            int totalVowels = input.Count(c => vowels.Contains(c));
            Console.WriteLine("Numarul total de vocale este: "+ totalVowels.ToString());
        }
    }
}
