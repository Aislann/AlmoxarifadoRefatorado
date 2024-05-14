using AlmoxarifadoDomain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlmoxarifadoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasFiscaisController : ControllerBase
    {
        private readonly xAlmoxarifadoContext _context;

        public NotasFiscaisController(xAlmoxarifadoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotaFiscal>>> GetNotaFiscals()
        {
            if (_context.NotaFiscals == null)
            {
                return NotFound();
            }
            return await _context.NotaFiscals.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NotaFiscal>> GetNotaFiscal(int id)
        {
            if (_context.NotaFiscals == null)
            {
                return NotFound();
            }
            var notaFiscal = await _context.NotaFiscals.FindAsync(id);

            if (notaFiscal == null)
            {
                return NotFound();
            }

            return notaFiscal;
        }

        [HttpPost]
        public async Task<ActionResult<NotaFiscal>> PostNotaFiscal(NotaFiscal notaFiscal)
        {
            if (_context.NotaFiscals == null)
            {
                return Problem("Entity set 'xAlmoxarifadoContext.NotaFiscals'  is null.");
            }
            _context.NotaFiscals.Add(notaFiscal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotaFiscal", new { id = notaFiscal.IdNota }, notaFiscal);
        }

        // DELETE: api/NotasFiscais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotaFiscal(int id)
        {
            if (_context.NotaFiscals == null)
            {
                return NotFound();
            }
            var notaFiscal = await _context.NotaFiscals.FindAsync(id);
            if (notaFiscal == null)
            {
                return NotFound();
            }

            _context.NotaFiscals.Remove(notaFiscal);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
