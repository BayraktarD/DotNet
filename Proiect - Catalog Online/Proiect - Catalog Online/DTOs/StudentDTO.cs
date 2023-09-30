using CatalogOnline_ClassLibrary.EntityModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Proiect___Catalog_Online.DTOs
{
    /// <summary>
    /// StudentDTO
    /// </summary>
    public class StudentDTO
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// FirstName
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Age
        /// </summary>
        [Range(1, 130, ErrorMessage = "Varsta trebuie sa fie mai mare decat 0")]
        [DefaultValue(1)]
        public int Age { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public virtual AddressDTO? Address { get; set; }

        /// <summary>
        /// StudentDTO
        /// </summary>
        public StudentDTO() { }

        /// <summary>
        /// StudentDTO
        /// </summary>
        /// <param name="student">student</param>
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
