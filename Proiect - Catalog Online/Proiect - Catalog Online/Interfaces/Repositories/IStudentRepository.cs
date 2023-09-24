using CatalogOnline_ClassLibrary.EntityModels;
using Proiect___Catalog_Online.DTOs;
using System.Threading.Tasks;

namespace Proiect___Catalog_Online.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<StudentDTO>> GetAllStudentsAsync();
        Task<StudentDTO> GetStudentByIdAsync(int id);
        Task<Dictionary<int, string>> AddStudentAsync(StudentDTO student);
        Task<Dictionary<int, string>> UpdateStudentAsync(StudentDTO student, bool updateAddress);
        Task<Dictionary<bool, string>> DeleteStudentAsync(int id, bool deleteStudentAddress);
        Task<AddressDTO> GetStudentAddressAsync(int studentId);
        Task<Dictionary<int, string>> UpdateStudentAddressAsync(int studentId, AddressDTO address);
        Task<Dictionary<string, decimal>> GetStudentsListOrderedByMarksAverageAsync(bool orderByAscending);
    }
}
