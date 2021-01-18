using API.DataAccess;
using API.Interfaces.Companies.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Companies.Jobs
{
    public class JobRepository : IJobRepository
    {

        private readonly ToDentroContext _context;

        public JobRepository(ToDentroContext context)
        {
            _context = context;
        }

        public async Task<Models.Companies.Jobs.Job> AddJob(Models.Companies.Jobs.Job job)
        {
            if (job == null) return null;
            else
            {
                job.JobId = Guid.NewGuid();

                await _context.Jobs.AddAsync(job);
                await _context.SaveChangesAsync();
                return job;
            }
        }

        public async Task<bool> DeleteJob(Guid id)
        {
            if (id == null) return false;
            else
            {
                var job = await _context.Jobs.FindAsync(id);
                _context.Jobs.Remove(job);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<Models.Companies.Jobs.Job> EditJob(Models.Companies.Jobs.Job job)
        {
            if (job == null) return null;
            else
            {
                var _job = await _context.Jobs.FindAsync(job.JobId);
                _job = job;
                _context.Entry(_job).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return _job;
            }
        }

        public IEnumerable<Models.Companies.Jobs.Job> GetAllJobs()
        {
            var jobList = _context.Jobs.ToList();
            return jobList;
        }

        public async Task<Models.Companies.Jobs.Job> GetJob(Guid id)
        {
            var job = await _context.Jobs.FindAsync(id);
            return job;
        }

        public IEnumerable<Models.Companies.Jobs.Job> GetJobsByCompany(string id)
        {
            var jobList = _context.Jobs.Where(j => j.CompanyId == id).ToList();
            return jobList;
        }
    }
}
