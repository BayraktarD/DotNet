using CatalogOnline_ClassLibrary.EntityModels;
using Microsoft.EntityFrameworkCore;
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
        /// Returneaza lista subiectelor
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SubjectDTO>> GetSubjectsAsync()
        {
            var subjects = await _db.Subjects.ToListAsync();
          
            IEnumerable<SubjectDTO> subjectDTOs = subjects.Select(s => new SubjectDTO(s));

            return subjectDTOs;
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

        /// <summary>
        /// Stergere Curs si profesor
        /// </summary>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        public async Task<Dictionary<bool,string>> DeleteSubjectAsync(int subjectId)
        {
            Dictionary<bool, string> result = new Dictionary<bool, string>();
            try
            {
                var subject = await _db.Subjects.FirstOrDefaultAsync(s=>s.Id== subjectId);
                if(subject != null)
                {
                    var subjectMarks = await _db.Marks.Where(m=>m.SubjectId==subjectId).ToListAsync();
                    if (subjectMarks.Count > 0)
                    {
                        _db.Marks.RemoveRange(subjectMarks);
                    }

                    _db.Subjects.Remove(subject);
                    await _db.SaveChangesAsync();
                }
                result.Add(true, "200 - Success");
            }
            catch (Exception ex)
            {
                result.Add(false,ex.Message);
            }

            return result;
        }


        /// <summary>
        /// Atribuire profesor unui subiect
        /// </summary>
        /// <param name="teacherId">id profesor</param>
        /// <param name="subjectId">id subiect</param>
        /// <returns></returns>
        public async Task<Dictionary<bool, string>> AssigningSubjectToTeacherAsync(int teacherId, int subjectId)
        {
            Dictionary<bool, string> result = new Dictionary<bool, string>();
            try
            {
                if (await _db.Teachers.FirstOrDefaultAsync(t => t.Id == teacherId) != null)
                {
                    var subject = await _db.Subjects.FirstOrDefaultAsync(s => s.Id == subjectId);
                    if (subject != null)
                    {
                        subject.TeacherId = teacherId;
                        await _db.SaveChangesAsync();
                        result.Add(true, "200 - Success!");
                        return result;
                    }
                    else
                    {
                        result.Add(false, "404 - Subject Not Found!");
                    }
                }
                else
                {
                    result.Add(false, "404 - Teacher Not Found!");
                }
            }
            catch (Exception ex)
            {
                result.Add(false, ex.Message);
            }
            return result;
        }
    }
}
