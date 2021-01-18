using API.Models.Users.Resumes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces.Users.Resumes
{
    public interface IResumeRepository
    {

        public Task<Resume> GetResume(string cpf);
        public Task<Resume> AddResume(Resume resume);
        public Task<Resume> EditResume(Resume resume);

    }
}
