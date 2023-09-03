using Lab11Ex1.Interfaces;
using Lab11Ex1.Models;

namespace Lab11Ex1.Services
{
    public class StudentsServices : IStudentsServices
    {
        private IAddressesServices _addressesServices;

        public StudentsServices(IAddressesServices addressesServices)
        {
            _addressesServices = addressesServices;
        }
        public List<Student> GetAllStudents()
        {
            var dbContext = new SchoolDbContext();
            var students = dbContext.Students.ToList();

            foreach (var student in students)
            {
                if (student.AddressId != 0)
                {
                    student.Address = dbContext.Addresses.Where(x => x.Id == student.AddressId).FirstOrDefault();
                }
            }

            return students;
        }

        public Student GetStudentById(int id)
        {
            var dbContext = new SchoolDbContext();
            var student = dbContext.Students.SingleOrDefault(x => x.Id == id);
            if (student.AddressId != 0)
            {
                student.Address = dbContext.Addresses.FirstOrDefault(x => x.Id == student.AddressId);
            }
            return student;
        }

        public void AddStudent(Student student)
        {
            var dbContext = new SchoolDbContext();
            dbContext.Students.Add(student);
            dbContext.SaveChanges();

        }

        public void UpdateStudent(Student student)
        {
            var dbContext = new SchoolDbContext();
            var existingStudent = dbContext.Students.FirstOrDefault(x => x.Id == student.Id);
            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.Age = student.Age;
            existingStudent.Address = dbContext.Addresses.FirstOrDefault(x => x.Id == existingStudent.AddressId);
            if (existingStudent.AddressId != null)
            {
                if (student.Address != null)
                {
                    if (existingStudent.Address.City != student.Address.City || existingStudent.Address.Street != student.Address.Street || existingStudent.Address.StreetNo != student.Address.StreetNo)
                        _addressesServices.UpdateAddress((int)existingStudent.AddressId, student.Address, dbContext);
                }
                else
                {
                    existingStudent.AddressId = null;
                    dbContext.Addresses.Remove(existingStudent.Address);
                }
            }
            else
            {
                existingStudent.Address = student.Address;
            }

            dbContext.SaveChanges();
        }

        public void DeleteStudent(int id, bool deleteStudentAddress)
        {
            var dbContext = new SchoolDbContext();
            var student = dbContext.Students.FirstOrDefault(x => x.Id == id);
            if (student != null)
            {
                var studentAddress = dbContext.Addresses.FirstOrDefault(y => y.Id == student.AddressId);
                if (studentAddress != null && deleteStudentAddress == true)
                {
                    dbContext.Remove(studentAddress);
                }

                dbContext.Remove(student);
            }
            dbContext.SaveChanges();
        }

        public Address GetStudentAddress(int studentId)
        {
            Address address = new Address();
            var dbContext = new SchoolDbContext();

            var student = dbContext.Students.FirstOrDefault(x => x.Id == studentId);
            if (student != null)
            {
                address = dbContext.Addresses.Where(x => x.Id == student.AddressId).FirstOrDefault();
            }
            return address;
        }

        public void UpdateStudentAddress(int studentId, Address address)
        {
            var dbContext = new SchoolDbContext();

            var existingStudent = dbContext.Students.FirstOrDefault(x => x.Id == studentId);

            existingStudent.Address = dbContext.Addresses.FirstOrDefault(x => x.Id == existingStudent.AddressId);

            if (existingStudent.AddressId != null)
            {
                if (existingStudent.Address.City != address.City || existingStudent.Address.Street != address.Street || existingStudent.Address.StreetNo != address.StreetNo)
                    _addressesServices.UpdateAddress((int)existingStudent.AddressId, address, dbContext);
            }
            else
            {
                existingStudent.Address = address;
            }
        }

    }
}
