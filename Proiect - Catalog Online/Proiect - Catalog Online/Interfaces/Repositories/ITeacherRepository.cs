using Proiect___Catalog_Online.DTOs;

namespace Proiect___Catalog_Online.Interfaces.Repositories
{
    /// <summary>
    /// Teacher Repository Interface
    /// </summary>
    public interface ITeacherRepository
    {
        Task<Dictionary<int, string>> AddTeacherAsync(TeacherDTO teacherDTO);
        Task<Dictionary<bool, string>> DeleteTeacherAsync(int teacherId, bool deleteSubjects);
    }
}
