using Lab11Ex1.Models;

namespace Lab11Ex1.Interfaces
{
    public interface IAddressesServices
    {
        void UpdateAddress(int addressId, Address updatedAddress, SchoolDbContext dbContext = null);
        void DeleteAddress(int addressId, SchoolDbContext dbContext = null);
        Address GetAddressById(int id);
    }
}
