using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class RequisicoesRepository : IRequisicoesRepository
    {
        private readonly xAlmoxarifadoContext _context;
        public RequisicoesRepository(xAlmoxarifadoContext contexto)
        {
            _context = contexto;
        }
        public List<Requisicao> ObterTodasRequisicoes()
        {
            return _context.Requisicoes.Select(requisicoes => new Requisicao 
            { 
                IdReq = requisicoes.IdReq,
                IdCli = requisicoes.IdCli,
                TotalReq = requisicoes.TotalReq,
                QtdIten = requisicoes.QtdIten,
                DataReq = requisicoes.DataReq,
                Ano = requisicoes.Ano,  
                Mes = requisicoes.Mes,
                IdSec = requisicoes.IdSec,
                IdSet = requisicoes.IdSet,  
                Observacao = requisicoes.Observacao
            }).ToList();
        }
        public Requisicao ObterRequisicaoPorId(int idRequisicao)
        {
            return _context.Requisicoes.Select(requisicoes => new Requisicao
            {
                IdReq = requisicoes.IdReq,
                IdCli = requisicoes.IdCli,
                TotalReq = requisicoes.TotalReq,
                QtdIten = requisicoes.QtdIten,
                DataReq = requisicoes.DataReq,
                Ano = requisicoes.Ano,
                Mes = requisicoes.Mes,
                IdSec = requisicoes.IdSec,
                IdSet = requisicoes.IdSet,
                Observacao = requisicoes.Observacao
            }).ToList().First(requisicao => requisicao.IdReq == idRequisicao);
        }

        public Requisicao CriarRequisicao(Requisicao requisicao)
        {
            _context.Requisicoes.Add(requisicao);
            _context.SaveChanges();
            return requisicao;
        }

        public Requisicao AtualizarRequisicao(Requisicao requisicao)
        {
            var requisicaoExistente = _context.Requisicoes.FirstOrDefault(id => id.IdReq == requisicao.IdReq);
            if (requisicaoExistente != null)
            {
                requisicaoExistente.IdReq = requisicao.IdReq;
                requisicaoExistente.IdCli = requisicao.IdCli;
                requisicaoExistente.TotalReq = requisicao.TotalReq;
                requisicaoExistente.QtdIten = requisicao.QtdIten;
                requisicaoExistente.DataReq = requisicao.DataReq;
                requisicaoExistente.Ano = requisicao.Ano;
                requisicaoExistente.Mes = requisicao.Mes;
                requisicaoExistente.IdSec = requisicao.IdSec;
                requisicaoExistente.IdSet = requisicao.IdSet;
                requisicaoExistente.Observacao = requisicao.Observacao;

                _context.SaveChanges();
                return requisicaoExistente;
            }
            else
            {
                throw new InvalidOperationException("Requisicao não encontrada");
            }
        }

        public Requisicao DeletarRequisicao(Requisicao requisicao)
        {
            var requisicaoComItens = _context.Requisicoes
                .Include(r => r.ItensReqs)
                .FirstOrDefault(r => r.IdReq == requisicao.IdReq);

            if (requisicaoComItens != null)
            {
                _context.ItensReqs.RemoveRange(requisicaoComItens.ItensReqs);
                _context.Requisicoes.Remove(requisicaoComItens);
                _context.SaveChanges();
            }
            return requisicao;
        }
    }
}
