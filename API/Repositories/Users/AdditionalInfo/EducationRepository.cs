using API.DataAccess;
using API.Interfaces.Users.AdditionalInfo;
using API.Models.Users.AdditionalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Users.AdditionalInfo
{
    public class EducationRepository : IEducationRepository
    {

        private readonly ToDentroContext _context;

        public EducationRepository(ToDentroContext context)
        {
            _context = context;
        }

        public IEnumerable<Education> GetEducations(string cpf)
        {
            // fluent validation
            if (cpf == null) return null;
            else
            {
                var educationList = _context.Education.Where(s => s.UserId == cpf).ToList();
                return educationList;
            }
        }

        public async Task<Education> AddEducation(Education education)
        {
            // fluent validation
            if (education == null) return null;
            else
            {
                education.Id = Guid.NewGuid();

                await _context.Education.AddAsync(education);
                await _context.SaveChangesAsync();
                return education;
            }
        }

        public async Task<Education> EditEducation(Education education)
        {
            // fluent validation
            if (education == null) return null;
            else
            {
                var _education = await _context.Education.FindAsync(education.Id);
                _education = education;

                _context.Entry(_education).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return education;
            }
        }

        public async Task<bool> DeleteEducation(Guid id)
        {
            // fluent validation
            if (id == null) return false;
            else
            {
                var education = await _context.Education.FindAsync(id);
                _context.Education.Remove(education);
                await _context.SaveChangesAsync();
                return true;
            }
        }

    }
}
