using AlmoxarifadoDomain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlmoxarifadoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequisicoesController : ControllerBase
    {
        private readonly xAlmoxarifadoContext _context;

        public RequisicoesController(xAlmoxarifadoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Requisicao>>> GetRequisicaos()
        {
            if (_context.Requisicaos == null)
            {
                return NotFound();
            }
            return await _context.Requisicaos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Requisicao>> GetRequisicao(int id)
        {
            if (_context.Requisicaos == null)
            {
                return NotFound();
            }
            var requisicao = await _context.Requisicaos.FindAsync(id);

            if (requisicao == null)
            {
                return NotFound();
            }

            return requisicao;
        }

        [HttpPost]
        public async Task<ActionResult<Requisicao>> PostRequisicao(Requisicao requisicao)
        {
            if (_context.Requisicaos == null)
            {
                return Problem("Entity set 'xAlmoxarifadoContext.Requisicaos'  is null.");
            }
            _context.Requisicaos.Add(requisicao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequisicao", new { id = requisicao.IdReq }, requisicao);
        }
    }
}
