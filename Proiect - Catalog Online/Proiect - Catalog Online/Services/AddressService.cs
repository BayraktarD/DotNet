using CatalogOnline_ClassLibrary.EntityModels;
using Proiect___Catalog_Online.DTOs;
using Proiect___Catalog_Online.Interfaces.Repositories;
using Proiect___Catalog_Online.Interfaces.Services;

namespace Proiect___Catalog_Online.Services
{

    /// <summary>
    /// Address Service Class
    /// </summary>
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        /// <summary>
        /// Address Service Constructor
        /// </summary>
        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        /// <summary>
        /// Modificare Adresa
        /// </summary>
        /// <param name="addressId">Id Adresa</param>
        /// <param name="addressDTO">Adresa</param>
        /// <returns></returns>
        public async Task<Dictionary<int, string>> UpdateAddressAsync(int addressId, AddressDTO addressDTO)
        {
            return await _addressRepository.UpdateAddressAsync(addressId, addressDTO);
        }


        /// <summary>
        /// Stergere Adresa
        /// </summary>
        /// <param name="addressId">Id-ul adresei ce se vrea sterge</param>
        /// <returns></returns>
        public async Task DeleteAddressAsync(int addressId)
        {
            await _addressRepository.DeleteAddressAsync(addressId);
        }

        /// <summary>
        /// Adaugare adresa
        /// </summary>
        /// <param name="addressDTO"></param>
        /// <returns></returns>
        public async Task<Dictionary<int, string>> AddAdressAsync(AddressDTO addressDTO)
        {
          return await _addressRepository.AddAdressAsync(addressDTO);
        }
    }
}
