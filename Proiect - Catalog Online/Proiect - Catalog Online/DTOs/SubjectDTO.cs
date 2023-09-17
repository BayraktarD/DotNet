using CatalogOnline_ClassLibrary.EntityModels;

namespace Proiect___Catalog_Online.DTOs
{
    public class SubjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public SubjectDTO()
        {

        }

        public SubjectDTO(Subject subject)
        {
            Id = subject.Id;
            Name = subject.Name;
        }
    }
}
