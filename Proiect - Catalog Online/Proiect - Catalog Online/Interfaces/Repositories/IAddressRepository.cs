using Proiect___Catalog_Online.DTOs;

namespace Proiect___Catalog_Online.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        Task<Dictionary<int, string>> UpdateAddressAsync(int addressId, AddressDTO addressDTO);
        Task<Dictionary<int, string>> AddAdressAsync(AddressDTO addressDTO);
        Task DeleteAddressAsync(int addressId);
    }
}
