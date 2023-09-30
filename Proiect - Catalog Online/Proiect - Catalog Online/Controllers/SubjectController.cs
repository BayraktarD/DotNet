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

        /// <summary>
        /// Returneaza lista subiectelor
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetSubjects")]
        public async Task<IEnumerable<SubjectDTO>> GetSubjectsAsync()
        {
            return await _subjectService.GetSubjectsAsync();
        }

        /// <summary>
        /// Adaugare Curs
        /// </summary>
        /// <param name="subjectDTO">Curs</param>
        /// <returns></returns>
        [HttpPost("AddSubject")]
        public async Task<Dictionary<int, string>> AddSubjectAsync(SubjectDTO subjectDTO)
        {
            return await _subjectService.AddSubjectAsync(subjectDTO);
        }

        /// <summary>
        /// Atribuire profesor unui subiect
        /// </summary>
        /// <param name="teacherId">id profesor</param>
        /// <param name="subjectId">id subiect</param>
        /// <returns></returns>
        [HttpPut("AssigningSubjectToTeacher")]
        public async Task<Dictionary<bool, string>> AssigningSubjectToTeacherAsync([FromQuery] int teacherId, [FromQuery] int subjectId)
        {
            return await _subjectService.AssigningSubjectToTeacherAsync(teacherId,subjectId);
        }

        /// <summary>
        /// Stergere subiect
        /// </summary>
        /// <param name="subjectId"> Id subiect ce se vrea sters</param>
        /// <returns></returns>
        [HttpDelete("DeleteSubjectAsync")]
        public async Task<Dictionary<bool, string>> DeleteSubjectAsync([FromQuery] int subjectId)
        {
            return await _subjectService.DeleteSubjectAsync(subjectId);
        }

    }
}
