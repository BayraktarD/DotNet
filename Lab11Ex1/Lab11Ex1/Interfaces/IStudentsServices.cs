using Lab11Ex1.Models;

namespace Lab11Ex1.Interfaces
{
    public interface IStudentsServices
    {
        List<Student> GetAllStudents();
        Student GetStudentById(int id);
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id, bool deleteStudentAddress);
        Address GetStudentAddress(int studentId);
        void UpdateStudentAddress(int studentId, Address address);
    }
}
