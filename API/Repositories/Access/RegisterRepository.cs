
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
    public class RegisterRepository : IRegisterRepository
    {

        private readonly ToDentroContext _context;

        public RegisterRepository(ToDentroContext context)
        {
            _context = context;
        }

        public async Task<bool> SingingUp(User newUser)
        {
            // chamar validation fluent data aqui
            if (newUser == null) return false;
            else
            {
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
                return true;
            }
        }

    }
}
