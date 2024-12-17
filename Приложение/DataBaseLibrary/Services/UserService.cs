using DataBaseLibrary.Models;
using DataBaseLibrary.Data;
using Microsoft.EntityFrameworkCore;
using ExamWork.Classes;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataBaseLibrary.Services
{
    public class UserService
    {
        private readonly AddDbContext _context = new();

        public async Task<bool> IsUserExistAsync(string login, string password) 
            => (await _context.ExamUsers.SingleOrDefaultAsync(u => u.Login == login && u.Password == password) != null) ? true : false;

        public async Task<ExamUser> GetUserAsync(string login, string password) 
            => await _context.ExamUsers.SingleAsync(u => u.Login == login && u.Password == password);

    }
}
