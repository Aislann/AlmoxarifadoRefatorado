using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices
{
    public class NotaFiscalService
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;
        private readonly IMapper _mapper;

        public NotaFiscalService(INotaFiscalRepository notaFiscalRepository, IMapper mapper)
        {
            _notaFiscalRepository = notaFiscalRepository;
            _mapper = mapper;
        }

        public List<NotaFiscalDTO> ObterTodasNotasFiscais()
        {
            var notasFiscais = _notaFiscalRepository.ObterTodasNotasFiscais();
            return _mapper.Map<List<NotaFiscalDTO>>(notasFiscais);
        }

        public NotaFiscal ObterNotaFiscalPorId(int idNota)
        {
            return _notaFiscalRepository.ObterNotaFiscalPorId(idNota);
        }

        public List<NotaFiscal> ObterNotasFiscaisPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return _notaFiscalRepository.ObterNotasFiscaisPorPeriodo(dataInicio, dataFim);
        }

        public NotaFiscal CriarNotaFiscal(NotaFiscal notaFiscal)
        {
            return _notaFiscalRepository.CriarNotaFiscal(notaFiscal);
        }
    }
}
