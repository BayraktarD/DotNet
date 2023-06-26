using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1Ex6
{
    class Program
    {
        //Se citesc trei numere de la tastatura, x,y,z. Scrieti un program care va afisa cele trei valori in ordine descrescatoare
        //• • Exemplu: citim 3,9,0 Afisam : 9 3 0

        static void Main(string[] args)
        {
            Console.WriteLine("Introduiceti valoarea primului numar:");
            float x = ValidateUserInput();

            Console.WriteLine("Introduiceti valoarea celui de-al doilea numar:");
            float y = ValidateUserInput();

            Console.WriteLine("Introduiceti valoarea celui de-al treilea numar:");
            float z = ValidateUserInput();

            List<float> numbers = new List<float>()
            {
                x,y,z
            };

            foreach (var number in numbers.OrderByDescending(x => x))
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
