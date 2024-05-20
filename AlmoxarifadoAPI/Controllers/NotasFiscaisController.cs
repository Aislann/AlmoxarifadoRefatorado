using AlmoxarifadoDomain.Models;
using AlmoxarifadoServices;
using AlmoxarifadoServices.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotasFiscaisController : ControllerBase
    {
        private readonly NotaFiscalService _notaFiscalService;
        public NotasFiscaisController(NotaFiscalService notaFiscalService)
        {
            _notaFiscalService = notaFiscalService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var notaFiscal = _notaFiscalService.ObterTodasNotasFiscais();
                return Ok(notaFiscal);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetPorID(int id)
        {
            try
            {
                var notaFiscal = _notaFiscalService.ObterNotaFiscalPorId(id);
                if (notaFiscal == null)
                {
                    return StatusCode(404, "Nenhum Usuario Encontrado com Esse Codigo");
                }
                return Ok(notaFiscal);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }

        }

        [HttpPost]
        public IActionResult CriarNotaFiscal(NotaFiscalPostDTO notaFiscal)
        {
            try
            {
                var notaFiscalSalva = _notaFiscalService.CriarNotaFiscal(notaFiscal);
                return Ok(notaFiscalSalva);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarNotaFiscal(int id, NotaFiscalPutDTO notaFiscal)
        {
            try
            {
                var notaFiscalAtualizada = _notaFiscalService.AtualizarNotaFiscal(id, notaFiscal);
                if (notaFiscalAtualizada == null)
                {
                    return StatusCode(404, "Nenhum item encontrado com este ID");
                }
                return Ok(notaFiscalAtualizada);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarNotaFiscal(int id)
        {
            try
            {
                var notaFiscal = _notaFiscalService.ObterNotaFiscalPorId(id);
                if (notaFiscal == null)
                {
                    return StatusCode(404, "Nenhum item encontrado com este ID");
                }

                var notaFiscalDeletada = _notaFiscalService.DeletarNotaFiscal(notaFiscal);
                if (notaFiscalDeletada == null)
                {
                    return StatusCode(404, "Ocorreu um erro ao excluir o item");
                }
                return Ok(notaFiscal);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }
    }
}
