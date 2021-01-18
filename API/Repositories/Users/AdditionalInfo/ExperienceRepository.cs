using API.DataAccess;
using API.Interfaces.Users.AdditionalInfo;
using API.Models.Users.AdditionalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Users.AdditionalInfo
{
    public class ExperienceRepository : IExperienceRepository
    {

        private readonly ToDentroContext _context;

        public ExperienceRepository(ToDentroContext context)
        {
            _context = context;
        }

        public IEnumerable<Experience> GetExperiences(string cpf)
        {
            // fluent validation
            if (cpf == null) return null;
            else
            {
                var experienceList = _context.Experiences.Where(s => s.UserId == cpf).ToList();
                return experienceList;
            }
        }

        public async Task<Experience> AddExperience(Experience experience)
        {
            // fluuent validation
            if (experience == null) return null;
            else
            {
                experience.Id = Guid.NewGuid();

                await _context.Experiences.AddAsync(experience);
                await _context.SaveChangesAsync();
                return experience;
            }
        }

        public async Task<Experience> EditExperience(Experience experience)
        {
            // fluuent validation
            if (experience == null) return null;
            else
            {
                var _experience = await _context.Experiences.FindAsync(experience.Id);
                _experience = experience;

                _context.Entry(_experience).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return experience;
            }
        }

        public async Task<bool> DeleteExperience(Guid id)
        {
            // fluuent validation
            if (id == null) return false;
            else
            {
                var experience = await _context.Experiences.FindAsync(id);
                _context.Experiences.Remove(experience);
                await _context.SaveChangesAsync();
                return true;
            }
        }

    }
}
