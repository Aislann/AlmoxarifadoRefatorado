using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AutoMapper;

namespace AlmoxarifadoServices
{
    public class RequisicaoService
    {
        private readonly IRequisicaoRepository _requisicaoRepository;
        private readonly IMapper _mapper;

        public RequisicaoService(IRequisicaoRepository requisicaoRepository, IMapper mapper)
        {
            _requisicaoRepository = requisicaoRepository;
            _mapper = mapper;
        }

        public List<RequisicaoDTO> ObterTodasRequisicoes()
        {
            var requisicoes = _requisicaoRepository.ObterTodasRequisicoes();
            return _mapper.Map<List<RequisicaoDTO>>(requisicoes);
        }

        public Requisicao ObterRequisicaoPorId(int idRequisicao)
        {
            return _requisicaoRepository.ObterRequisicaoPorId(idRequisicao);
        }

        public List<Requisicao> ObterRequisicoesPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return _requisicaoRepository.ObterRequisicoesPorPeriodo(dataInicio, dataFim);
        }

        public Requisicao CriarRequisicao(Requisicao requisicao)
        {
            return _requisicaoRepository.CriarRequisicao(requisicao);
        }
    }
}
