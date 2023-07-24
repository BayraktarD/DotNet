using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab5Ex1.Models
{
    class Catalogue
    {
        public string ClassName { get; set; }
        public List<Student> Students { get; set; }

        public string GetStudents()
        {
            string ret = "Clasa: " + ClassName + "\r\n\t\t";
            foreach (var student in Students)
            {
                ret += student.Firstname + " " + student.Lastname + "\r\n\t\t";
            }
            return ret;
        }
        public string GetPremiantul()
        {
            string premiantul = string.Empty;

            premiantul = Students.OrderByDescending(x => x.ComputeStudentGPA()).FirstOrDefault().GetStudentFullName();

            return premiantul;
        }

    }
}
