using DataBaseLibrary.Models;
using DataBaseLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace DataBaseLibrary.Services
{
    public class ProductService
    {
        private readonly AddDbContext _context = new();

        public async Task<List<ExamProduct>> GetProductsAsync(string filtersQuery)
        {
            return await _context.ExamProducts.ToListAsync();
        }

        public async Task<int> GetProductsCountAsync()
        {
            List<ExamProduct> products = await _context.ExamProducts.ToListAsync();
            return products.Count();
        }

    }
}
