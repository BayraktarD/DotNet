using Lab5Ex1.Models;
using System;
using System.Collections.Generic;

namespace Lab5Ex1
{

//    Catalog
            //Un catalog contine
            // numele clasei
            // lista elevilor.
            // O functie care va returna un string continand
            //numele clasei si al fiecarui elev in parte.
            // O functie “GetPremiantul” care va determina
            //elevul cu media cea mai mare.
            //• Elevii vor avea
            // nume, prenume
            // o lista de note specifica fiecarui elev.
            // O functie care va calcula media elevului
            // O functie care va returna un string sub forma
            // nume, prenume
            // nota0 nota1 nota2…. Notam
            //• In functia “Main”
            // Initializati 3 elevi
            // Initializati un catalog adaugandu-I elevii
            // Acordati note elevilor
            // Apelati metoda GetPremiantul a catalogului si
            //afisati elevul cu media cea mai mare
            // Apelati metoedele care returneaza descrierile
            //obiectelor si afisati-le rezultatele.
            //• Realiazti diagrama UML a clasei
            //• Atentie la : constructori, modificatori de
            //acces, clase.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializare studenti...\r\n--------------------------------------------------------");
            var students = InitializeStudents();

            Console.WriteLine("Initializare Catalog...\r\n--------------------------------------------------------");

            var cataloue = InitializaeCatalogue(students);

            Console.WriteLine("Initializare Note Studenti...\r\n--------------------------------------------------------");
            foreach (var student in students)
            {
                student.Marks = SetStudentMarks();
            }

            Console.WriteLine("Premiantul este:\r\n\t"+ cataloue.GetPremiantul()+ "\r\n--------------------------------------------------------");

            Console.WriteLine(cataloue.GetStudents()+ "\r\n--------------------------------------------------------");

            foreach (var student in students)
            {
                Console.WriteLine(student.GetStudentMarks()); 
            }

        }

        static List<Student> InitializeStudents()
        {
            List<Student> students = new List<Student>();

            for (int i = 1; i < 4; i++)
            {
                Student newStudent = new Student();
                newStudent.Firstname = "Firstname " + i.ToString();
                newStudent.Lastname = "Lastname " + i.ToString();
                newStudent.Marks = new List<decimal>();

                students.Add(newStudent);

            }

            return students;
        }

        static Catalogue InitializaeCatalogue(List<Student> students)
        {
            Catalogue catalogue = new Catalogue();
            catalogue.ClassName = "Class A";
            catalogue.Students = students;

            return catalogue;
        }

        static List<decimal> SetStudentMarks()
        {
            List<decimal> marks = new List<decimal>();

            Random rand = new Random();
            int marksCount = rand.Next(5, 10);

            for (int i = 0; i < marksCount; i++)
            {
                marks.Add(rand.Next(1, 10));
            }

            return marks;
        }
    }
}
