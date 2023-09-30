using Proiect___Catalog_Online.DTOs;

namespace Proiect___Catalog_Online.Interfaces.Repositories
{
    /// <summary>
    /// Address Repository Interface
    /// </summary>
    public interface IAddressRepository
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
        /// Stergere Adresa
        /// </summary>
        /// <param name="addressId">Id-ul adresei ce se vrea sterge</param>
        /// <returns></returns>
        Task DeleteAddressAsync(int addressId);
    }
}
