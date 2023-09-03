using Lab11Ex1.Interfaces;
using Lab11Ex1.Models;

namespace Lab11Ex1.Services
{
    public class AddressesServices : IAddressesServices
    {
        public void UpdateAddress(int addressId, Address updatedAddress, SchoolDbContext dbContext = null)
        {
            dbContext = GetDbContext(dbContext);
            var address = dbContext.Addresses.FirstOrDefault(x => x.Id == addressId);
            address.City = updatedAddress.City;
            address.Street = updatedAddress.Street;
            address.StreetNo = updatedAddress.StreetNo;

            dbContext.SaveChanges();
        }

        private static SchoolDbContext GetDbContext(SchoolDbContext dbContext)
        {
            if (dbContext == null)
            {
                dbContext = new SchoolDbContext();
            }

            return dbContext;
        }

        public void DeleteAddress(int addressId, SchoolDbContext dbContext = null)
        {
            dbContext = GetDbContext(dbContext);

           var address =  dbContext.Addresses.FirstOrDefault(x => x.Id == addressId);

            dbContext.Addresses.Remove(address);

            dbContext.SaveChanges();
        }

        public Address GetAddressById(int id)
        {
            var dbContext = new SchoolDbContext();
            return dbContext.Addresses.FirstOrDefault(x => x.Id == id);
        }
    }
}
