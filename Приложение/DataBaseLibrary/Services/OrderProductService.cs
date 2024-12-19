using DataBaseLibrary.Data;
using DataBaseLibrary.Models;

namespace DataBaseLibrary.Services
{
    public class OrderProductService
    {
        private readonly AddDbContext _context = new();

        public async Task AddOrderProductAsync(ExamOrderProduct orderProduct)
        {
            _context.ExamOrderProducts.Add(orderProduct);
            await _context.SaveChangesAsync();
        }

    }
}
