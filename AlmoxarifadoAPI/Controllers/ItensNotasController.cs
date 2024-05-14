using AlmoxarifadoDomain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlmoxarifadoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItensNotasController : ControllerBase
    {
        private readonly xAlmoxarifadoContext _context;

        public ItensNotasController(xAlmoxarifadoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItensNota>>> GetItensNota()
        {
            if (_context.ItensNota == null)
            {
                return NotFound();
            }
            return await _context.ItensNota.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItensNota>> GetItensNotum(int id)
        {
            if (_context.ItensNota == null)
            {
                return NotFound();
            }
            var itensNotum = await _context.ItensNota.FindAsync(id);

            if (itensNotum == null)
            {
                return NotFound();
            }

            return itensNotum;
        }

        [HttpPost]
        public async Task<ActionResult<ItensNota>> PostItensNotum(ItensNota itensNotum)
        {
            if (_context.ItensNota == null)
            {
                return Problem("Entity set 'xAlmoxarifadoContext.ItensNota'  is null.");
            }
            _context.ItensNota.Add(itensNotum);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ItensNotumExists(itensNotum.ItemNum))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetItensNotum", new { id = itensNotum.ItemNum }, itensNotum);
        }

        private bool ItensNotumExists(int id)
        {
            return (_context.ItensNota?.Any(e => e.ItemNum == id)).GetValueOrDefault();
        }
    }
}
