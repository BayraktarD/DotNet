using System.ComponentModel.DataAnnotations;

namespace Lab11Ex1.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string City  { get; set; }
        public string Street { get; set; }
        public string StreetNo { get; set; }

    }
}
