using CatalogOnline_ClassLibrary.EntityModels;
using Proiect___Catalog_Online.DTOs;
using System.Threading.Tasks;

namespace Proiect___Catalog_Online.Interfaces.Repositories
{
    /// <summary>
    /// Student Repository Interface
    /// </summary>
    public interface IStudentRepository
    {

        /// <summary>
        /// Returneaza lista studentilor
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<StudentDTO>> GetAllStudentsAsync();

        /// <summary>
        /// Returneaza studentul dupa Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<StudentDTO> GetStudentByIdAsync(int id);

        /// <summary>
        /// Adaugare student
        /// </summary>
        /// <param name="student">Detalii student</param>
        /// <returns></returns>
        Task<Dictionary<int, string>> AddStudentAsync(StudentDTO student);

        /// <summary>
        /// Actualizare date student
        /// </summary>
        /// <param name="student">Detalii student</param>
        /// <param name="updateAddress">Adresa actualizata</param>
        /// <returns></returns>
        Task<Dictionary<int, string>> UpdateStudentAsync(StudentDTO student, bool updateAddress);

        /// <summary>
        /// Stergere student
        /// </summary>
        /// <param name="id">id student ce se vrea sters</param>
        /// <param name="deleteStudentAddress">true - stergere si adresa student / false - nu se sterge adresa studentului sters</param>
        /// <returns></returns>
        Task<Dictionary<bool, string>> DeleteStudentAsync(int id, bool deleteStudentAddress);

/// <summary>
/// Return adresa student dupa id student
/// </summary>
/// <param name="studentId">id student a carui adresa se vrea returnata</param>
/// <returns></returns>
        Task<AddressDTO> GetStudentAddressAsync(int studentId);

        /// <summary>
        /// Actualizare adresa student
        /// </summary>
        /// <param name="studentId">id student a carui adresa se vrea actualizata</param>
        /// <param name="address">adresa actualizata</param>
        /// <returns></returns>
        Task<Dictionary<int, string>> UpdateStudentAddressAsync(int studentId, AddressDTO address);

        /// <summary>
        /// Returneaza lista studentilor ordonata dupa media notelor
        /// </summary>
        /// <param name="orderByAscending">true - ordoneaza crescator / fasle - ordonare descrescator</param>
        /// <returns></returns>
        Task<Dictionary<string, decimal>> GetStudentsListOrderedByMarksAverageAsync(bool orderByAscending);
    }
}
