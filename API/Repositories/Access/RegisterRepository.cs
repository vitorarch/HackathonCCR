using API.DataAccess;
using API.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Access
{
    public class RegisterRepository
    {

        private readonly ToDentroContext _context;

        public RegisterRepository(ToDentroContext context)
        {
            _context = context;
        }


        public async Task SingingIn(User user)
        {
            await _context.Users.AddAsync(user);
        }

    }
}
