using Lab12Ex1.Models;

namespace Lab12Ex1.Interfaces
{
    public interface IAddressesServices
    {
        Task<Dictionary<int, string>> UpdateAddress(int addressId, Address updatedAddress, SchoolDbContext dbContext = null);
        void DeleteAddress(int addressId, SchoolDbContext dbContext = null);
        Address GetAddressById(int id);
    }
}
