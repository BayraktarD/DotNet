using System;

namespace Lab3Ex7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti N:");
            int n = int.Parse(Console.ReadLine());
            int sum = CalculateSum(n);

            Console.WriteLine($"Suma numerelor de la 1 la {n} este {sum}.");


        }

        public static int CalculateSum(int n)
        {
            if (n == 1)
                return 1;

            return n + CalculateSum(n - 1);
        }
    }
}
