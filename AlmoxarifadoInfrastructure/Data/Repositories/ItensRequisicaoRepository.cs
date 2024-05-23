using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class ItensRequisicaoRepository : IItensRequisicaoRepository
    {
        private readonly xAlmoxarifadoContext _context;
        public ItensRequisicaoRepository(xAlmoxarifadoContext contexto)
        {
            _context = contexto;
        }

        public List<ItensRequisicao> ObterTodosItensRequisicao()
        {
            return _context.ItensReqs.Select(itens => new ItensRequisicao
            {
                NumItem = itens.NumItem,
                IdPro = itens.IdPro,
                IdReq = itens.IdReq,
                IdSec = itens.IdSec,
                QtdPro = itens.QtdPro,
                PreUnit = itens.PreUnit,
                TotalItem = itens.TotalItem,
                TotalReal = itens.TotalReal,
            }).ToList();
        }

        public ItensRequisicao ObterItemRequisicaoPorNumero(int numeroItem)
        {
            return _context.ItensReqs.Select(itens => new ItensRequisicao
            {
                NumItem = itens.NumItem,
                IdPro = itens.IdPro,
                IdReq = itens.IdReq,
                IdSec = itens.IdSec,
                QtdPro = itens.QtdPro,
                PreUnit = itens.PreUnit,
                TotalItem = itens.TotalItem,
                TotalReal = itens.TotalReal,
            }).ToList().First(item => item?.NumItem == numeroItem);
        }

        public ItensRequisicao CriarItemRequisicao(ItensRequisicao itemRequisicao)
        {
            _context.ItensReqs.Add(itemRequisicao);
            _context.SaveChanges();
            return itemRequisicao;
        }

        public ItensRequisicao AtualizarItemRequisicao(ItensRequisicao itemRequisicao)
        {
            var itemRequisicaoExistente = _context.ItensReqs.FirstOrDefault(item => item.NumItem == itemRequisicao.NumItem);
            if (itemRequisicaoExistente != null)
            {
                itemRequisicaoExistente.IdPro = itemRequisicao.IdPro;
                itemRequisicaoExistente.IdReq = itemRequisicao.IdReq;
                itemRequisicaoExistente.IdSec = itemRequisicao.IdSec;
                itemRequisicaoExistente.QtdPro = itemRequisicao.QtdPro;
                itemRequisicaoExistente.PreUnit = itemRequisicao.PreUnit;
                itemRequisicaoExistente.TotalItem = itemRequisicao.TotalItem;
                itemRequisicaoExistente.TotalReal = itemRequisicao.TotalReal;

                _context.SaveChanges();
                return itemRequisicaoExistente;
            }
            else
            {
                throw new InvalidOperationException("Item da Requisição não encontrado");
            }
        }

        public ItensRequisicao DeletarItemRequisicao(ItensRequisicao itemRequisicao)
        {
            _context.ItensReqs.Remove(itemRequisicao);
            _context.SaveChanges();
            return itemRequisicao;
        }
    }
}
