using CatalogOnline_ClassLibrary.EntityModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect___Catalog_Online.DTOs;
using Proiect___Catalog_Online.Interfaces.Repositories;

namespace Proiect___Catalog_Online.Repositories
{
    /// <summary>
    /// Address Repository Class
    /// </summary>
    public class AddressRepository : IAddressRepository
    {
        private readonly SchoolDbContext _db;

        /// <summary>
        /// Address Repository Constructor
        /// </summary>
        public AddressRepository(SchoolDbContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Actualizeaza o adresa in functie de Id.
        /// </summary>
        /// <param name="addressId">Id-ul adresei care se vrea modificata.</param>
        /// <param name="addressDTO">Noua adresa.</param>
        /// <returns></returns>
        public async Task<Dictionary<int, string>> UpdateAddressAsync(int addressId, AddressDTO addressDTO)
        {
            var result = new Dictionary<int, string>();
            try
            {
                var address = await _db.Addresses.FirstOrDefaultAsync(x => x.Id == addressId);
                if (address != null)
                {
                    address.City = addressDTO.City;
                    address.Street = addressDTO.Street;
                    address.StreetNo = addressDTO.StreetNo;

                    await _db.SaveChangesAsync();

                    result.Add(address.Id, "200 - Success");
                }
            }
            catch (Exception ex)
            {
                result.Add(0, "500 - Error: " + ex.Message);
            }
            return result;
        }

        /// <summary>
        /// Sterge o adresa in functie de Id.
        /// </summary>
        /// <param name="addressId">Id-ul adresei care se vrea actualizat.</param>
        public async Task DeleteAddressAsync(int addressId)
        {

            var address = await _db.Addresses.FirstOrDefaultAsync(x => x.Id == addressId);
            if (address != null)
            {
                _db.Addresses.Remove(address);
            }

            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Adaugare adresa
        /// </summary>
        /// <param name="addressDTO"></param>
        /// <returns></returns>
        public async Task<Dictionary<int, string>> AddAdressAsync(AddressDTO addressDTO)
        {
            var resutl = new Dictionary<int, string>();
            try
            {
                var address = new Address()
                {
                    City = addressDTO.City,
                    Street = addressDTO.Street,
                    StreetNo = addressDTO.StreetNo,
                    StudentId = addressDTO.StudentId != 0 ? addressDTO.StudentId : null,
                    TeacherId = addressDTO.TeacherId != 0 ? addressDTO.TeacherId : null,
                };
                await _db.Addresses.AddAsync(address);
                await _db.SaveChangesAsync();


                resutl.Add(address.Id, "200 - Success");
            }
            catch (Exception ex)
            {
                resutl.Add(0, "500 - Error: " + ex.Message);
            }

            return resutl;
        }
    }
}
