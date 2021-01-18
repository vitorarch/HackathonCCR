using API.DataAccess;
using API.Interfaces.Advertisements;
using API.Models.Advertisements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Advertisements
{
    public class AdvertisementRepository : IAdvertisementRepository
    {

        private readonly ToDentroContext _context;

        public AdvertisementRepository(ToDentroContext context)
        {
            _context = context;
        }

        public IEnumerable<Advertisement> GetAdvertisements()
        {
            var advertisementList = _context.Advertisements.Where(a => a.Active.Equals(true)).ToList();
            return advertisementList;
        }

        public IEnumerable<Advertisement> GetAdvertisementsByCompany(string companyId)
        {
            // fluent validation
            if (companyId == null) return null;
            else
            {
                var advertisement = _context.Advertisements.Where(a => a.CompanyId == companyId).ToList();
                return advertisement;
            }
        }

        public async Task<Advertisement> GetAdvertisementById(string id)
        {
            // fluent validation
            if (id == null) return null;
            else
            {
                var advertisement = await _context.Advertisements.FindAsync(id);
                return advertisement;
            }
        }

        public async Task<Advertisement> AddAdvertisement(Advertisement advertisement)
        {
            // fluuent validation
            if (advertisement == null) return null;
            else
            {
                await _context.Advertisements.AddAsync(advertisement);
                await _context.SaveChangesAsync();
                return advertisement;
            }
        }

        public async Task<Advertisement> EditAdvertisement(Advertisement advertisement)
        {
            // fluuent validation
            if (advertisement == null) return null;
            else
            {
                var _advertisement = await _context.Advertisements.FindAsync(advertisement.Id);
                _advertisement = advertisement;

                _context.Entry(_advertisement).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return advertisement;
            }
        }

        public async Task<bool> DeleteAdvertisement(Guid id)
        {
            // fluuent validation
            if (id == null) return false;
            else
            {
                var advertisement = await _context.Advertisements.FindAsync(id);
                _context.Advertisements.Remove(advertisement);
                await _context.SaveChangesAsync();
                return true;
            }
        }

    }
}
