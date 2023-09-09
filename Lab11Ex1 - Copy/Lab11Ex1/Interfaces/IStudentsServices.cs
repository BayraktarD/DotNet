using Lab12Ex1.Models;

namespace Lab12Ex1.Interfaces
{
    public interface IStudentsServices
    {
        Task<List<Student>> GetAllStudents();
        Task<Student> GetStudentById(int id);
        Task<Dictionary<int, string>> AddStudent(Student student);
        Task<Dictionary<int, string>> UpdateStudent(Student student, bool updateAddress);
        Task<Dictionary<bool, string>> DeleteStudent(int id, bool deleteStudentAddress);
        Task<Address> GetStudentAddress(int studentId);
        Task<Dictionary<int, string>> UpdateStudentAddress(int studentId, Address address);
    }
}
