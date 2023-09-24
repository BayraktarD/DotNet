using Proiect___Catalog_Online.DTOs;

namespace Proiect___Catalog_Online.Interfaces.Repositories
{
    /// <summary>
    /// Subject Repository Intercace
    /// </summary>
    public interface ISubjectRepository
    {
        /// <summary>
        /// Adaugare Curs
        /// </summary>
        /// <param name="subjectDTO">Curs</param>
        /// <returns></returns>
        Task<Dictionary<int, string>> AddSubjectAsync(SubjectDTO subjectDTO);
        Task<Dictionary<bool, string>> UpdateSubjectTeacherAsync(int teacherId, int subjectId);
    }
}
