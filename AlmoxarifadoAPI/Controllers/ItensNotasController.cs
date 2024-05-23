using Microsoft.AspNetCore.Mvc;
using AlmoxarifadoServices;
using AlmoxarifadoServices.DTO;
using AlmoxarifadoDomain.Models;

namespace AlmoxarifadoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItensNotasController : ControllerBase
    {
        private readonly ItensNotaService _itensNotaService;
        private readonly EstoqueService _estoqueService;
        public ItensNotasController(ItensNotaService itensNotaService, EstoqueService estoqueService)
        {
            _itensNotaService = itensNotaService;
            _estoqueService = estoqueService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var itens = _itensNotaService.ObterTodosItensNota();
                return Ok(itens);
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
                var itens = _itensNotaService.ObterItemNotaPorNumero(numero);
                if (itens == null)
                {
                    return StatusCode(404, "Nenhum Usuario Encontrado com Esse Codigo");
                }
                return Ok(itens);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro ao acessar os dados. Por favor, tente novamente mais tarde.");
            }

        }

        [HttpPost]
        public IActionResult CriarItensNota(ItensNotaPostDTO itens)
        {
            try
            {
                var itemSalvo = _itensNotaService.CriarItemNota(itens);
                _estoqueService.AtualizarEstoqueAoEntrarNotaFiscal(new ItensNota
                {
                    ItemNum = itemSalvo.ItemNum,
                    IdPro = itemSalvo.IdPro,
                    IdNota = itemSalvo.IdNota,
                    IdSec = itemSalvo.IdSec,
                    QtdPro = itemSalvo.QtdPro,
                    PreUnit = itemSalvo.PreUnit,
                    TotalItem = itemSalvo.TotalItem,
                    EstLin = itemSalvo.EstLin
                });
                return Ok(itemSalvo);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{numero}")]
        public IActionResult AtualizarItemNota(int numero, ItensNotaPutDTO novoItem)
        {
            try
            {
                var itemAtualizado = _itensNotaService.AtualizarItemNota(numero, novoItem);
                if (itemAtualizado == null)
                {
                    return StatusCode(404, "Nenhum item encontrado com este ID");
                }
                _estoqueService.AtualizarEstoqueAoEntrarNotaFiscal(new ItensNota
                {
                    ItemNum = itemAtualizado.ItemNum,
                    IdPro = itemAtualizado.IdPro,
                    IdNota = itemAtualizado.IdNota,
                    IdSec = itemAtualizado.IdSec,
                    QtdPro = itemAtualizado.QtdPro,
                    PreUnit = itemAtualizado.PreUnit,
                    TotalItem = itemAtualizado.TotalItem,
                    EstLin = itemAtualizado.EstLin
                });
                return Ok(itemAtualizado);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message) ;
            }
        }


        [HttpDelete("{numero}")]
        public IActionResult DeletarItemNota(int numero)
        {
            try
            {
                var itemNota = _itensNotaService.ObterItemNotaPorNumero(numero);
                if (itemNota == null)
                {
                    return StatusCode(404, "Nenhum item encontrado com este ID");
                }

                var itemDeletado = _itensNotaService.DeletarItemNota(itemNota);
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
