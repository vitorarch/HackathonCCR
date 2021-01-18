using API.Models.Users.AdditionalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces.Users.AdditionalInfo
{
    public interface IExperienceRepository
    {

        public IEnumerable<Experience> GetExperiences(string cpf);
        public Task<Experience> AddExperience(Experience experience);
        public Task<Experience> EditExperience(Experience experience);
        public Task<bool> DeleteExperience(Guid id);

    }
}
