using CatalogOnline_ClassLibrary.EntityModels;

namespace Proiect___Catalog_Online.DTOs
{
    /// <summary>
    /// SujectDTO
    /// </summary>
    public class SubjectDTO
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// TeacherId
        /// </summary>
        public int? TeacherId { get; set; }

        /// <summary>
        /// StudentDTO
        /// </summary>
        public SubjectDTO()
        {

        }

        /// <summary>
        /// SubjectDTO
        /// </summary>
        /// <param name="subject">subject</param>
        public SubjectDTO(Subject subject)
        {
            Id = subject.Id;
            Name = subject.Name;
            TeacherId = subject.TeacherId;
        }
    }
}
