using System;

namespace Lab1Ex8
{
    //Scrieti un program care interschimba valoarea a doua variabile intreg
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti valoarea pentru variabila X :");
            int x = ValidateUserInput();

            Console.WriteLine("Introduceti valoarea pentru variabila Y :");
            int y = ValidateUserInput();

            Console.WriteLine("Interschimbare...");
            int z = y;
            y = x;
            x = z;

            Console.WriteLine("Rezultatul interschimbarii:");
            Console.WriteLine("X = " + x.ToString()) ;
            Console.WriteLine("Y = " + y.ToString());

        }

        private static int ValidateUserInput()
        {
            int output;
            string input = Console.ReadLine().Trim().Replace(".", ",");

            bool parseResult = int.TryParse(input, out output);

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
