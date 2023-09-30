using Proiect___Catalog_Online.DTOs;

namespace Proiect___Catalog_Online.Interfaces.Services
{
    /// <summary>
    /// Address Service Interface
    /// </summary>
    public interface IAddressService
    {
        /// <summary>
        /// Modificare Adresa
        /// </summary>
        /// <param name="addressId">Id Adresa</param>
        /// <param name="addressDTO">Adresa</param>
        /// <returns></returns>
        Task<Dictionary<int, string>> UpdateAddressAsync(int addressId, AddressDTO addressDTO);


        /// <summary>
        /// Adaugare adresa
        /// </summary>
        /// <param name="addressDTO"></param>
        /// <returns></returns>
        Task<Dictionary<int, string>> AddAdressAsync(AddressDTO addressDTO);


        /// <summary>
        /// Sterge o adresa in functie de Id.
        /// </summary>
        /// <param name="addressId">Id-ul adresei care se vrea actualizat.</param>
        Task DeleteAddressAsync(int addressId);
    }
}
