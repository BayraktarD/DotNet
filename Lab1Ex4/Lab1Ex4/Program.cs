using System;

namespace Lab1Ex4
{
    class Program
    {

        //Scrieti un program care va afisa semnul unui numar citit de la tastatura
                //• Daca numarul este pozitiv, va afisa “+”
                //• Daca numarul este negativ, va afisa “-”
                //• Daca numarul este 0, va afisa “0”
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti un numar real:");
            float userInput = ValidateUserInput();

            if (userInput > 0)
            {
                Console.WriteLine("+");
            }
            else if (userInput < 0)
            {
                Console.WriteLine("-");
            }
            else
            {
                Console.WriteLine("0");
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
