using API.DataAccess;
using API.Interfaces.Users.AdditionalInfo;
using API.Models.Users.AdditionalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Users.AdditionalInfo
{
    public class SkillRepository : ISkillRepository
    {
        private readonly ToDentroContext _context;
        public SkillRepository(ToDentroContext context)
        {
            _context = context;
        }

        public IEnumerable<Skill> GetSkills(string cpf)
        {
            // fluent validation
            if (cpf == null) return null;
            else
            {
                var skillList =  _context.Skills.Where(s => s.UserId == cpf).ToList();
                return skillList;
            }
        }

        public async Task<Skill> AddSkill(Skill skill)
        {
            // fluuent validation
            if (skill == null) return null;
            else
            {
                skill.Id = Guid.NewGuid();

                await _context.Skills.AddAsync(skill);
                await _context.SaveChangesAsync();
                return skill;
            }
        }

        public async Task<Skill> EditSkill(Skill skill)
        {
            // fluuent validation
            if (skill == null) return null;
            else
            {
                var _skill = await _context.Skills.FindAsync(skill.Id);
                _skill = skill;

                //_context.Entry(_skill).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return skill;
            }
        }

        public async Task<bool> DeleteSkill(Guid id)
        {
            // fluuent validation
            if (id == null) return false;
            else
            {
                var skill = await _context.Skills.FindAsync(id);
                _context.Skills.Remove(skill);
                await _context.SaveChangesAsync();
                return true;
            }
        }

    }
}
