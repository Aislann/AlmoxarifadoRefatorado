using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoServices.DTO;
using AutoMapper;

namespace AlmoxarifadoServices
{
    public class NotaFiscalService
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;
        private readonly MapperConfiguration configurationMapper;

        public NotaFiscalService(INotaFiscalRepository notaFiscalRepository)
        {
            _notaFiscalRepository = notaFiscalRepository;
            configurationMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NotaFiscal, NotaFiscalGetDTO>();
                cfg.CreateMap<NotaFiscalGetDTO, NotaFiscal>();
            });
        }

        public List<NotaFiscalGetDTO> ObterTodasNotasFiscais()
        {
            var mapper = configurationMapper.CreateMapper();
            return mapper.Map<List<NotaFiscalGetDTO>>(_notaFiscalRepository.ObterTodasNotasFiscais());
        }

        public NotaFiscal ObterNotaFiscalPorId(int idNota)
        {
            return _notaFiscalRepository.ObterNotaFiscalPorId(idNota);
        }

        public NotaFiscalGetDTO CriarNotaFiscal(NotaFiscalPostDTO notaFiscal)
        {
            var notaFiscalSalva = _notaFiscalRepository.CriarNotaFiscal(
                new NotaFiscal
                {
                    IdSec = notaFiscal.IdSec,
                    NumNota = notaFiscal.NumNota,
                    ValorNota = notaFiscal.ValorNota,
                    QtdItem = notaFiscal.QtdItem,
                    Icms = notaFiscal.Icms,
                    Iss = notaFiscal.Iss,
                    Ano = notaFiscal.Ano,
                    Mes = notaFiscal.Mes,
                    DataNota = notaFiscal.DataNota,
                    IdTipoNota = notaFiscal.IdTipoNota,
                    ObservacaoNota = notaFiscal.ObservacaoNota,
                    EmpenhoNum = notaFiscal.EmpenhoNum
                });
            return new NotaFiscalGetDTO
            {
                IdNota = notaFiscalSalva.IdNota,
                IdFor = notaFiscalSalva.IdFor,
                IdSec = notaFiscalSalva.IdSec,
                NumNota = notaFiscalSalva.NumNota,
                ValorNota = notaFiscalSalva.ValorNota,
                QtdItem = notaFiscalSalva.QtdItem,
                Icms = notaFiscalSalva .Icms,
                Iss = notaFiscalSalva.Iss,
                Ano = notaFiscalSalva.Ano,
                Mes = notaFiscalSalva.Mes,
                DataNota = notaFiscalSalva.DataNota,
                IdTipoNota = notaFiscalSalva.IdTipoNota,
                ObservacaoNota = notaFiscalSalva.ObservacaoNota,
                EmpenhoNum = notaFiscalSalva.EmpenhoNum
            };
        }
        public NotaFiscalGetDTO AtualizarNotaFiscal(int id, NotaFiscalPutDTO novaNotaFiscal)
        {
            var notaFiscalxistente = _notaFiscalRepository.ObterNotaFiscalPorId(id);
            if (notaFiscalxistente != null)
            {
            if (notaFiscalxistente != null)
                notaFiscalxistente.IdFor = novaNotaFiscal.IdFor;
                notaFiscalxistente.IdSec = novaNotaFiscal.IdSec;
                notaFiscalxistente.NumNota = novaNotaFiscal.NumNota;
                notaFiscalxistente.ValorNota = novaNotaFiscal.ValorNota;
                notaFiscalxistente.QtdItem = novaNotaFiscal.QtdItem;
                notaFiscalxistente.Icms = novaNotaFiscal.Icms;
                notaFiscalxistente.Iss = novaNotaFiscal.Iss;
                notaFiscalxistente.Ano = novaNotaFiscal.Ano;
                notaFiscalxistente.Mes = novaNotaFiscal.Mes;
                notaFiscalxistente.DataNota = novaNotaFiscal.DataNota;
                notaFiscalxistente.IdTipoNota = novaNotaFiscal.IdTipoNota;
                notaFiscalxistente.ObservacaoNota = novaNotaFiscal.ObservacaoNota;
                notaFiscalxistente.EmpenhoNum = novaNotaFiscal.EmpenhoNum;

                _notaFiscalRepository.AtualizarNotaFiscal(notaFiscalxistente);

                var mapper = configurationMapper.CreateMapper();
                return mapper.Map<NotaFiscalGetDTO>(notaFiscalxistente);
            }
            else
            {
                return null;
            }
        }

        public NotaFiscalGetDTO DeletarNotaFiscal(NotaFiscal notaFiscal)
        {
            var notaFiscalDeletada = _notaFiscalRepository.DeletarNotaFiscal(notaFiscal);
            if (notaFiscalDeletada != null)
            {
                var mapper = configurationMapper.CreateMapper();
                return mapper.Map<NotaFiscalGetDTO>(notaFiscalDeletada);
            }
            return null;
        }
    }
}
