using CatalogOnline_ClassLibrary.EntityModels;
using Proiect___Catalog_Online.DTOs;
using Proiect___Catalog_Online.Enums;
using Proiect___Catalog_Online.Interfaces.Repositories;
using Proiect___Catalog_Online.Interfaces.Services;
using System.Data;
using static Proiect___Catalog_Online.DTOs.MarkDTO;

namespace Proiect___Catalog_Online.Services
{
    /// <summary>
    /// Teacher Service Class
    /// </summary>
    public class TeacherService:ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;


        /// <summary>
        /// Teacher Service Constructor
        /// </summary>
        /// <param name="teacherRepository"></param>
        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        /// <summary>
        /// Returneaza lista profesorilor
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TeacherDTO>> GetTeachersAsync()
        {
            return await _teacherRepository.GetTeachersAsync();
        }

        /// <summary>
        /// Add Teacher
        /// </summary>
        /// <param name="teacherDTO"></param>
        /// <returns>int - new teacher id; string - status</returns>
        public async Task<Dictionary<int, string>> AddTeacherAsync(TeacherDTO teacherDTO)
        {
            return await _teacherRepository.AddTeacherAsync(teacherDTO);
        }


        /// <summary>
        /// Delete teacher
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        public async Task<Dictionary<int, string>> DeleteTeacherAsync(int teacherId)
        {
           return await _teacherRepository.DeleteTeacherAsync(teacherId);

        }


        /// <summary>
        /// Actualizare adresa profesor
        /// </summary>
        /// <param name="teacherId">id profesor</param>
        /// <param name="addressDTO">adresa</param>
        /// <returns></returns>
        public async Task<Dictionary<int, string>> UpdateTeacherAddressAsync(int teacherId, AddressDTO addressDTO)
        {
            return await _teacherRepository.UpdateTeacherAddressAsync(teacherId, addressDTO);
        }

        /// <summary>
        /// Promovare Profesor
        /// </summary>
        /// <param name="teacherId">id profesor</param>
        /// <returns></returns>
        public async Task<Dictionary<int, string>> PromoteTeacherAsync(int teacherId)
        {
            return await _teacherRepository.PromoteTeacherAsync(teacherId);
        }


        /// <summary>
        /// Returneaza lista notelor acordate de profesor
        /// </summary>
        /// <param name="teacherId">Id profesor</param>
        /// <returns></returns>
        public async Task<Dictionary<int, List<StudentSubjectDTO>>> GetTeacherMarksAsync(int teacherId)
        {
            return await _teacherRepository.GetTeacherMarksAsync(teacherId);
        }
    }
}
