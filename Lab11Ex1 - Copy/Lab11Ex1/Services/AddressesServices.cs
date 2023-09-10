using Lab12Ex1.Interfaces;
using Lab12Ex1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Lab12Ex1.Services
{
    public class AddressesServices : IAddressesServices
    {

        /// <summary>
        /// Actualizeaza o adresa in functie de Id.
        /// </summary>
        /// <param name="addressId">Id-ul adresei care se vrea modificata.</param>
        /// <param name="updatedAddress">Noua adresa.</param>
        /// <param name="dbContext">DbContext - se transmite doar daca a fost initializat in metoda caller.</param>
        /// <returns></returns>
        public async Task<Dictionary<int, string>> UpdateAddress(int addressId, Address updatedAddress, SchoolDbContext dbContext = null)
        {
            var result = new Dictionary<int, string>();
            try
            {
                dbContext = GetDbContext(dbContext);
                var address = dbContext.Addresses.FirstOrDefault(x => x.Id == addressId);
                address.City = updatedAddress.City;
                address.Street = updatedAddress.Street;
                address.StreetNo = updatedAddress.StreetNo;

                dbContext.SaveChanges();

                result.Add(address.Id, "200 - Success");
            }
            catch (Exception ex)
            {
                result.Add(0, "500 - Error: " + ex.Message);
            }
            return result;
        }


        /// <summary>
        /// Verifica daca este null dbContext-ul. Daca este null, initializeaza dbContext-ul.
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        private static SchoolDbContext GetDbContext(SchoolDbContext dbContext)
        {
            if (dbContext == null)
            {
                dbContext = new SchoolDbContext();
            }

            return dbContext;
        }


        /// <summary>
        /// Sterge o adresa in functie de Id.
        /// </summary>
        /// <param name="addressId">Id-ul adresei care se vrea actualizat.</param>
        /// <param name="dbContext"></param>
        public void DeleteAddress(int addressId, SchoolDbContext dbContext = null)
        {
            dbContext = GetDbContext(dbContext);

            var address = dbContext.Addresses.FirstOrDefault(x => x.Id == addressId);

            dbContext.Addresses.Remove(address);

            dbContext.SaveChanges();
        }



        /// <summary>
        /// Returneaza adresa dupa Id-ul adresei.
        /// </summary>
        /// <param name="id">Id-ul adresei care se vrea returnata.</param>
        /// <returns></returns>
        public Address GetAddressById(int id)
        {
            var dbContext = new SchoolDbContext();
            return dbContext.Addresses.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Dictionary<int, string>> AddAdress(Address address, SchoolDbContext dbContext = null)
        {
            var resutl = new Dictionary<int, string>();
            try
            {
                dbContext = GetDbContext(dbContext);

                dbContext.Addresses.AddAsync(address);
                dbContext.SaveChangesAsync();

                
                resutl.Add(address.Id, "200 - Success");
            }
            catch (Exception ex)
            {
                resutl.Add(0, "500 - Error: "+ex.Message);
            }

            return resutl;
        }
    }
}
