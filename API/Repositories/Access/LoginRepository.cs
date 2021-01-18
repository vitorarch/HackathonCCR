using API.DataAccess;
using API.Interfaces.Access;
using API.Models.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Access
{
    public class LoginRepository : ILoginRepository
    {

        private readonly ToDentroContext _context;

        public LoginRepository(ToDentroContext context)
        {
            _context = context;
        }

        public async Task<User> SingingIn(User user)
        {
            var _user = await _context.Users.FindAsync(user.CPF, user.Password);
            return _user;
        }

    }
}
