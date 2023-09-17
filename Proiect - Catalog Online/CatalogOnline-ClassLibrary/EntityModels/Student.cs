using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogOnline_ClassLibrary.EntityModels
{
    public class Student
    {

        /// <summary>
        /// Id-ul studentului
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Prenumele studentului
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Numele studentului
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Varsta studentului (nu poate fi mai mica decat 0 si mai mare decat 130)
        /// </summary>
        [Range(1, 130, ErrorMessage = "Varsta trebuie sa fie mai mare decat 0")]
        [DefaultValue(1)]
        public int Age { get; set; }

        public virtual Address? Address { get; set; }
    }
}
