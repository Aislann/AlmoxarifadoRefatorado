using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoServices.DTO;
using AutoMapper;

namespace AlmoxarifadoServices
{
    public class ItensRequisicaoService
    {
        private readonly IItensRequisicaoRepository _itensRequisicaoRepository;
        private readonly MapperConfiguration configurationMapper;

        public ItensRequisicaoService(IItensRequisicaoRepository itensRequisicaoRepository)
        {
            _itensRequisicaoRepository = itensRequisicaoRepository;
            configurationMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ItensRequisicao, ItensRequisicaoGetDTO>();
                cfg.CreateMap<ItensRequisicaoGetDTO, ItensRequisicao>();
            });
        }

        public List<ItensRequisicaoGetDTO> ObterTodosItensRequisicao()
        {
            var mapper = configurationMapper.CreateMapper();
            return mapper.Map<List<ItensRequisicaoGetDTO>>(_itensRequisicaoRepository.ObterTodosItensRequisicao());
        }

        public ItensRequisicao ObterItemRequisicaoPorNumero(int numeroItem)
        {
            return _itensRequisicaoRepository.ObterItemRequisicaoPorNumero(numeroItem);
        }

        public ItensRequisicaoGetDTO CriarItemRequisicao(ItensRequisicaoPostDTO itemRequisicao)
        {
            var itemSalvo = _itensRequisicaoRepository.CriarItemRequisicao(
                new ItensRequisicao
                {
                    NumItem = itemRequisicao.NumItem,
                    IdPro = itemRequisicao.IdPro,
                    IdReq = itemRequisicao.IdReq,
                    IdSec = itemRequisicao.IdSec,
                    QtdPro = itemRequisicao.QtdPro,
                    PreUnit = itemRequisicao.PreUnit,
                    TotalItem = itemRequisicao.QtdPro * itemRequisicao.PreUnit,
                    TotalReal = itemRequisicao.QtdPro * itemRequisicao.PreUnit
                });
            return new ItensRequisicaoGetDTO 
            { 
                NumItem = itemSalvo.NumItem,
                IdPro = itemSalvo.IdPro,
                IdReq = itemSalvo.IdReq,
                IdSec = itemSalvo.IdSec,
                QtdPro = itemSalvo.QtdPro,
                PreUnit = itemSalvo.PreUnit,
                TotalItem = itemSalvo.QtdPro * itemSalvo.PreUnit,
                TotalReal = itemSalvo.QtdPro * itemSalvo.PreUnit
            };
        }
        public ItensRequisicaoGetDTO AtualizarItemRequisicao(int numeroItem, ItensRequisicaoPutDTO novoItemRequisicao)
        {
            var itemExistente = _itensRequisicaoRepository.ObterItemRequisicaoPorNumero(numeroItem);
            if (itemExistente != null)
            {
                itemExistente.IdPro = novoItemRequisicao.IdPro;
                itemExistente.IdReq = novoItemRequisicao.IdReq;
                itemExistente.IdSec = novoItemRequisicao.IdSec;
                itemExistente.QtdPro = novoItemRequisicao.QtdPro;
                itemExistente.PreUnit = novoItemRequisicao.PreUnit;
                itemExistente.TotalItem = novoItemRequisicao.QtdPro * novoItemRequisicao.PreUnit;
                itemExistente.TotalReal = novoItemRequisicao.QtdPro * novoItemRequisicao.PreUnit;

                _itensRequisicaoRepository.AtualizarItemRequisicao(itemExistente);

                var mapper = configurationMapper.CreateMapper();
                return mapper.Map<ItensRequisicaoGetDTO>(itemExistente);
            }
            else
            {
                return null;
            }
        }


        public ItensRequisicaoGetDTO DeletarItemRequisicao(ItensRequisicao itemRequisicao)
        {
            var itemDeletado = _itensRequisicaoRepository.DeletarItemRequisicao(itemRequisicao);
            if (itemDeletado != null)
            {
                var mapper = configurationMapper.CreateMapper();
                return mapper.Map<ItensRequisicaoGetDTO>(itemDeletado);
            }
            return null;
        }
    }
}
