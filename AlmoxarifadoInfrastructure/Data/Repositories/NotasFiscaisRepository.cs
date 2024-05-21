using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class NotasFiscaisRepository : INotaFiscalRepository
    {
        private readonly xAlmoxarifadoContext _context;
        public NotasFiscaisRepository(xAlmoxarifadoContext contexto)
        {
            _context = contexto;
        }
        public List<NotaFiscal> ObterTodasNotasFiscais()
        {
            return _context.NotasFiscais.Select(notasFiscais => new NotaFiscal 
            { 
                IdNota = notasFiscais.IdNota,
                IdFor = notasFiscais.IdFor,
                IdSec = notasFiscais.IdSec,
                NumNota = notasFiscais.NumNota,
                ValorNota = notasFiscais.ValorNota,
                QtdItem = notasFiscais.QtdItem,
                Icms = notasFiscais.Icms,
                Iss = notasFiscais.Iss,
                Ano = notasFiscais.Ano,
                Mes = notasFiscais.Mes,
                DataNota = notasFiscais.DataNota,
                IdTipoNota = notasFiscais.IdTipoNota,
                ObservacaoNota = notasFiscais.ObservacaoNota,
                EmpenhoNum = notasFiscais.EmpenhoNum
            }).ToList();
        }

        public NotaFiscal ObterNotaFiscalPorId(int idNota)
        {
            return _context.NotasFiscais.Select(notasFiscais => new NotaFiscal
            {
                IdNota = notasFiscais.IdNota,
                IdFor = notasFiscais.IdFor,
                IdSec = notasFiscais.IdSec,
                NumNota = notasFiscais.NumNota,
                ValorNota = notasFiscais.ValorNota,
                QtdItem = notasFiscais.QtdItem,
                Icms = notasFiscais.Icms,
                Iss = notasFiscais.Iss, 
                Ano = notasFiscais.Ano,
                Mes = notasFiscais.Mes,
                DataNota = notasFiscais.DataNota,
                IdTipoNota = notasFiscais.IdTipoNota,
                ObservacaoNota = notasFiscais.ObservacaoNota,
                EmpenhoNum = notasFiscais.EmpenhoNum
            }).ToList().First(notaFiscal => notaFiscal.IdNota == idNota);
        }

        public NotaFiscal CriarNotaFiscal(NotaFiscal notaFiscal)
        {
            _context.NotasFiscais.Add(notaFiscal);
            _context.SaveChanges();
            return notaFiscal;
        }

        public NotaFiscal AtualizarNotaFiscal(NotaFiscal notaFiscal)
        {
            var notaExistente = _context.NotasFiscais.FirstOrDefault(i => i.IdNota == notaFiscal.IdNota);
            if (notaExistente != null)
            {
                notaExistente.IdFor = notaFiscal.IdFor;
                notaExistente.IdSec = notaFiscal.IdSec;
                notaExistente.NumNota = notaFiscal.NumNota;
                notaExistente.ValorNota = notaFiscal.ValorNota;
                notaExistente.QtdItem = notaFiscal.QtdItem;
                notaExistente.Icms = notaFiscal.Icms;
                notaExistente.Iss = notaFiscal.Iss; 
                notaExistente.Ano = notaFiscal.Ano;
                notaExistente.Mes = notaFiscal.Mes;
                notaExistente.DataNota = notaFiscal.DataNota;
                notaExistente.IdTipoNota = notaFiscal.IdTipoNota;
                notaExistente.ObservacaoNota = notaFiscal.ObservacaoNota;
                notaExistente.EmpenhoNum = notaFiscal.EmpenhoNum;

                _context.SaveChanges();
                return notaExistente;
            }
            else
            {
                throw new InvalidOperationException("Nota Fiscal não encontrado");
            }
        }

        public NotaFiscal DeletarNotaFiscal(NotaFiscal notaFiscal)
        {
            _context.NotasFiscais.Remove(notaFiscal);
            _context.SaveChanges();
            return notaFiscal;
        }
    }
}
