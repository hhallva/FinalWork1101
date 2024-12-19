using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataBaseLibrary.Data;
using DataBaseLibrary.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamPickupPointsController : ControllerBase
    {
        private readonly AddDbContext _context;

        public ExamPickupPointsController(AddDbContext context)
        {
            _context = context;
        }

        // GET: api/ExamPickupPoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamPickupPoint>>> GetExamPickupPoints()
        {
            return await _context.ExamPickupPoints.ToListAsync();
        }

        // GET: api/ExamPickupPoints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExamPickupPoint>> GetExamPickupPoint(int id)
        {
            var examPickupPoint = await _context.ExamPickupPoints.FindAsync(id);

            if (examPickupPoint == null)
            {
                return NotFound();
            }

            return examPickupPoint;
        }

        // PUT: api/ExamPickupPoints/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExamPickupPoint(int id, ExamPickupPoint examPickupPoint)
        {
            if (id != examPickupPoint.PickupPointIndex)
            {
                return BadRequest();
            }

            _context.Entry(examPickupPoint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamPickupPointExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ExamPickupPoints
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExamPickupPoint>> PostExamPickupPoint(ExamPickupPoint examPickupPoint)
        {
            _context.ExamPickupPoints.Add(examPickupPoint);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ExamPickupPointExists(examPickupPoint.PickupPointIndex))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetExamPickupPoint", new { id = examPickupPoint.PickupPointIndex }, examPickupPoint);
        }

        // DELETE: api/ExamPickupPoints/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamPickupPoint(int id)
        {
            var examPickupPoint = await _context.ExamPickupPoints.FindAsync(id);
            if (examPickupPoint == null)
            {
                return NotFound();
            }

            _context.ExamPickupPoints.Remove(examPickupPoint);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExamPickupPointExists(int id)
        {
            return _context.ExamPickupPoints.Any(e => e.PickupPointIndex == id);
        }
    }
}
