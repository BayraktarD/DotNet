using Lab12Ex1.Interfaces;
using Lab12Ex1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace Lab12Ex1.Controllers
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


        /// <summary>
        /// Returneaza adresa studentului dupa Id-ul studentului.
        /// </summary>
        /// <param name="studentId">Id-ul studentului a carui adresa se va returna.</param>
        /// <returns></returns>
        [HttpGet("GetStudentAddress")]
        public async Task<IActionResult> GetStudentAddressAsync([FromQuery]int studentId)
        {
            if (studentId > 0)
            {
                var studentAddress = await _studentsService.GetStudentAddress(studentId);
                if (studentAddress.Id > 0)
                {
                    return Ok(studentAddress);
                }
                else
                {
                    return NotFound("Nu s-a gasit vreo adresa pentru id-ul de student furnizat!");
                }
            }
            else
            {
                return BadRequest("Id-ul trebuie sa fie mai mare decat 0!");
            }
        }



        /// <summary>
        /// Returenaza lista studentilor.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllStudents")]
        public async Task<IActionResult> GetStudentsAsync()
        {
            var students = await _studentsService.GetAllStudents();
            if (students != null && students.Count() > 0)
            {
                return Ok(students);
            }
            else
            {
                return NotFound("Nu s-a gasit nici un student!");
            }
        }


        /// <summary>
        /// Returneaza un student in functie de Id.
        /// </summary>
        /// <param name="id">Id-ul studentului.</param>
        /// <returns></returns>
        [HttpGet("GetStudentById")]
        public async Task<IActionResult> GetStudentByIdAsync([FromQuery]int id)
        {
            if (id > 0)
            {
                var student = await _studentsService.GetStudentById(id);
                if (student != null)
                {
                    return Ok(student);
                }
                else
                {
                    return NotFound("Nu s-a gasit nici un student cu Id-ul " + id.ToString());
                }
            }
            else
            {
                return BadRequest("Id-ul trebuie sa fie mai mare decat 0.");
            }
        }


        /// <summary>
        /// Adauga un student nou.
        /// </summary>
        /// <param name="student">Studentul</param>
        /// <returns></returns>
        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudentAsync(Student student)
        {
            var result = await _studentsService.AddStudent(student);
            if (result.Keys.First() > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }



        /// <summary>
        /// Actualizare date student.
        /// </summary>
        /// <param name="student"></param>
        /// <param name="updateAddress"></param>
        /// <returns></returns>
        [HttpPut("UpdateStudent")]
        public async Task<IActionResult> UpdateStudentAsync(Student student,[FromQuery] bool updateAddress)
        {
            if (student.Id > 0)
            {
                var result = await _studentsService.UpdateStudent(student, updateAddress);
                if (result.Keys.First() > 0)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            else
            {
                return BadRequest("Id-ul studentului nu poate fi mai mic decat 0!");
            }
        }


        /// <summary>
        /// Actualizare adresa student pe baza Id-ului de student.
        /// </summary>
        /// <param name="studentId">Id-ul studentului a carui adresa se vrea actualizata.</param>
        /// <param name="address">Adresa</param>
        /// <returns></returns>
        [HttpPut("UpdateStudentAddress")]
        public async Task<IActionResult> UpdateStudentAddressAsync([FromQuery] int studentId, Address address)
        {
            var result = await _studentsService.UpdateStudentAddress(studentId, address);
            if (result.Keys.First() > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }



        /// <summary>
        /// Stergere student pe baza Id-ului studentului.
        /// </summary>
        /// <param name="id">Id-ul studentului care se vrea sters.</param>
        /// <param name="deleteAddress">true - sterge si adresa, false - nu sterge adresa studentului</param>
        /// <returns></returns>
        [HttpDelete("DeleteStudent/id={id}&deleteAddress={deleteAddress}")]
        public async Task<IActionResult> DeleteStudentAsync(int id, bool deleteAddress)
        {
            if (id > 0)
            {

                var result = await _studentsService.DeleteStudent(id, deleteAddress);
                if (result.Keys.First() == true)
                {
                    return Ok(result);
                }
                else
                {
                    if(result.Values.First().Contains("404"))
                    {
                        return NotFound(result);
                    }
                    return BadRequest(result);

                }
            }
            else
            {
                return BadRequest("Id-ul trebuie sa fie mai mare decat 0!");
            }
        }

    }
}
