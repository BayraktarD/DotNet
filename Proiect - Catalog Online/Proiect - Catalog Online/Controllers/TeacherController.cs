using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect___Catalog_Online.DTOs;
using Proiect___Catalog_Online.Interfaces.Services;
using System.Diagnostics.Eventing.Reader;

namespace Proiect___Catalog_Online.Controllers
{
    /// <summary>
    /// TeacherController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        /// <summary>
        /// TeacherController Class
        /// </summary>
        /// <param name="teacherService"></param>
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        /// <summary>
        /// Returneaza lista profesorilor
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetTeachersAsync")]
        public async Task<IEnumerable<TeacherDTO>> GetTeachersAsync()
        {
            return await _teacherService.GetTeachersAsync();
        }

        /// <summary>
        /// Add Teacher
        /// </summary>
        /// <param name="teacherDTO"></param>
        /// <returns>int - new teacher id; string - status</returns>
        [HttpPost("AddTeacher")]
        public async Task<IActionResult> AddTeacherAsync(TeacherDTO teacherDTO)
        {
            var result = await _teacherService.AddTeacherAsync(teacherDTO);
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
        /// Delete teacher
        /// </summary>
        /// <param name="teacherId"></param>
        /// <returns></returns>
        [HttpDelete("DeleteTeacher")]
        public async Task<IActionResult> DeleteTeacherAsync([FromQuery] int teacherId)
        {
            var result = await _teacherService.DeleteTeacherAsync(teacherId);
            if (result.Keys.First() == 200)
            {
                return Ok(result);
            }
            else if (result.Keys.First() == 404)
            {
                return NotFound(result);
            }
            else
            {
                return BadRequest(result);
            }


        }

        /// <summary>
        /// Actualizare adresa profesor
        /// </summary>
        /// <param name="teacherId">id profesor</param>
        /// <param name="addressDTO">adresa</param>
        /// <returns></returns>
        [HttpPut("UpdateTeacherAddress")]
        public async Task<IActionResult> UpdateTeacherAddressAsync([FromQuery] int teacherId, AddressDTO addressDTO)
        {
            var result = await _teacherService.UpdateTeacherAddressAsync(teacherId, addressDTO);
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
        /// Promovare Profesor
        /// </summary>
        /// <param name="teacherId">id profesor</param>
        /// <returns></returns>
        [HttpPut("PromoteTeacher")]
        public async Task<IActionResult> PromoteTeacherAsync([FromQuery] int teacherId)
        {
            var result = await _teacherService.PromoteTeacherAsync(teacherId);
            if (result.Keys.First() == 200)
            {
                return Ok(result);
            }
            else if (result.Keys.First() == 404)
            {
                return NotFound(result);

            }
            else
            {
                return BadRequest(result);
            }
        }

        /// <summary>
        /// Returneaza lista notelor acordate de profesor
        /// </summary>
        /// <param name="teacherId">Id profesor</param>
        /// <returns></returns>
        [HttpGet("GetTeacherMarks")]
        public async Task<IActionResult> GetTeacherMarksAsync([FromQuery] int teacherId)
        {
            var result = await _teacherService.GetTeacherMarksAsync(teacherId);
            if (result.Keys.First() == 200)
            {
                return Ok(result);
            }
            else if (result.Keys.First() == 404)
            {
                return NotFound(result);

            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
