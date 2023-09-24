using Proiect___Catalog_Online.DTOs;

namespace Proiect___Catalog_Online.Interfaces.Services
{
    /// <summary>
    /// Mark Service Inteface
    /// </summary>
    public interface IMarkService
    {

        /// <summary>
        /// Get Student's Marks
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        Task<List<MarkDTO>> GetStudentMarksAsync(int studentId);

        /// <summary>
        /// Get Student's Marks For Certain Subject
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        Task<List<MarkDTO>> GetStudentMarksAtSubjectAsync(int studentId, int subjectId);

        /// <summary>
        /// Get Student's Averages For Each Subject
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        Task<Dictionary<string, decimal>> GetStudentAveragesForEachSubjectAsync(int studentId);

        /// <summary>
        /// Get Student's Averages For Each Subject
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        Task<Dictionary<int, string>> AddMarkAsync(MarkDTO markDTO);

        /// <summary>
        /// Delete student's marks
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        Task<Dictionary<bool, string>> DeleteStudentMarksAsync(int studentId);
    }
}
