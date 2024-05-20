using AlmoxarifadoDomain.Models;
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
        private readonly EstoqueService _estoqueService;
        public ItensRequisicoesController(ItensRequisicaoService itensRequisicaoService, EstoqueService estoqueService)
        {
            _itensRequisicaoService = itensRequisicaoService;
            _estoqueService = estoqueService;
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
                _estoqueService.AtualizarEstoqueAoSairRequisicao(new ItensRequisicao
                {
                    NumItem = itensSalvos.NumItem,
                    IdPro = itensSalvos.IdPro,
                    IdReq = itensSalvos.IdReq,
                    IdSec = itensSalvos.IdSec, 
                    QtdPro = itensSalvos.QtdPro,
                    PreUnit = itensSalvos.PreUnit,
                    TotalItem = itensSalvos.TotalItem,
                    TotalReal = itensSalvos.TotalReal
                });
                return Ok(itensSalvos);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message );
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
                _estoqueService.AtualizarEstoqueAoSairRequisicao(new ItensRequisicao
                {
                    NumItem = itemAtualizado.NumItem,
                    IdPro = itemAtualizado.IdPro,
                    IdReq = itemAtualizado.IdReq,
                    IdSec = itemAtualizado.IdSec,
                    QtdPro = itemAtualizado.QtdPro,
                    PreUnit = itemAtualizado.PreUnit,
                    TotalItem = itemAtualizado.TotalItem,
                    TotalReal = itemAtualizado.TotalReal
                });
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
