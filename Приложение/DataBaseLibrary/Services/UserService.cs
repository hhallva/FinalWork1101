using DataBaseLibrary.Data;
using DataBaseLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseLibrary.Services
{
    public class UserService
    {
        private readonly AddDbContext _context = new();

        public async Task<bool> IsUserExistAsync(string login, string password)
            => (await _context.ExamUsers.SingleOrDefaultAsync(u => u.Login == login && u.Password == password) != null);

        public async Task<ExamUser> GetUserAsync(string login, string password)
            => await _context.ExamUsers.SingleAsync(u => u.Login == login && u.Password == password);

    }
}
