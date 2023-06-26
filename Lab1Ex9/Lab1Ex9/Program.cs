using System;

namespace Lab1Ex9
{
    class Program
    {
            //Folosind instructiunea “switch”, scrieti un program care citind de la tastatura un numar intreg va verifica urmatoarele
            //“unu” daca numarul citit este 1
            //“doi” daca numarul citit este 2
            //“trei” daca numarul citit este 3
            //“cinci” daca numarul citit este 5
            //“opt” daca numarul citit este 8
            //“neidentificat” pentru orice alt caz
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti un numar intreg:");

            int input = ValidateUserInput();
            Console.WriteLine(IdentifyNumber(input));
            Console.ReadLine();
        }

        private static string IdentifyNumber(int input)
        {
            switch (input)
            {
                case 1:
                    return "unu";
                case 2:
                    return "doi";
                case 3:
                    return "trei";
                case 5:
                    return "cinci";
                case 8:
                    return "opt";
                default:
                    return "neidentificat";
            }


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
