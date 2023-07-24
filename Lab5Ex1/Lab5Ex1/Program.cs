using Lab5Ex1.Models;
using System;
using System.Collections.Generic;

namespace Lab5Ex1
{
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
