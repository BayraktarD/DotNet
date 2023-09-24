using CatalogOnline_ClassLibrary.EntityModels;
using Proiect___Catalog_Online.DTOs;
using Proiect___Catalog_Online.Interfaces.Repositories;
using Proiect___Catalog_Online.Interfaces.Services;

namespace Proiect___Catalog_Online.Services
{

    /// <summary>
    /// Mark Service Class
    /// </summary>
    public class MarkService: IMarkService
    {
        private readonly IMarkRepository _markRepository;


        /// <summary>
        /// Mark Service Constructor
        /// </summary>
        /// <param name="markRepository"></param>
        public MarkService(IMarkRepository markRepository)
        {
            _markRepository = markRepository;
        }

        /// <summary>
        /// Get Studnet's Marks
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public async Task<List<MarkDTO>> GetStudentMarksAsync(int studentId)
        {
            return await _markRepository.GetStudentMarksAsync(studentId);
        }

        /// <summary>
        /// Get Student's Marks At Certain Subject
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        public async Task<List<MarkDTO>> GetStudentMarksAtSubjectAsync(int studentId, int subjectId)
        {
            return await _markRepository.GetStudentMarksAtSubjectAsync(studentId, subjectId);
        }

        /// <summary>
        /// Get Student's Averages For Each Subject
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, decimal>> GetStudentAveragesForEachSubjectAsync(int studentId)
        {
            return await _markRepository.GetStudentAveragesForEachSubjectAsync(studentId);
        }


        /// <summary>
        /// Add Mark
        /// </summary>
        /// <param name="markDTO"></param>
        /// <returns></returns>
        public async Task<Dictionary<int, string>> AddMarkAsync(MarkDTO markDTO)
        {
           return await _markRepository.AddMarkAsync(markDTO);
        }

        public async Task<Dictionary<bool, string>> DeleteStudentMarksAsync(int studentId)
        {
            return await _markRepository.DeleteStudentMarksAsync(studentId);
        }
    }
}
