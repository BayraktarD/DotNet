using CatalogOnline_ClassLibrary.EntityModels;
using Proiect___Catalog_Online.DTOs;
using Proiect___Catalog_Online.Interfaces.Repositories;
using Proiect___Catalog_Online.Interfaces.Services;

namespace Proiect___Catalog_Online.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<Dictionary<int, string>> UpdateAddressAsync(int addressId, AddressDTO addressDTO)
        {
            return await _addressRepository.UpdateAddressAsync(addressId, addressDTO);
        }

        public async Task DeleteAddressAsync(int addressId)
        {
            await _addressRepository.DeleteAddressAsync(addressId);
        }

        public async Task<Dictionary<int, string>> AddAdressAsync(AddressDTO addressDTO)
        {
          return await _addressRepository.AddAdressAsync(addressDTO);
        }
    }
}
