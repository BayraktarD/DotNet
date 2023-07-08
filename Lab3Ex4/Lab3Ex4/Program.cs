using System;
using System.Globalization;
using System.Threading;

namespace Lab3Ex4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti un sir de caractere");
            string input = Console.ReadLine();

            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;

            Console.WriteLine(textInfo.ToTitleCase(input.ToLower()));
        }

    }
}
