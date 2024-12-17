using DataBaseLibrary.Models;
using DataBaseLibrary.Data;
using Microsoft.EntityFrameworkCore;

namespace DataBaseLibrary.Services
{
    public class ProductService
    {
        private readonly AddDbContext _context = new();

        public async Task<List<ExamProduct>> GetProductsAsync() 
            => await _context.ExamProducts.ToListAsync();
    }
}
