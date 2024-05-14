using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AutoMapper;

namespace AlmoxarifadoServices
{
    public class ItensNotaService
    {
        private readonly IItensNotaRepository _itensNotaRepository;
        private readonly IMapper _mapper;

        public ItensNotaService(IItensNotaRepository itensNotaRepository, IMapper mapper)
        {
            _itensNotaRepository = itensNotaRepository;
            _mapper = mapper;
        }

        public List<ItensNotaDTO> ObterTodosItensNota()
        {
            var itensNota = _itensNotaRepository.ObterTodosItensNota();
            return _mapper.Map<List<ItensNotaDTO>>(itensNota);
        }

        public ItensNota ObterItemNotaPorNumero(int numeroItem)
        {
            return _itensNotaRepository.ObterItemNotaPorNumero(numeroItem);
        }

        public ItensNota CriarItemNota(ItensNota itemNota)
        {
            return _itensNotaRepository.CriarItemNota(itemNota);
        }
    }
}
