using CatalogOnline_ClassLibrary.EntityModels;
using Microsoft.EntityFrameworkCore;
using Proiect___Catalog_Online.DTOs;
using Proiect___Catalog_Online.Interfaces.Repositories;

namespace Proiect___Catalog_Online.Repositories
{
    /// <summary>
    /// Mark Repository Class
    /// </summary>
    public class MarkRepository : IMarkRepository
    {
        private readonly SchoolDbContext _db;

        /// <summary>
        /// Mark Repository Contstructor
        /// </summary>
        /// <param name="schoolDbContext"></param>
        public MarkRepository(SchoolDbContext schoolDbContext)
        {
            _db = schoolDbContext;
        }

        /// <summary>
        /// Get Studnet's Marks
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public async Task<List<MarkDTO>> GetStudentMarksAsync(int studentId)
        {
            return await _db.Marks.Where(m => m.StudentId == studentId).Select(m => new MarkDTO(m)).ToListAsync();
        }

        /// <summary>
        /// Get Student's Marks At Certain Subject
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        public async Task<List<MarkDTO>> GetStudentMarksAtSubjectAsync(int studentId, int subjectId)
        {
            return await _db.Marks.Where(m => m.StudentId == studentId && m.SubjectId == subjectId).Select(m => new MarkDTO(m)).ToListAsync();
        }

        /// <summary>
        /// Get Student's Averages For Each Subject
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public async Task<Dictionary<string, decimal>> GetStudentAveragesForEachSubjectAsync(int studentId)
        {
            var result = new Dictionary<string, decimal>();
            try
            {
                var studentSubjects = _db.Marks.Where(x => x.StudentId == studentId).Distinct();
                var subjects = await _db.Subjects.ToListAsync();
                foreach (var subject in subjects)
                {
                    var studentMarksAtCertainSubject = await _db.Marks.Where(m => m.SubjectId == subject.Id).Select(m => m.Value).ToListAsync();
                    if (studentMarksAtCertainSubject != null && studentMarksAtCertainSubject.Count > 0)
                    {
                        result.Add(subject.Name, (decimal)studentMarksAtCertainSubject.Sum() / (decimal)studentMarksAtCertainSubject.Count());
                    }
                }
            }
            catch (Exception ex)
            {
                result.Clear();
                result.Add("400 - Error: " + ex.Message, 0);
            }
            return result;
        }

        /// <summary>
        /// Delete student's marks
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public async Task<Dictionary<bool, string>> DeleteStudentMarksAsync(int studentId)
        {
            var result = new Dictionary<bool, string>();
            try
            {
                var studentMarks = await _db.Marks.Where(m => m.StudentId == studentId).ToListAsync();
                foreach (var mark in studentMarks)
                {
                    _db.Remove(mark);
                }
               await _db.SaveChangesAsync();
                result.Add(true, "200 - Success");

            }
            catch (Exception ex)
            {
                result.Add(false, "400 - Error: " + ex.Message);
            }
            return result;
        }


        /// <summary>
        /// Add Mark
        /// </summary>
        /// <param name="markDTO"></param>
        /// <returns></returns>
        public async Task<Dictionary<int, string>> AddMarkAsync(MarkDTO markDTO)
        {
            var result = new Dictionary<int, string>();
            try
            {
                var mark = new Mark()
                {
                    Date = DateTime.Now,
                    StudentId = markDTO.StudentId,
                    SubjectId = markDTO.SubjectId,
                    Value = markDTO.Value,
                };

                await _db.AddAsync(mark);
                await _db.SaveChangesAsync();

                result.Add(mark.Id, "200 - Success");
            }
            catch (Exception ex)
            {
                result.Add(0, "400 - Error: " + ex.ToString());
            }
            return result;
        }
    }
}
