using CatalogOnline_ClassLibrary.EntityModels;
using Microsoft.EntityFrameworkCore;
using Proiect___Catalog_Online.DTOs;
using Proiect___Catalog_Online.Enums;
using Proiect___Catalog_Online.Interfaces.Repositories;
using Proiect___Catalog_Online.Interfaces.Services;
using Proiect___Catalog_Online.Services;
using System.Collections.Generic;
using System.Data;
using static Proiect___Catalog_Online.DTOs.MarkDTO;

namespace Proiect___Catalog_Online.Repositories
{
    /// <summary>
    /// Teacher Repository Class
    /// </summary>
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SchoolDbContext _db;

        private readonly IAddressRepository _addressService;
        /// <summary>
        /// Teacher Repository Constructor
        /// </summary>
        /// <param name="db"></param>
        /// <param name="addressService"></param>
        public TeacherRepository(SchoolDbContext db, IAddressRepository addressService)
        {
            _db = db;
            _addressService = addressService;
        }

        /// <summary>
        /// Returneaza lista profesorilor
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TeacherDTO>> GetTeachersAsync()
        {
            var teachers = await _db.Teachers.ToListAsync();
            foreach (var teacher in teachers)
            {
                teacher.Address = await _db.Addresses.FirstOrDefaultAsync(a => a.TeacherId == teacher.Id);
            }
            IEnumerable<TeacherDTO> teacherDTOs = teachers.Select(t => new TeacherDTO(t));

            return teacherDTOs;
        }

        /// <summary>
        /// Add Teacher
        /// </summary>
        /// <param name="teacherDTO"></param>
        /// <returns>int - new teacher id; string - status</returns>
        public async Task<Dictionary<int, string>> AddTeacherAsync(TeacherDTO teacherDTO)
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            try
            {
                var teacher = new Teacher()
                {
                    Name = teacherDTO.Name,
                    Rank = teacherDTO.Rank,
                };
                await _db.Teachers.AddAsync(teacher);
                await _db.SaveChangesAsync();

                if (teacherDTO.Address != null)
                {
                    var address = new Address()
                    {
                        City = teacherDTO.Address.City,
                        Street = teacherDTO.Address.Street,
                        StreetNo = teacherDTO.Address.StreetNo,
                        TeacherId = teacher.Id
                    };
                    await _db.Addresses.AddAsync(address);
                }

                await _db.SaveChangesAsync();

                result.Add(teacher.Id, "200 - Success");

            }
            catch (Exception ex)
            {
                result.Add(0, "400 - Error: " + ex.Message);
            }
            return result;
        }


        /// <summary>
        /// Delete teacher
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        public async Task<Dictionary<int, string>> DeleteTeacherAsync(int teacherId)
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            try
            {
                var teacher = _db.Teachers.FirstOrDefault(x => x.Id == teacherId);
                if (teacher != null)
                {
                    await RemoveTeacherAddress(teacherId);

                    var teacherSubjects = _db.Subjects.Where(s => s.TeacherId == teacherId);
                    foreach (var subject in teacherSubjects)
                    {
                        subject.TeacherId = null;
                    }


                    _db.Teachers.Remove(teacher);
                    await _db.SaveChangesAsync();
                    result.Add(200, "Success");
                }
            }
            catch (Exception ex)
            {
                result.Add(400, ex.Message);
            }
            return result;

        }

        private async Task RemoveTeacherAddress(int teacherId)
        {
            var address = await _db.Addresses.FirstOrDefaultAsync(a => a.TeacherId == teacherId);
            if (address != null)
            {
                _db.Addresses.Remove(address);
                await _db.SaveChangesAsync();
            }
        }


        /// <summary>
        /// Actualizare adresa profesor
        /// </summary>
        /// <param name="teacherId">id profesor</param>
        /// <param name="addressDTO">adresa</param>
        /// <returns></returns>
        public async Task<Dictionary<int, string>> UpdateTeacherAddressAsync(int teacherId, AddressDTO addressDTO)
        {
            var result = new Dictionary<int, string>();
            try
            {

                var existingTeacher = _db.Teachers.FirstOrDefault(x => x.Id == teacherId);
                if (existingTeacher != null)
                {
                    addressDTO.TeacherId = teacherId;
                    var existingTeacherAddress = _db.Addresses.FirstOrDefault(x => x.TeacherId == existingTeacher.Id);

                    if (existingTeacherAddress != null)
                    {
                        if (existingTeacherAddress.City != addressDTO.City || existingTeacherAddress.Street != addressDTO.Street || existingTeacherAddress.StreetNo != addressDTO.StreetNo)
                        {
                            var addressUpdateResult = await _addressService.UpdateAddressAsync((int)existingTeacherAddress.Id, addressDTO);

                            if (addressUpdateResult.Keys.First() == 0)
                            {
                                return addressUpdateResult;
                            }

                            result.Add(existingTeacherAddress.Id, "200 - Success");
                        }
                    }
                    else
                    {
                        var addressAddResult = await _addressService.AddAdressAsync(addressDTO);
                        if (addressAddResult.Keys.First() == 0)
                        {
                            return addressAddResult;
                        }
                        else
                        {
                            result.Add(addressAddResult.Keys.First(), "200 - Success");
                        }
                    }
                    return result;

                }
                else
                {
                    result.Add(0, "404 - Nu a fost gasit nici un profesor cu Id-ul " + teacherId);
                }
            }
            catch (Exception ex)
            {
                result.Add(0, "400 - Error: " + ex.Message);
            }
            return result;
        }

        /// <summary>
        /// Promovare Profesor
        /// </summary>
        /// <param name="teacherId">id profesor</param>
        /// <returns></returns>
        public async Task<Dictionary<int, string>> PromoteTeacherAsync(int teacherId)
        {
            var result = new Dictionary<int, string>();

            try
            {
                var teacher = await _db.Teachers.FirstOrDefaultAsync(t => t.Id == teacherId);
                if (teacher != null)
                {
                    if (teacher.Rank == (int)TeacherRanks.Professor)
                    {
                        result.Add(400, "This teacher is a Professor");
                    }
                    else
                    {
                        teacher.Rank -= 1;
                        await _db.SaveChangesAsync();
                        result.Add(200, "Success");
                    }
                }
                else
                {
                    result.Add(404, "Teacher Not Found!");
                }
            }
            catch (Exception ex)
            {
                result.Add(400, ex.Message);
            }

            return result;
        }


        /// <summary>
        /// Returneaza lista notelor acordate de profesor
        /// </summary>
        /// <param name="teacherId">Id profesor</param>
        /// <returns></returns>
        public async Task<Dictionary<int, List<StudentSubjectDTO>>> GetTeacherMarksAsync(int teacherId)
        {
            var result = new Dictionary<int, List<StudentSubjectDTO>>();
            List<StudentSubjectDTO> studentSubjectDTOs = new List<StudentSubjectDTO>();
            try
            {
                if (_db.Teachers.First(t => t.Id == teacherId) != null)
                {

                    var teacherSubjects = await _db.Subjects.Where(s => s.TeacherId == teacherId).ToListAsync();
                    foreach (var subject in teacherSubjects)
                    {
                        var subjectMarks = await _db.Marks.Where(m => m.SubjectId == subject.Id).ToListAsync();
                        studentSubjectDTOs.AddRange(subjectMarks.Select(sM => new StudentSubjectDTO(sM)));
                    }
                    result.Add(200, studentSubjectDTOs);
                }
                else
                {
                    result.Add(404, studentSubjectDTOs);
                }
            }
            catch 
            {
                result.Add(400, studentSubjectDTOs);
            }

            return result;
        }


    }
}
