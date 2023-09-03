using Lab11Ex1.Interfaces;
using Lab11Ex1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace Lab11Ex1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentsServices _studentsService;

        public StudentsController(IStudentsServices studentsService)
        {
            _studentsService = studentsService;
        }

        [HttpGet("GetStudentAddress/{studentId}")]
        public Address GetStudentAddress(int studentId)
        {
            return _studentsService.GetStudentAddress(studentId);
        }


        [HttpGet("GetAllStudents")]
        public List<Student> GetStudents()
        {
            return _studentsService.GetAllStudents();
        }

        [HttpGet("GetStudentById/{id}")]
        public Student GetStudentById(int id)
        {
            return _studentsService.GetStudentById(id);
        }

        [HttpPost("AddStudent")]
        public void AddStudent(Student student)
        {
            _studentsService.AddStudent(student);
        }

        [HttpPut("UpdateStudent")]
        public void UpdateStudent(Student student)
        {
            _studentsService.UpdateStudent(student);
        }

        [HttpPut("UpdateStudentAddress/{studentId}")]
        public void UpdateStudentAddress(int studentId, Address address)
        {
            _studentsService.UpdateStudentAddress(studentId,address);
        }

        [HttpDelete("DeleteStudent/id={id}&deleteAddress={deleteAddress}")]
        public void DeleteStudent(int id,bool deleteAddress)
        {
            _studentsService.DeleteStudent(id,deleteAddress);
        }
       
    }
}
