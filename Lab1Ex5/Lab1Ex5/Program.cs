using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1Ex5
{
    class Program
    {
        //Se citesc doua numere de la tastatura, x,y.Scrieti un program care va afisa cele doua valori in ordine crescatoare.
            //• Exemplu: citim ,9,0 Afisam : 0 9 
        static void Main(string[] args)
        {
            Console.WriteLine("Introduiceti valoarea primului numar:");
            float x = ValidateUserInput();

            Console.WriteLine("Introduiceti valoarea celui de-al doilea numar:");
            float y = ValidateUserInput();

            List<float> numbers = new List<float>()
            {
                x,y
            };

            foreach (var number in numbers.OrderBy(x=>x))
            {
                Console.WriteLine(number.ToString());
            }
        }

        private static float ValidateUserInput()
        {
            float output;
            string input = Console.ReadLine().Trim().Replace(".", ",");

            bool parseResult = float.TryParse(input, out output);

            while (!parseResult)
            {
                Console.WriteLine("Introduceti un numar real!");
                input = Console.ReadLine().Trim().Replace(".", ",");
                parseResult = float.TryParse(input, out output);
            }

            return output;

        }
    }
}
