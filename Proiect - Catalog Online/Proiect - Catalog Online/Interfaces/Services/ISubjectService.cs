using Proiect___Catalog_Online.DTOs;

namespace Proiect___Catalog_Online.Interfaces.Services
{
    /// <summary>
    /// Subject Service Interface
    /// </summary>
    public interface ISubjectService
    {
        Task<Dictionary<int, string>> AddSubjectAsync(SubjectDTO subjectDTO);
        Task<Dictionary<bool, string>> UpdateSubjectTeacherAsync(int teacherId, int subjectId);
    }
}
