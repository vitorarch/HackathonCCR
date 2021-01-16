

using API.DataAccess;
using API.Interfaces.Users;
using API.Models.Company.Jobs;
using API.Models.Culture.Events;
using API.Models.Culture.Posts;
using API.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly User _user;
        private readonly ToDentroContext _context;

        public UserRepository(ToDentroContext context)
        {
            _user = new User();
            _context = context;
        }

        public async Task<IEnumerable<Job>> GetJobs()
        {
            var jobs = await _context.Jobs.ToListAsync();
            return jobs;
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = await _context.Posts.ToListAsync();
            return posts;
        }

        public async Task<IEnumerable<Event>> GetEvents()
        {
            var events = await _context.Events.ToListAsync();
            return events;
        }

        public async Task<User> GetUserProfile(string cpf)
        {
            var user = await _context.Users.FindAsync(cpf);
            return user;
        }

    }
}
