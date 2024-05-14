using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AutoMapper;

namespace AlmoxarifadoServices
{
    public class ItensRequisicaoService
    {
        private readonly IItensRequisicaoRepository _itensRequisicaoRepository;
        private readonly IMapper _mapper;

        public ItensRequisicaoService(IItensRequisicaoRepository itensRequisicaoRepository, IMapper mapper)
        {
            _itensRequisicaoRepository = itensRequisicaoRepository;
            _mapper = mapper;
        }

        public List<ItensRequisicaoDTO> ObterTodosItensRequisicao()
        {
            var itensRequisicao = _itensRequisicaoRepository.ObterTodosItensRequisicao();
            return _mapper.Map<List<ItensRequisicaoDTO>>(itensRequisicao);
        }

        public ItensRequisicao ObterItemRequisicaoPorNumero(int numeroItem)
        {
            return _itensRequisicaoRepository.ObterItemRequisicaoPorNumero(numeroItem);
        }

        public ItensRequisicao CriarItemRequisicao(ItensRequisicao itemRequisicao)
        {
            return _itensRequisicaoRepository.CriarItemRequisicao(itemRequisicao);
        }
    }
}
