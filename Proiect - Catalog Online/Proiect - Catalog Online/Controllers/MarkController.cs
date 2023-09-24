using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect___Catalog_Online.DTOs;
using Proiect___Catalog_Online.Interfaces.Services;
using Proiect___Catalog_Online.Services;
using System.Runtime.CompilerServices;

namespace Proiect___Catalog_Online.Controllers
{
    /// <summary>
    /// Mark Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        private readonly IMarkService _markService;
        public MarkController(IMarkService markService)
        {
            _markService= markService;
        }

        /// <summary>
        /// GEt Student's Marks
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>List of Student's Marks</returns>
        [HttpGet("GetStudentMarks")]
        public async Task<List<MarkDTO>> GetStudentMarksAsync([FromQuery] int studentId)
        {
            return await _markService.GetStudentMarksAsync(studentId);
        }

        /// <summary>
        /// Get Student's Marks For Certain Subject
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="subjectId"></param>
        /// <returns>list of student's marks</returns>
        [HttpGet("GetStudentMarksAtSubject")]
        public async Task<List<MarkDTO>> GetStudentMarksAtSubjectAsync([FromQuery] int studentId, [FromQuery] int subjectId)
        {
            return await _markService.GetStudentMarksAtSubjectAsync(studentId, subjectId);
        }


        /// <summary>
        /// Get Student's Averages For Each Subject
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>string - subject name/error; decimal - mean</returns>
        [HttpGet("GetStudentAveragesForEachSubject")]
        public async Task<Dictionary<string, decimal>> GetStudentAveragesForEachSubjectAsync(int studentId)
        {
            return await _markService.GetStudentAveragesForEachSubjectAsync(studentId);
        }

        /// <summary>
        /// Add new Mark
        /// </summary>
        /// <param name="markDTO"></param>
        /// <returns>int - new mark Id; string - status</returns>
        [HttpPost("AddMark")]
        public async Task<Dictionary<int, string>> AddMarkAsync(MarkDTO markDTO)
        {
            return await _markService.AddMarkAsync(markDTO);
        }

    }
}
