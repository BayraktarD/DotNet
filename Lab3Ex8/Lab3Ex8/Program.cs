using System;

namespace Lab3Ex8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti n: ");
            int n = int.Parse(Console.ReadLine());
            DisplayNumberPyramidHelper(n, 1);
            Console.ReadLine();
        }

      

        static void DisplayNumberPyramidHelper(int n, int current)
        {
            if (current > n)
                return;

            DisplayNumbers(current, current);
            Console.WriteLine();

            DisplayNumberPyramidHelper(n, current + 1);
        }

        static void DisplayNumbers(int num, int count)
        {
            if (count == 0)
                return;

            Console.Write(num + " ");
            DisplayNumbers(num, count - 1);
        }
    }
}
