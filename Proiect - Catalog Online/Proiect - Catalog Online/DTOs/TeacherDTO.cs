using CatalogOnline_ClassLibrary.EntityModels;

namespace Proiect___Catalog_Online.DTOs
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Rank { get; set; }

        public TeacherDTO()
        {

        }

        public TeacherDTO(Teacher teacher)
        {
            Id = teacher.Id;
            Name = teacher.Name;
            Address = teacher.Address;
            Rank = teacher.Rank;
        }
    }
}
