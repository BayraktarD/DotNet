using CatalogOnline_ClassLibrary.EntityModels;
using Microsoft.EntityFrameworkCore;
using Proiect___Catalog_Online.DTOs;
using Proiect___Catalog_Online.Interfaces.Repositories;
using Proiect___Catalog_Online.Interfaces.Services;
using System.Net;

namespace Proiect___Catalog_Online.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _db;
        private readonly IAddressService _addressService;
        public StudentRepository(SchoolDbContext db, IAddressService addressService)
        {
            _db= db;
            _addressService= addressService;
        }

        /// <summary>
        /// Returneaza lista studentilor.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<StudentDTO>> GetAllStudentsAsync()
        {
            var students = _db.Students.ToList();

            foreach (var student in students)
            {
                student.Address = _db.Addresses.FirstOrDefault(x => x.StudentId == student.Id);
            }

            IEnumerable<StudentDTO> studentDTOs = students.Select(s => new StudentDTO(s));

            return studentDTOs;
        }


        /// <summary>
        /// Returneaza studentul dupa Id.
        /// </summary>
        /// <param name="id">Id-ul studentului.</param>
        /// <returns></returns>
        public async Task<StudentDTO> GetStudentByIdAsync(int id)
        {
            var student = _db.Students.SingleOrDefault(x => x.Id == id);

            student.Address = _db.Addresses.FirstOrDefault(x => x.StudentId == student.Id);

            var studentDTO = new StudentDTO(student);

            var marks = _db.Marks.Where(x => x.StudentId == student.Id).ToList();

            return studentDTO;
        }



        /// <summary>
        /// Adauga un studentDTO nou in baza de date.
        /// </summary>
        /// <param name="student">Studentul</param>
        /// <returns></returns>
        public async Task<Dictionary<int, string>> AddStudentAsync(StudentDTO studentDTO)
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            try
            {
                var student = new Student()
                {
                    FirstName = studentDTO.FirstName,
                    LastName = studentDTO.LastName,
                    Age = (int)studentDTO.Age,
                };

                await _db.Students.AddAsync(student);
                await _db.SaveChangesAsync();
                if (studentDTO.Address != null)
                {
                    studentDTO.Address.StudentId = student.Id;

                    var addressAddResult = await _addressService.AddAdressAsync(studentDTO.Address);
                    if (addressAddResult.Keys.First() == 0)
                    {
                        return result;
                    }
                }
                result.Add(student.Id, "200 - Success");
            }
            catch (Exception ex)
            {
                result.Add(0, "400 - Error: " + ex.ToString());
            }
            return result;

        }


        /// <summary>
        /// Actualizeaza un studentDTO si adresa acestuia. Adresa se actualizeaza doar daca se cere actualizarea acesteia.
        /// </summary>
        /// <param name="studentDTO"></param>
        /// <returns></returns>
        public async Task<Dictionary<int, string>> UpdateStudentAsync(StudentDTO studentDTO, bool updateAddress)
        {
            var result = new Dictionary<int, string>();
            try
            {
                var existingStudent = _db.Students.FirstOrDefault(x => x.Id == studentDTO.Id);
                var existingStudentAddress = _db.Addresses.FirstOrDefault(x => x.StudentId == studentDTO.Id);

                if (studentDTO.Address.StudentId != studentDTO.Id)
                {
                    studentDTO.Address.StudentId = (int)studentDTO.Id;
                }

                if (existingStudent != null)
                {

                    existingStudent.FirstName = studentDTO.FirstName;
                    existingStudent.LastName = studentDTO.LastName;
                    existingStudent.Age = (int)studentDTO.Age;

                    _db.SaveChangesAsync();

                    if (updateAddress)
                    {
                        if (studentDTO.Address != null)
                        {

                            if (existingStudentAddress != null)
                            {
                                if (existingStudentAddress.City != studentDTO.Address.City || existingStudentAddress.Street != studentDTO.Address.Street || existingStudentAddress.StreetNo != studentDTO.Address.StreetNo)
                                {
                                    var addressUpdateResult = await _addressService.UpdateAddressAsync(existingStudentAddress.Id, studentDTO.Address);
                                    if (addressUpdateResult.Keys.First() == 0)
                                    {
                                        return addressUpdateResult;
                                    }
                                }
                            }
                            else
                            {
                                var addressAddResult = await _addressService.AddAdressAsync(studentDTO.Address);
                            }
                        }
                        else
                        {
                            if (existingStudentAddress != null)
                            {
                                await _addressService.DeleteAddressAsync(existingStudentAddress.Id);
                            }
                        }

                    }

                    result.Add((int)studentDTO.Id, "200 - Success");
                }
                else
                {
                    result.Add(0, "404 - Nu s-a gasit nici un studentDTO cu Id-ul " + studentDTO.Id);
                }
            }
            catch (Exception ex)
            {
                result.Add(0, "400 - Error: " + ex.Message);
            }
            return result;
        }



        /// <summary>
        /// Sterge un sutdent dupa id. Se poate sterge si adresa daca se cere.
        /// </summary>
        /// <param name="id">Id-ul studentului care trebuie sters.</param>
        /// <param name="deleteStudentAddress">true - sterge si adresa, false - nu sterge adresa.</param>
        /// <returns></returns>
        public async Task<Dictionary<bool, string>> DeleteStudentAsync(int id, bool deleteStudentAddress)
        {
            var result = new Dictionary<bool, string>();
            try
            {
                var student = _db.Students.FirstOrDefault(x => x.Id == id);
                if (student != null)
                {
                    var studentAddress = _db.Addresses.FirstOrDefault(y => y.StudentId == student.Id);
                    if (studentAddress != null && deleteStudentAddress == true)
                    {
                        _db.Remove(studentAddress);
                    }

                    _db.Remove(student);
                    _db.SaveChanges();
                    result.Add(true, "200 - Success");
                }
                else
                {
                    result.Add(false, "404 - Nu a fost gasit nici un studentDTO cu Id-ul " + id.ToString());
                }

            }
            catch (Exception ex)
            {
                result.Add(false, "400 - Error: " + ex.Message);
            }

            return result;
        }



        /// <summary>
        /// Returneaza adresa unui studentDTO dupa Id-ul studentului.
        /// </summary>
        /// <param name="studentId">Id-ul studentului a carui adresa dorim sa o obtinem.</param>
        /// <returns></returns>
        public async Task<AddressDTO> GetStudentAddressAsync(int studentId)
        {
            Address address = new Address();
            var student = _db.Students.Include(x => x.Address).FirstOrDefault(x => x.Id == studentId);
            if (student != null)
            {
                address = await _db.Addresses.Where(x => x.StudentId == studentId).FirstOrDefaultAsync();
            }

            AddressDTO addressDTO = new AddressDTO(address);
            return addressDTO;
        }



        /// <summary>
        /// Actualizare adresa pentru studentul cu Id-ul funrizat.
        /// </summary>
        /// <param name="studentId">Id-ul studentului a carui adresa dorim sa o modificam.</param>
        /// <param name="addressDTO">Noua adresa a studentului.</param>
        /// <returns></returns>
        public async Task<Dictionary<int, string>> UpdateStudentAddressAsync(int studentId, AddressDTO addressDTO)
        {
            var result = new Dictionary<int, string>();
            try
            {

                var existingStudent = _db.Students.FirstOrDefault(x => x.Id == studentId);
                if (existingStudent != null)
                {
                    var existingStudentAddress = _db.Addresses.FirstOrDefault(x => x.StudentId == existingStudent.Id);

                    if (existingStudentAddress != null)
                    {
                        if (existingStudentAddress.City != addressDTO.City || existingStudentAddress.Street != addressDTO.Street || existingStudentAddress.StreetNo != addressDTO.StreetNo)
                        {
                            var addressUpdateResult = await _addressService.UpdateAddressAsync((int)existingStudentAddress.Id, addressDTO);

                            if (addressUpdateResult.Keys.First() == 0)
                            {
                                return addressUpdateResult;
                            }
                        }
                    }
                    else
                    {
                        var addressAddResult = await _addressService.AddAdressAsync(addressDTO);
                        if (addressAddResult.Keys.First() == 0)
                        {
                            return addressAddResult;
                        }
                    }

                    result.Add(existingStudentAddress.Id, "200 - Success");
                }
                else
                {
                    result.Add(0, "404 - Nu a fost gasit nici un studentDTO cu Id-ul " + studentId);
                }
            }
            catch (Exception ex)
            {
                result.Add(0, "400 - Error: " + ex.Message);
            }
            return result;
        }

    }
}
