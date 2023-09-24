using CatalogOnline_ClassLibrary.EntityModels;
using Proiect___Catalog_Online.DTOs;
using Proiect___Catalog_Online.Interfaces.Repositories;
using Proiect___Catalog_Online.Interfaces.Services;
using Proiect___Catalog_Online.Services;

namespace Proiect___Catalog_Online.Repositories
{
    /// <summary>
    /// Subject Repository Class
    /// </summary>
    public class SubjectRepository: ISubjectRepository
    {
        private readonly SchoolDbContext _db;

        /// <summary>
        /// Constructor Subject Repository
        /// </summary>
        /// <param name="db"></param>
        public SubjectRepository(SchoolDbContext db)
        {
            _db = db;
        }


        /// <summary>
        /// Adaugare curs
        /// </summary>
        /// <param name="subjectDTO">Curs</param>
        /// <returns></returns>
        public async Task<Dictionary<int, string>> AddSubjectAsync(SubjectDTO subjectDTO)
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            try
            {
                var subject = new Subject()
                {
                   Name = subjectDTO.Name,
                   TeacherId = subjectDTO.TeacherId,
                };

                await _db.Subjects.AddAsync(subject);
                await _db.SaveChangesAsync();
                
                result.Add(subject.Id, "200 - Success");
            }
            catch (Exception ex)
            {
                result.Add(0, "400 - Error: " + ex.ToString());
            }
            return result;
        }

        public async Task<Dictionary<bool, string>> UpdateSubjectTeacherAsync(int teacherId, int subjectId)
        {
            Dictionary<bool, string> result = new Dictionary<bool, string>();

            try
            {
                var subject = _db.Subjects.FirstOrDefault(s => s.Id == subjectId);
                if (subject == null)
                {
                    subject.TeacherId = teacherId;
                    await _db.SaveChangesAsync();
                    result.Add(true, "200 - Success");

                }
                else
                {
                    result.Add(false, "404 - Subject Not Found");
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
