using API.Models.Users.AdditionalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces.Users.AdditionalInfo
{
    public interface IEducationRepository
    {

        public IEnumerable<Education> GetEducations(string cpf);
        public Task<Education> AddEducation(Education education);
        public Task<Education> EditEducation(Education education);
        public Task<bool> DeleteEducation(Guid id);

    }
}
