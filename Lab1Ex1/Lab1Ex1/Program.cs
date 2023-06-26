using System;

namespace Laborator1
{
    class Program
    {

        //        Scrieti un program care citind de la tastaura cele trei dimensiuni ale unui paralelipiped dreptunghic, va afisa volumul lui
        static void Main(string[] args)
        {
            float length = 0;
            float width = 0;
            float height = 0;

            length = HandleUserInput("LUNGIMII");

            width = HandleUserInput("LATIMII");

            height = HandleUserInput("INALTIMII");

            float volume = ComputeVolume(length, width, height);

            Console.WriteLine(volume.ToString());
            Console.ReadLine();
        }

        private static float ComputeVolume(float length, float width,float height)
        {
            return length * width * height;
        }

        private static float HandleUserInput(string measure)
        {
            Console.WriteLine("Introduceti valoarea "+ measure+ " (cm):");

            float output;
            string input = Console.ReadLine().Trim().Replace(".",",");

            bool parseResult = float.TryParse(input, out output);
            while (!parseResult)
            {
                Console.WriteLine("Introduceti un numar real pozitiv");
                input = Console.ReadLine().Trim();
                parseResult = float.TryParse(input, out output);
            }

            return output;
        }
    }
}
