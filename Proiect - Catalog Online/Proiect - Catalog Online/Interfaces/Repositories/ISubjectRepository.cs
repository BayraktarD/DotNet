using Proiect___Catalog_Online.DTOs;

namespace Proiect___Catalog_Online.Interfaces.Repositories
{
    /// <summary>
    /// Subject Repository Intercace
    /// </summary>
    public interface ISubjectRepository
    {
        /// <summary>
        /// Returneaza lista subiectelor
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SubjectDTO>> GetSubjectsAsync();

        /// <summary>
        /// Adaugare Curs
        /// </summary>
        /// <param name="subjectDTO">Curs</param>
        /// <returns></returns>
        Task<Dictionary<int, string>> AddSubjectAsync(SubjectDTO subjectDTO);

        /// <summary>
        /// Stergere subiect
        /// </summary>
        /// <param name="subjectId"> Id subiect ce se vrea sters</param>
        /// <returns></returns>
        Task<Dictionary<bool, string>> DeleteSubjectAsync(int subjectId);

        /// <summary>
        /// Atribuire profesor unui subiect
        /// </summary>
        /// <param name="teacherId">id profesor</param>
        /// <param name="subjectId">id subiect</param>
        /// <returns></returns>
        Task<Dictionary<bool, string>> AssigningSubjectToTeacherAsync(int teacherId, int subjectId);
    }
}
