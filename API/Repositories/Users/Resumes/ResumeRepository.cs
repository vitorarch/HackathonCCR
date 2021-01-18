using API.DataAccess;
using API.Interfaces.Users.Resumes;
using API.Models.Users;
using API.Models.Users.Resumes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Users.Resumes
{
    public class ResumeRepository : IResumeRepository
    {

        private readonly ToDentroContext _context;

        public ResumeRepository(ToDentroContext context)
        {
            _context = context;
        }

        public async Task<Resume> GetResume(string cpf)
        {
            var resume = await _context.Resumes.FindAsync(cpf);
            return resume;
        }

        public async Task<Resume> AddResume(Resume resume)
        {
            // fluent validation
            //Creating relation between user-resume and a guid id to identifier resume
            if (resume == null) return null;
            else
            {
                resume.Id = Guid.NewGuid();

                await _context.Resumes.AddAsync(resume);
                await _context.SaveChangesAsync();
                return resume;
            }
        }

        public async Task<Resume> EditResume(Resume newResume)
        {
            //fluent validation
            if (newResume == null) return null;
            else
            {
                var resume = await _context.Resumes.FindAsync(newResume.Id); // perg oscar
                resume = newResume;
                _context.Entry(resume).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return resume;
            }
        }

    }
}
