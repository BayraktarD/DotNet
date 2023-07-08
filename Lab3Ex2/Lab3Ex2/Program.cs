using System;

namespace Lab3Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti un sir de caractere: ");
            string input = Console.ReadLine();
            Console.WriteLine("Introduceti secventa a carei pozitie doriti sa fie returnata: ");
            string substring = Console.ReadLine();
            while (!input.Contains(substring))
            {
                Console.WriteLine("Sirul initial nu contine secventa: " + substring+". Incercati din nou.");
                substring = Console.ReadLine();
            }
            if (input.Contains(substring))
            {
                Console.WriteLine("Secventa introdusa incepe cu pozitia "+input.IndexOf(substring));
            }
           
        }
    }
}
