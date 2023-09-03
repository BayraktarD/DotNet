using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab11Ex1.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Addresses")]
        public int? AddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public int Age { get; set; }

        public Address? Address { get; set; }

    }
}
