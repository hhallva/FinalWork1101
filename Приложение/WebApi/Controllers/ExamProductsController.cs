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
    public class ExamProductsController : ControllerBase
    {
        private readonly AddDbContext _context;

        public ExamProductsController(AddDbContext context)
        {
            _context = context;
        }

        // GET: api/ExamProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamProduct>>> GetExamProducts()
        {
            return await _context.ExamProducts.ToListAsync();
        }

        // GET: api/ExamProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExamProduct>> GetExamProduct(string id)
        {
            var examProduct = await _context.ExamProducts.FindAsync(id);

            if (examProduct == null)
            {
                return NotFound();
            }

            return examProduct;
        }

        // PUT: api/ExamProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExamProduct(string id, ExamProduct examProduct)
        {
            if (id != examProduct.ArticleNumber)
            {
                return BadRequest();
            }

            _context.Entry(examProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamProductExists(id))
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

        // POST: api/ExamProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ExamProduct>> PostExamProduct(ExamProduct examProduct)
        {
            _context.ExamProducts.Add(examProduct);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ExamProductExists(examProduct.ArticleNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetExamProduct", new { id = examProduct.ArticleNumber }, examProduct);
        }

        // DELETE: api/ExamProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamProduct(string id)
        {
            var examProduct = await _context.ExamProducts.FindAsync(id);
            if (examProduct == null)
            {
                return NotFound();
            }

            _context.ExamProducts.Remove(examProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExamProductExists(string id)
        {
            return _context.ExamProducts.Any(e => e.ArticleNumber == id);
        }
    }
}
