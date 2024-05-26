using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoServices.DTO;
using AutoMapper;

namespace AlmoxarifadoServices
{
    public class RequisicaoService
    {
        private readonly IRequisicoesRepository _requisicaoRepository;
        private readonly MapperConfiguration configurationMapper;

        public RequisicaoService(IRequisicoesRepository requisicaoRepository)
        {
            _requisicaoRepository = requisicaoRepository;
            configurationMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Requisicao, RequisicaoGetDTO>();
                cfg.CreateMap<RequisicaoGetDTO, Requisicao>();
            });
        }

        public List<RequisicaoGetDTO> ObterTodasRequisicoes()
        {
            var mapper = configurationMapper.CreateMapper();
            return mapper.Map<List<RequisicaoGetDTO>>(_requisicaoRepository.ObterTodasRequisicoes());
        }

        public Requisicao ObterRequisicaoPorId(int idRequisicao)
        {
            return _requisicaoRepository.ObterRequisicaoPorId(idRequisicao);
        }

        public RequisicaoGetDTO CriarRequisicao(RequisicaoPostDTO requisicao)
        {
            var requisicaoSalva = _requisicaoRepository.CriarRequisicao(
                new Requisicao
                {
                    IdCli = requisicao.IdCli,
                    TotalReq = requisicao.TotalReq,
                    QtdIten = requisicao.QtdIten,
                    DataReq = requisicao.DataReq,
                    Ano = requisicao.Ano,
                    Mes = requisicao.Mes,
                    IdSec = requisicao.IdSec,
                    IdSet = requisicao.IdSet,
                    Observacao = requisicao.Observacao
                });
            return new RequisicaoGetDTO 
            { 
                IdReq = requisicaoSalva.IdReq,
                IdCli = requisicaoSalva.IdCli,
                TotalReq = requisicaoSalva.TotalReq,
                QtdIten = requisicaoSalva .QtdIten,
                DataReq = requisicaoSalva.DataReq,
                Ano = requisicaoSalva.Ano,
                Mes = requisicaoSalva.Mes,
                IdSec = requisicaoSalva.IdSec,
                IdSet = requisicaoSalva.IdSet,
                Observacao = requisicaoSalva.Observacao
            };
        }
        public RequisicaoGetDTO AtualizarRequisicao(int id, RequisicaoPutDTO novaRequisicao)
        {
            var requisicaoExistente = _requisicaoRepository.ObterRequisicaoPorId(id);
            if (requisicaoExistente != null)
            {
                requisicaoExistente.TotalReq = novaRequisicao.TotalReq;
                requisicaoExistente.QtdIten = novaRequisicao.QtdIten;
                requisicaoExistente.DataReq = novaRequisicao.DataReq;
                requisicaoExistente.Ano = novaRequisicao.Ano;
                requisicaoExistente.Mes = novaRequisicao.Mes;
                requisicaoExistente.IdSec = novaRequisicao.IdSec;
                requisicaoExistente.IdSet = novaRequisicao.IdSet;
                requisicaoExistente.Observacao = novaRequisicao.Observacao;

                _requisicaoRepository.AtualizarRequisicao(requisicaoExistente);

                var mapper = configurationMapper.CreateMapper();
                return mapper.Map<RequisicaoGetDTO>(requisicaoExistente);
            }
            else
            {
                return null;
            }
        }

        public RequisicaoGetDTO DeletarItemRequisicao(Requisicao requisicao)
        {

            var requisicaoDeletada = _requisicaoRepository.DeletarRequisicao(requisicao);
            if (requisicaoDeletada != null)
            {
                var mapper = configurationMapper.CreateMapper();
                return mapper.Map<RequisicaoGetDTO>(requisicaoDeletada);
            }
            return null;
        }
    }
}
