using DataBaseLibrary.Data;
using DataBaseLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseLibrary.Services
{
    public class PickupPointService
    {
        private readonly AddDbContext _context = new();

        public async Task<List<ExamPickupPoint>> GetPicupPointsAcync()
            => await _context.ExamPickupPoints.ToListAsync();

    }
}
