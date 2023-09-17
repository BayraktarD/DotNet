using Proiect___Catalog_Online.DTOs;

namespace Proiect___Catalog_Online.Interfaces.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDTO>> GetAllStudentsAsync();
        Task<StudentDTO> GetStudentByIdAsync(int id);
        Task<Dictionary<int, string>> AddStudentAsync(StudentDTO student);
        Task<Dictionary<int, string>> UpdateStudentAsync(StudentDTO student, bool updateAddress);
        Task<Dictionary<bool, string>> DeleteStudentAsync(int id, bool deleteStudentAddress);
        Task<AddressDTO> GetStudentAddressAsync(int studentId);
        Task<Dictionary<int, string>> UpdateStudentAddressAsync(int studentId, AddressDTO address);
    }
}
