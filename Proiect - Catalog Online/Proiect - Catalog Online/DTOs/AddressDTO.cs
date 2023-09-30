using CatalogOnline_ClassLibrary.EntityModels;

namespace Proiect___Catalog_Online.DTOs
{
    /// <summary>
    /// AddressDTO
    /// </summary>
    public class AddressDTO
    {
       
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// StudentId
        /// </summary>
        public int? StudentId { get; set; }

        /// <summary>
        /// TeacherId
        /// </summary>
        public int? TeacherId { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Street
        /// </summary>
        public string Street { get; set; }


        /// <summary>
        /// StreetNo
        /// </summary>
        public string StreetNo { get; set; }

        /// <summary>
        /// AddressDTO Cosntructor
        /// </summary>
        public AddressDTO() { }

        /// <summary>
        /// AddressDTO Cosntructor
        /// </summary>
        /// <param name="address">address</param>
        public AddressDTO(Address address)
        {
            Id = address.Id;
            StudentId = address.StudentId;
            TeacherId = address.TeacherId;
            City = address.City;
            Street = address.Street;
            StreetNo = address.StreetNo;
        }
    }
}
