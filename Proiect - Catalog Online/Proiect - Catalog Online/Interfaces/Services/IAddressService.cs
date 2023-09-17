using Proiect___Catalog_Online.DTOs;

namespace Proiect___Catalog_Online.Interfaces.Services
{
    public interface IAddressService
    {
        Task<Dictionary<int, string>> UpdateAddressAsync(int addressId, AddressDTO addressDTO);
        Task<Dictionary<int, string>> AddAdressAsync(AddressDTO addressDTO);
        Task DeleteAddressAsync(int addressId);
    }
}
