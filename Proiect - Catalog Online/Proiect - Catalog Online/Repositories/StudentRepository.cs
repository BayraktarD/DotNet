﻿using CatalogOnline_ClassLibrary.EntityModels;
using Microsoft.EntityFrameworkCore;
using Proiect___Catalog_Online.DTOs;
using Proiect___Catalog_Online.Interfaces.Repositories;
using Proiect___Catalog_Online.Interfaces.Services;
using Proiect___Catalog_Online.Utils;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace Proiect___Catalog_Online.Repositories
{
    /// <summary>
    /// Student Repository Class
    /// </summary>
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _db;
        private readonly IAddressService _addressService;
        private readonly IMarkService _markService;

        /// <summary>
        /// Student Repository Cosntructor
        /// </summary>
        /// <param name="db"></param>
        /// <param name="addressService"></param>
        /// <param name="markService"></param>
        public StudentRepository(SchoolDbContext db, IAddressService addressService, IMarkService markService)
        {
            _db = db;
            _addressService = addressService;
            _markService = markService;
        }

        /// <summary>
        /// Returneaza lista studentilor.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<StudentDTO>> GetAllStudentsAsync()
        {
            var students = await _db.Students.ToListAsync();

            foreach (var student in students)
            {
                student.Address = await _db.Addresses.FirstOrDefaultAsync(x => x.StudentId == student.Id);
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
            StudentDTO studentDTO = new StudentDTO();
            var student = await _db.Students.FirstOrDefaultAsync(x => x.Id == id);
            if (student != null)
            {

                student.Address = await _db.Addresses.FirstOrDefaultAsync(x => x.StudentId == student.Id);
                studentDTO = new StudentDTO(student);
            }

            return studentDTO;
        }



        /// <summary>
        /// Adauga un studentDTO nou in baza de date.
        /// </summary>
        /// <param name="studentDTO">Studentul</param>
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
        /// <param name="studentDTO">date actualizate student</param>
        /// <param name="updateAddress">true - actualieaza si adresa / false - nu actualiza adresa</param>
        /// <returns></returns>
        public async Task<Dictionary<int, string>> UpdateStudentAsync(StudentDTO studentDTO, bool updateAddress)
        {
            var result = new Dictionary<int, string>();
            try
            {
                var existingStudent = _db.Students.FirstOrDefault(x => x.Id == studentDTO.Id);
                var existingStudentAddress = _db.Addresses.FirstOrDefault(x => x.StudentId == studentDTO.Id);

                if (studentDTO.Address != null && studentDTO.Address.StudentId != studentDTO.Id)
                {
                    studentDTO.Address.StudentId = (int)studentDTO.Id;
                }

                if (existingStudent != null)
                {

                    existingStudent.FirstName = studentDTO.FirstName;
                    existingStudent.LastName = studentDTO.LastName;
                    existingStudent.Age = (int)studentDTO.Age;

                    await _db.SaveChangesAsync();

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

                    var deleteMarksResult = await _markService.DeleteStudentMarksAsync(student.Id);

                    _db.Remove(student);
                    await _db.SaveChangesAsync();
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
            AddressDTO addressDTO = new AddressDTO();
            var student = _db.Students.Include(x => x.Address).FirstOrDefault(x => x.Id == studentId);
            if (student != null)
            {
                var address = await _db.Addresses.FirstOrDefaultAsync(x => x.StudentId == studentId);
                if (address != null)
                    addressDTO = new AddressDTO(address);
            }

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
                            result.Add(existingStudentAddress.Id, "200 - Success");

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
                    result.Add(0, "404 - Nu a fost gasit nici un studentDTO cu Id-ul " + studentId);
                }
            }
            catch (Exception ex)
            {
                result.Add(0, "400 - Error: " + ex.Message);
            }
            return result;
        }

        /// <summary>
        /// Get Students List Ordered By Marks Average
        /// </summary>
        /// <param name="orderByAscending"></param>
        /// <returns>a ordered list of students</returns>
        public async Task<Dictionary<string, decimal>> GetStudentsListOrderedByMarksAverageAsync(bool orderByAscending)
        {
            var result = new Dictionary<string, decimal>();
            try
            {
                var students = await _db.Students.ToListAsync();

                foreach (var student in students)
                {
                    var studentMarkDTOs = await _markService.GetStudentMarksAsync(student.Id);
                    var studentMarksValues = studentMarkDTOs.Select(m => m.Value).ToList();
                    var studentMean = (decimal)studentMarksValues.Sum() / (decimal)studentMarkDTOs.Count();
                    result.Add("Id: " + student.Id + " " + student.FirstName + " " + student.LastName + ", Age: " + student.Age, studentMean);
                }
                return SortResult(orderByAscending, result);

            }
            catch (Exception ex)
            {
                result.Clear();
                result.Add("400 - Error: " + ex.Message, 0);
                return result;
            }
        }

        private OrderedDictionary<string, decimal> SortResult(bool orderByAscending, Dictionary<string, decimal> result)
        {
            OrderedDictionary<string, decimal> orderedDictionary = new OrderedDictionary<string, decimal>();
            IOrderedEnumerable<KeyValuePair<string, decimal>> sortedResult;
            if (orderByAscending)
            {
                sortedResult = result.OrderBy(x => x.Value);

            }
            else
            {
                sortedResult = result.OrderByDescending(x => x.Value);
            }
            foreach (var item in sortedResult)
            {
                orderedDictionary.Add(item.Key, item.Value);
            }
            return orderedDictionary;
        }
    }
}
