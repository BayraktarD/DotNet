using CatalogOnline_ClassLibrary.EntityModels;
using Proiect___Catalog_Online.DTOs;
using Proiect___Catalog_Online.Interfaces.Repositories;
using Proiect___Catalog_Online.Interfaces.Services;

namespace Proiect___Catalog_Online.Repositories
{
    /// <summary>
    /// Teacher Repository Class
    /// </summary>
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SchoolDbContext _db;

        /// <summary>
        /// Teacher Repository Constructor
        /// </summary>
        /// <param name="db"></param>
        public TeacherRepository(SchoolDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Add Teacher
        /// </summary>
        /// <param name="teacherDTO"></param>
        /// <returns>int - new teacher id; string - status</returns>
        public async Task<Dictionary<int, string>> AddTeacherAsync(TeacherDTO teacherDTO)
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            try
            {
                var teacher = new Teacher()
                {
                    Name = teacherDTO.Name,
                    Address = teacherDTO.Address,
                    Rank = teacherDTO.Rank,
                };
                await _db.Teachers.AddAsync(teacher);
                await _db.SaveChangesAsync();

                result.Add(teacher.Id, "200 - Success");

            }
            catch (Exception ex)
            {
                result.Add(0, "400 - Error: " + ex.Message);
            }
            return result;
        }


        /// <summary>
        /// Delete teacher
        /// </summary>
        /// <param name="teacherId"></param>
        /// <param name="deleteSubjects"></param>
        /// <returns></returns>
        public async Task<Dictionary<bool, string>> DeleteTeacherAsync(int teacherId, bool deleteSubjects)
        {
            Dictionary<bool, string> result = new Dictionary<bool, string>();
            try
            {
                var teacher = _db.Teachers.FirstOrDefault(x => x.Id == teacherId);
                if (teacher != null)
                {
                    var teacherSubjects = _db.Subjects.Where(s => s.TeacherId == teacherId);
                    if (!deleteSubjects)
                    {
                        foreach (var subject in teacherSubjects)
                        {
                            subject.TeacherId = 0;
                        }
                    }
                    else
                    {
                        foreach (var subject in teacherSubjects)
                        {
                            _db.Subjects.Remove(subject);
                        }
                    }

                    _db.Teachers.Remove(teacher);
                    await _db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                result.Add(false, "400 - Error: " + ex.Message);
            }
            return result;

        }



    }
}
