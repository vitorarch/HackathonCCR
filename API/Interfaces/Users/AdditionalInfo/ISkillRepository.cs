using API.Models.Users.AdditionalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces.Users.AdditionalInfo
{
    public interface ISkillRepository
    {

        public IEnumerable<Skill> GetSkills(string cpf);
        public Task<Skill> AddSkill(Skill skill);
        public Task<Skill> EditSkill(Skill skill);
        public Task<bool> DeleteSkill(Guid id);


    }
}
