using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5Ex1.Models
{
    class Student
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<decimal> Marks { get; set; }

        public decimal ComputeStudentGPA()
        {
            decimal sum = 0;
            foreach (var mark in Marks)
            {
                sum += mark;
            }

            decimal gpa = sum / Marks.Count;

            return gpa;
        }

        public string GetStudentMarks()
        {
            string ret = Firstname + " " + Lastname;
            foreach (var mark in Marks)
            {
                ret += "\r\n\t\t " + mark;
            }

            ret += "\r\nMedia: " + ComputeStudentGPA().ToString()+"\r\n____________________________________________";

            return ret;
        }

        public string GetStudentFullName()
        {
            return Firstname + " " + Lastname;
        }
    }
}
