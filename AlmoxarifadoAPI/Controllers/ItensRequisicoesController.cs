using AlmoxarifadoServices;
using AlmoxarifadoServices.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AlmoxarifadoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItensRequisicoesController : ControllerBase
    {
        private readonly ItensRequisicaoService _itensRequisicaoService;

        public ItensRequisicoesController(ItensRequisicaoService itensRequisicaoService)
        {
            _itensRequisicaoService = itensRequisicaoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var itensRequisicao = _itensRequisicaoService.ObterTodosItensRequisicao();
                return Ok(itensRequisicao);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }

        }

        [HttpGet("{numero}")]
        public IActionResult GetPorID(int numero)
        {
            try
            {
                var itensRequisicao = _itensRequisicaoService.ObterItemRequisicaoPorNumero(numero);
                if (itensRequisicao == null)
                {
                    return StatusCode(404, "Nenhum Usuario Encontrado com Esse Codigo");
                }
                return Ok(itensRequisicao);
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }

        }

        [HttpPost]
        public IActionResult CriarItensRequisicao(ItensRequisicaoPostDTO itensRequisicao)
        {
            try
            {
                var itensSalvos = _itensRequisicaoService.CriarItemRequisicao(itensRequisicao);
                return Ok(itensSalvos);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpPut("{numero}")]
        public IActionResult AtualizarItemRequisicao(int numero, ItensRequisicaoPutDTO novoItemRequisicao)
        {
            try
            {
                var itemAtualizado = _itensRequisicaoService.AtualizarItemRequisicao(numero, novoItemRequisicao);
                if (itemAtualizado == null)
                {
                    return StatusCode(404, "Nenhum item encontrado com este ID");
                }
                return Ok(itemAtualizado);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpDelete("{numero}")]
        public IActionResult DeletarItemRequisicao(int numero)
        {
            try
            {
                var itemRequisicao= _itensRequisicaoService.ObterItemRequisicaoPorNumero(numero);
                if (itemRequisicao == null)
                {
                    return StatusCode(404, "Nenhum item encontrado com este ID");
                }

                var itemDeletado = _itensRequisicaoService.DeletarItemRequisicao(itemRequisicao);
                if (itemDeletado == null)
                {
                    return StatusCode(404, "Ocorreu um erro ao excluir o item");
                }

                return Ok(itemDeletado);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }
        }
    }
}
