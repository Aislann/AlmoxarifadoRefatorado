using AlmoxarifadoDomain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlmoxarifadoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItensRequisicoesController : ControllerBase
    {
        private readonly xAlmoxarifadoContext _context;

        public ItensRequisicoesController(xAlmoxarifadoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItensRequisicao>>> GetItensReqs()
        {
            if (_context.ItensReqs == null)
            {
                return NotFound();
            }
            return await _context.ItensReqs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItensRequisicao>> GetItensReq(int id)
        {
            if (_context.ItensReqs == null)
            {
                return NotFound();
            }
            var itensReq = await _context.ItensReqs.FindAsync(id);

            if (itensReq == null)
            {
                return NotFound();
            }

            return itensReq;
        }

        [HttpPost]
        public async Task<ActionResult<ItensRequisicao>> PostItensReq(ItensRequisicao itensReq)
        {
            if (_context.ItensReqs == null)
            {
                return Problem("Entity set 'xAlmoxarifadoContext.ItensReqs'  is null.");
            }
            _context.ItensReqs.Add(itensReq);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ItensReqExists(itensReq.NumItem))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetItensReq", new { id = itensReq.NumItem }, itensReq);
        }

        private bool ItensReqExists(int id)
        {
            return (_context.ItensReqs?.Any(e => e.NumItem == id)).GetValueOrDefault();
        }
    }
}
