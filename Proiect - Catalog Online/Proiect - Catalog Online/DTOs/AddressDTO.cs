using CatalogOnline_ClassLibrary.EntityModels;

namespace Proiect___Catalog_Online.DTOs
{
    public class AddressDTO
    {
       
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNo { get; set; }

        public AddressDTO() { }
        public AddressDTO(Address address)
        {
            Id = address.Id;
            StudentId = address.StudentId;
            City = address.City;
            Street = address.Street;
            StreetNo = address.StreetNo;
        }
    }
}
