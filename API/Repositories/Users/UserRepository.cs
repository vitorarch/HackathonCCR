using API.DataAccess;
using API.Interfaces.Users;
using API.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace API.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly ToDentroContext _context;

        public UserRepository(ToDentroContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserProfile(string cpf)
        {
            var user = await _context.Users.FindAsync(cpf);
            return user;
        }

        public async Task<User> EditUserProfile(User userEdited)
        {
            var user = await _context.Users.FindAsync(userEdited.CPF);

            if (user == null) return null;
            else
            {
                user = userEdited;
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return user;
            }
        }

        public async Task<bool> DeleteUserProfile(string cpf)
        {
            var user = await _context.Users.FindAsync(cpf);

            if (user == null) return false;
            else
            {
                _context.Users.Remove(user);
                //_context.Entry(user).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
