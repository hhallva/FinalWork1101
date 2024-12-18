using DataBaseLibrary.Data;
using DataBaseLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseLibrary.Services
{
    public class ProductService
    {
        private readonly AddDbContext _context = new();

        public async Task<List<ExamProduct>> GetProductsAsync(string subSting, int? sortMethod, decimal minCost, decimal? maxCost, string? manufacturer)
        {
            IQueryable<ExamProduct> products = _context.ExamProducts.AsNoTracking();
            Console.WriteLine($"Вызван GetProductsAsync с параметрами: subSting = '{subSting}', sortMethod = {sortMethod}, minCost = {minCost}, maxCost = {maxCost}, manufacturer = '{manufacturer}'");


            // Фильтрация по подстроке в имени
            if (!string.IsNullOrEmpty(subSting))
                products = products.Where(p => EF.Functions.Like(p.Name, $"%{subSting}%"));


            // Фильтрация по минимальной цене
            products = products.Where(p => p.Cost >= minCost);

            // Фильтрация по максимальной цене



            if (maxCost.HasValue)
                products = products.Where(p => p.Cost <= maxCost);

            if (manufacturer == "System.Windows.Controls.ComboBoxItem: Все")
                manufacturer = "";

            // Фильтрация по производителю
            else if (!string.IsNullOrEmpty(manufacturer) && manufacturer != "Все")
                products = products.Where(p => p.Manufacturer == manufacturer);


            // Сортировка
            if (sortMethod == 0)
                products = products.OrderBy(p => p.Cost);
            else if (sortMethod == 1)
                products = products.OrderByDescending(p => p.Cost);

            string query = products.ToQueryString();

            // Выполнение запроса асинхронно и возврат списка
            return await products.ToListAsync();
        }

        public async Task<List<string>> GetManufacturersAsync()
        {
            var manufacturers = await _context.ExamProducts
                .Select(p => p.Manufacturer) // Выбираем только столбец производителя
                .Distinct()                // Убираем дубликаты
                .Where(m => !string.IsNullOrEmpty(m)) // Отфильтровываем пустые строки
                .OrderBy(m => m)             // Сортируем производителей по алфавиту
                .ToListAsync();             // Асинхронно получаем список

            return manufacturers;
        }

        public async Task<int> GetProductsCountAsync()
        {
            List<ExamProduct> products = await _context.ExamProducts.ToListAsync();
            return products.Count();
        }
    }
}
