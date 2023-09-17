using CatalogOnline_ClassLibrary.EntityModels;
using Proiect___Catalog_Online.DTOs;
using Proiect___Catalog_Online.Interfaces.Repositories;
using Proiect___Catalog_Online.Interfaces.Services;

namespace Proiect___Catalog_Online.Services
{
    public class StudentService:IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        /// <summary>
        /// Returneaza lista studentilor.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<StudentDTO>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllStudentsAsync();
        }


        /// <summary>
        /// Returneaza studentul dupa Id.
        /// </summary>
        /// <param name="id">Id-ul studentului.</param>
        /// <returns></returns>
        public async Task<StudentDTO> GetStudentByIdAsync(int id)
        {
            return await _studentRepository.GetStudentByIdAsync(id);
        }



        /// <summary>
        /// Adauga un studentDTO nou in baza de date.
        /// </summary>
        /// <param name="student">Studentul</param>
        /// <returns></returns>
        public async Task<Dictionary<int, string>> AddStudentAsync(StudentDTO studentDTO)
        {
            return await _studentRepository.AddStudentAsync(studentDTO);
        }


        /// <summary>
        /// Actualizeaza un studentDTO si adresa acestuia. Adresa se actualizeaza doar daca se cere actualizarea acesteia.
        /// </summary>
        /// <param name="studentDTO"></param>
        /// <returns></returns>
        public async Task<Dictionary<int, string>> UpdateStudentAsync(StudentDTO studentDTO, bool updateAddress)
        {
            return await _studentRepository.UpdateStudentAsync(studentDTO,updateAddress);
        }



        /// <summary>
        /// Sterge un sutdent dupa id. Se poate sterge si adresa daca se cere.
        /// </summary>
        /// <param name="id">Id-ul studentului care trebuie sters.</param>
        /// <param name="deleteStudentAddress">true - sterge si adresa, false - nu sterge adresa.</param>
        /// <returns></returns>
        public async Task<Dictionary<bool, string>> DeleteStudentAsync(int id, bool deleteStudentAddress)
        { 
            return await _studentRepository.DeleteStudentAsync(id,deleteStudentAddress);
        }



        /// <summary>
        /// Returneaza adresa unui studentDTO dupa Id-ul studentului.
        /// </summary>
        /// <param name="studentId">Id-ul studentului a carui adresa dorim sa o obtinem.</param>
        /// <returns></returns>
        public async Task<AddressDTO> GetStudentAddressAsync(int studentId)
        {
            
            return await _studentRepository.GetStudentAddressAsync(studentId);
        }



        /// <summary>
        /// Actualizare adresa pentru studentul cu Id-ul funrizat.
        /// </summary>
        /// <param name="studentId">Id-ul studentului a carui adresa dorim sa o modificam.</param>
        /// <param name="addressDTO">Noua adresa a studentului.</param>
        /// <returns></returns>
        public async Task<Dictionary<int, string>> UpdateStudentAddressAsync(int studentId, AddressDTO addressDTO)
        {
            return await _studentRepository.UpdateStudentAddressAsync(studentId,addressDTO);
        }
    }
}
