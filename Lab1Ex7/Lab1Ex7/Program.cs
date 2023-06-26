using System;

namespace Lab1Ex7
{
    class Program
    {
        //        Scrieti un program care va verifica daca un numar citit de la tastatura este par sau impar
        // In cazul in care numarul este par, programul va afisa “par” iar in caz contrar, “impar”.
        // Google :even and odd number
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti un numar real:");

            float input = ValidateUserInput();

            if (input % 2 == 0)
            {
                Console.WriteLine("par");
            }
            else
            {
                Console.WriteLine("impar");
            }

            Console.ReadLine();
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
