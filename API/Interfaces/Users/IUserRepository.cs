using API.Models.Company.Jobs;
using API.Models.Culture.Events;
using API.Models.Culture.Posts;
using API.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces.Users
{
    public interface IUserRepository
    {
        public Task<IEnumerable<Job>> GetJobs();

        public Task<IEnumerable<Post>> GetPosts();

        public Task<IEnumerable<Event>> GetEvents();

        public Task<User> GetUserProfile(string cpf);


    }
}
