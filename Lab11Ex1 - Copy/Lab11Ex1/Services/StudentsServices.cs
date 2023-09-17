using Lab12Ex1.Interfaces;
using Lab12Ex1.Models;
using System.Data.Entity;

namespace Lab12Ex1.Services
{
    public class StudentsServices : IStudentsServices
    {
        private IAddressesServices _addressesServices;

        public StudentsServices(IAddressesServices addressesServices)
        {
            _addressesServices = addressesServices;
        }


        /// <summary>
        /// Returneaza lista studentilor.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Student>> GetAllStudents()
        {
            var dbContext = new SchoolDbContext();
            var students = dbContext.Students.ToList();

            foreach (var student in students)
            {
                student.Address = dbContext.Addresses.FirstOrDefault(x => x.StudentId == student.Id);
            }

            return students;
        }


        /// <summary>
        /// Returneaza studentul dupa Id.
        /// </summary>
        /// <param name="id">Id-ul studentului.</param>
        /// <returns></returns>
        public async Task<Student> GetStudentById(int id)
        {
            var dbContext = new SchoolDbContext();
            var student = dbContext.Students.SingleOrDefault(x => x.Id == id);

            student.Address = dbContext.Addresses.FirstOrDefault(x => x.StudentId == student.Id);

            return student;
        }



        /// <summary>
        /// Adauga un student nou in baza de date.
        /// </summary>
        /// <param name="student">Studentul</param>
        /// <returns></returns>
        public async Task<Dictionary<int, string>> AddStudent(Student student)
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            try
            {
                var dbContext = new SchoolDbContext();
                dbContext.Students.Add(student);
                dbContext.SaveChanges();
                if (student.Address != null)
                {
                    student.Address.StudentId = student.Id;
                    var addressAddResult = await _addressesServices.AddAdress(student.Address);
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
        /// Actualizeaza un student si adresa acestuia. Adresa se actualizeaza doar daca se cere actualizarea acesteia.
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<Dictionary<int, string>> UpdateStudent(Student student, bool updateAddress)
        {
            var result = new Dictionary<int, string>();
            try
            {
                var dbContext = new SchoolDbContext();
                var existingStudent = dbContext.Students.FirstOrDefault(x => x.Id == student.Id);
                var existingStudentAddress = dbContext.Addresses.FirstOrDefault(x => x.StudentId == student.Id);

                if(student.Address.StudentId != student.Id)
                {
                    student.Address.StudentId = student.Id;
                }

                if (existingStudent != null)
                {

                    existingStudent.FirstName = student.FirstName;
                    existingStudent.LastName = student.LastName;
                    existingStudent.Age = student.Age;

                    dbContext.SaveChangesAsync();

                    if (updateAddress)
                    {
                        if (student.Address != null)
                        {

                            if (existingStudentAddress != null)
                            {
                                if (existingStudentAddress.City != student.Address.City && existingStudentAddress.Street != student.Address.Street && existingStudentAddress.StreetNo != student.Address.StreetNo)
                                {
                                    var addressUpdateResult = await _addressesServices.UpdateAddress(existingStudentAddress.Id, student.Address, dbContext);
                                    if (addressUpdateResult.Keys.First() == 0)
                                    {
                                        return addressUpdateResult;
                                    }
                                }
                            }
                            else
                            {
                                var addressAddResult = await _addressesServices.AddAdress(student.Address, dbContext);
                            }
                        }
                        else
                        {
                            if (existingStudentAddress != null)
                            {
                                _addressesServices.DeleteAddress(existingStudentAddress.Id, dbContext);
                            }
                        }

                    }

                    result.Add(student.Id, "200 - Success");
                }
                else
                {
                    result.Add(0, "404 - Nu s-a gasit nici un student cu Id-ul " + student.Id);
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
        public async Task<Dictionary<bool, string>> DeleteStudent(int id, bool deleteStudentAddress)
        {
            var result = new Dictionary<bool, string>();
            try
            {
                var dbContext = new SchoolDbContext();
                var student = dbContext.Students.FirstOrDefault(x => x.Id == id);
                if (student != null)
                {
                    var studentAddress = dbContext.Addresses.FirstOrDefault(y => y.StudentId == student.Id);
                    if (studentAddress != null && deleteStudentAddress == true)
                    {
                        dbContext.Remove(studentAddress);
                    }

                    dbContext.Remove(student);
                    dbContext.SaveChanges();
                    result.Add(true, "200 - Success");
                }
                else
                {
                    result.Add(false, "404 - Nu a fost gasit nici un student cu Id-ul " + id.ToString());
                }

            }
            catch (Exception ex)
            {
                result.Add(false, "400 - Error: " + ex.Message);
            }

            return result;
        }



        /// <summary>
        /// Returneaza adresa unui student dupa Id-ul studentului.
        /// </summary>
        /// <param name="studentId">Id-ul studentului a carui adresa dorim sa o obtinem.</param>
        /// <returns></returns>
        public async Task<Address> GetStudentAddress(int studentId)
        {
            Address address = new Address();
            var dbContext = new SchoolDbContext();

            var student = dbContext.Students.FirstOrDefault(x => x.Id == studentId);
            if (student != null)
            {
                address = dbContext.Addresses.Where(x => x.StudentId == studentId).FirstOrDefault();
            }
            return address;
        }



        /// <summary>
        /// Actualizare adresa pentru studentul cu Id-ul funrizat.
        /// </summary>
        /// <param name="studentId">Id-ul studentului a carui adresa dorim sa o modificam.</param>
        /// <param name="address">Noua adresa a studentului.</param>
        /// <returns></returns>
        public async Task<Dictionary<int, string>> UpdateStudentAddress(int studentId, Address address)
        {
            var result = new Dictionary<int, string>();
            try
            {
                var dbContext = new SchoolDbContext();

                var existingStudent = dbContext.Students.FirstOrDefault(x => x.Id == studentId);
                if (existingStudent != null)
                {
                    var existingStudentAddress = dbContext.Addresses.FirstOrDefault(x => x.StudentId == existingStudent.Id);

                    if (existingStudentAddress != null)
                    {
                        if (existingStudentAddress.City != address.City || existingStudentAddress.Street != address.Street || existingStudentAddress.StreetNo != address.StreetNo)
                        {
                            var addressUpdateResult = await _addressesServices.UpdateAddress((int)existingStudentAddress.Id, address, dbContext);

                            if (addressUpdateResult.Keys.First() == 0)
                            {
                                return addressUpdateResult;
                            }
                        }
                    }
                    else
                    {
                        var addressAddResult = await _addressesServices.AddAdress(address, dbContext);
                        if (addressAddResult.Keys.First() == 0)
                        {
                            return addressAddResult;
                        }
                    }

                    result.Add(existingStudentAddress.Id, "200 - Success");
                }
                else
                {
                    result.Add(0, "404 - Nu a fost gasit nici un student cu Id-ul " + studentId);
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
