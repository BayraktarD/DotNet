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

        /// <summary>
        /// Returneaza lista subiectelor
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SubjectDTO>> GetSubjectsAsync()
        {
            return await _subjectRepository.GetSubjectsAsync();
        }

        /// <summary>
        /// Adaugare Curs
        /// </summary>
        /// <param name="subjectDTO">Curs</param>
        /// <returns></returns>
        public async Task<Dictionary<int, string>> AddSubjectAsync(SubjectDTO subjectDTO)
        {
            return await _subjectRepository.AddSubjectAsync(subjectDTO);
        }

        /// <summary>
        /// Stergere subiect
        /// </summary>
        /// <param name="subjectId"> Id subiect ce se vrea sters</param>
        /// <returns></returns>
        public async Task<Dictionary<bool, string>> DeleteSubjectAsync(int subjectId)
        {
            return await _subjectRepository.DeleteSubjectAsync(subjectId);
        }


        /// <summary>
        /// Atribuire profesor unui subiect
        /// </summary>
        /// <param name="teacherId">id profesor</param>
        /// <param name="subjectId">id subiect</param>
        /// <returns></returns>
        public async Task<Dictionary<bool, string>> AssigningSubjectToTeacherAsync(int teacherId, int subjectId)
        {
            return await _subjectRepository.AssigningSubjectToTeacherAsync(teacherId, subjectId);
        }
    }
}
