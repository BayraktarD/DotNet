using CatalogOnline_ClassLibrary.EntityModels;
using Proiect___Catalog_Online.DTOs;
using Proiect___Catalog_Online.Interfaces.Repositories;
using Proiect___Catalog_Online.Interfaces.Services;

namespace Proiect___Catalog_Online.Services
{
    /// <summary>
    /// Subject Service Class
    /// </summary>
    public class SubjectService: ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        /// <summary>
        /// Subject Service Constructor
        /// </summary>
        /// <param name="subjectRepository"></param>
        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<Dictionary<int, string>> AddSubjectAsync(SubjectDTO subjectDTO)
        {
            return await _subjectRepository.AddSubjectAsync(subjectDTO);
        }

        public async Task<Dictionary<bool, string>> UpdateSubjectTeacherAsync(int teacherId, int subjectId)
        {
            return await _subjectRepository.UpdateSubjectTeacherAsync(teacherId, subjectId);

        }
    }
}
