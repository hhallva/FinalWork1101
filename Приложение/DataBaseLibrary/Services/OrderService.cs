using DataBaseLibrary.Data;
using DataBaseLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseLibrary.Services
{
    public class OrderService
    {
        private readonly AddDbContext _context = new();


        public async Task<List<ExamOrder>> GetOrdersByUserIdAsync(int id)
            => await _context.ExamOrders.Where(u => u.UserId == id).ToListAsync();


        public async Task AddOrderAsync(ExamOrder order)
        {
            _context.ExamOrders.Add(order);
            await _context.SaveChangesAsync();
        }
    }
}
