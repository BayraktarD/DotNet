using Proiect___Catalog_Online.DTOs;
using System.Data;
using static Proiect___Catalog_Online.DTOs.MarkDTO;

namespace Proiect___Catalog_Online.Interfaces.Services
{
    /// <summary>
    /// Teacher Service Interface
    /// </summary>
    public interface ITeacherService
    {
        /// <summary>
        /// Returneaza lista profesorilor
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TeacherDTO>> GetTeachersAsync();

        /// <summary>
        /// Add Teacher
        /// </summary>
        /// <param name="teacherDTO"></param>
        /// <returns>int - new teacher id; string - status</returns>
        Task<Dictionary<int, string>> AddTeacherAsync(TeacherDTO teacherDTO);


        /// <summary>
        /// Delete teacher
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        Task<Dictionary<int, string>> DeleteTeacherAsync(int teacherId);

        /// <summary>
        /// Actualizare adresa profesor
        /// </summary>
        /// <param name="teacherId">id profesor</param>
        /// <param name="addressDTO">adresa</param>
        /// <returns></returns>
        Task<Dictionary<int, string>> UpdateTeacherAddressAsync(int teacherId, AddressDTO addressDTO);

        /// <summary>
        /// Promovare Profesor
        /// </summary>
        /// <param name="teacherId">id profesor</param>
        /// <returns></returns>
        Task<Dictionary<int, string>> PromoteTeacherAsync(int teacherId);

        /// <summary>
        /// Returneaza lista notelor acordate de profesor
        /// </summary>
        /// <param name="teacherId">Id profesor</param>
        /// <returns></returns>
        Task<Dictionary<int, List<StudentSubjectDTO>>> GetTeacherMarksAsync(int teacherId);
    }
}
