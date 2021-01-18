using API.DataAccess;
using API.Interfaces.Companies;
using API.Models.Companies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Companies
{
    public class CompanyRepository : ICompanyRepository
    {

        private readonly ToDentroContext _context;

        public CompanyRepository(ToDentroContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteCompanyProfile(string id)
        {
            var user = await _context.Companies.FindAsync(id);

            if (user == null) return false;
            else
            {
                _context.Companies.Remove(user);
                //_context.Entry(user).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<Company> EditCompanyProfile(Company companyEdited)
        {
                var company = await _context.Companies.FindAsync(companyEdited.Id);

                if (company == null) return null;
                else
                {
                    company = companyEdited;
                    _context.Entry(company).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return company;
                }
            }

        public async Task<Company> GetCompanyProfile(string id)
        {
            var company = await _context.Companies.FindAsync(id);
            return company;
        }
    }
}
