using CatalogOnline_ClassLibrary.EntityModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Proiect___Catalog_Online.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Range(1, 130, ErrorMessage = "Varsta trebuie sa fie mai mare decat 0")]
        [DefaultValue(1)]
        public int Age { get; set; }
        public virtual AddressDTO? Address { get; set; }

        public StudentDTO() { }
        public StudentDTO(Student student)
        {
            Id = student.Id;
            FirstName = student.FirstName;
            LastName = student.LastName;
            Age = student.Age;

            if(student.Address != null)
            {
                Address = new AddressDTO(student.Address);
            }
        }
    }
}
