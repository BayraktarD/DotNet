using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect___Catalog_Online.DTOs;
using Proiect___Catalog_Online.Interfaces.Services;

namespace Proiect___Catalog_Online.Controllers
{
    /// <summary>
    /// Subject Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {

        private ISubjectService _subjectService;

        /// <summary>
        /// Subject Controller Constructor
        /// </summary>
        /// <param name="subjectService"></param>
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }


        [HttpPost("AddSubject")]
        public async Task<Dictionary<int, string>> AddSubjectAsync(SubjectDTO subjectDTO)
        {
            return await _subjectService.AddSubjectAsync(subjectDTO);
        }

        [HttpPut("UpdateSubjectTeacherAsync")]
        public async Task<Dictionary<bool, string>> UpdateSubjectTeacherAsync([FromQuery] int teacherId, [FromQuery] int subjectId)
        {
            return await _subjectService.UpdateSubjectTeacherAsync(teacherId,subjectId);
        }
    }
}
