using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoServices.DTO;
using AutoMapper;

namespace AlmoxarifadoServices
{
    public class ItensNotaService
    {
        private readonly IItensNotaRepository _itensNotaRepository;
        private readonly MapperConfiguration configurationMapper;

        public ItensNotaService(IItensNotaRepository itensNotaRepository)
        {
            _itensNotaRepository = itensNotaRepository;
            configurationMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ItensNota, ItensNotaGetDTO>();
                cfg.CreateMap<ItensNotaGetDTO, ItensNota>();
            });
        }

        public List<ItensNotaGetDTO> ObterTodosItensNota()
        {
            var mapper = configurationMapper.CreateMapper();
            return mapper.Map<List<ItensNotaGetDTO>>(_itensNotaRepository.ObterTodosItensNota());
        }

        public ItensNota ObterItemNotaPorNumero(int numeroItem)
        {
            return _itensNotaRepository.ObterItemNotaPorNumero(numeroItem);
        }

        public ItensNotaGetDTO CriarItemNota(ItensNotaPostDTO itemNota)
        {
            var itemSalvo = _itensNotaRepository.CriarItemNota(
                new ItensNota 
                {
                    ItemNum = itemNota.ItemNum,
                    IdPro = itemNota.IdPro, 
                    IdNota = itemNota.IdNota, 
                    IdSec = itemNota.IdSec,
                    QtdPro = itemNota.QtdPro, 
                    PreUnit = itemNota.PreUnit,
                    TotalItem = itemNota.QtdPro * itemNota.PreUnit,
                    EstLin = itemNota.EstLin
                });

            return new ItensNotaGetDTO
            {
                ItemNum = itemSalvo.ItemNum,
                IdPro = itemSalvo.IdPro,
                IdNota = itemSalvo.IdNota,
                IdSec = itemSalvo.IdSec,
                QtdPro = itemSalvo.QtdPro,
                PreUnit = itemSalvo.PreUnit,
                TotalItem = itemSalvo.QtdPro * itemNota.PreUnit,
                EstLin = itemSalvo.EstLin
            };
        }
        public ItensNotaGetDTO AtualizarItemNota(int numeroItem, ItensNotaPutDTO novoItemNota)
        {
            var itemExistente = _itensNotaRepository.ObterItemNotaPorNumero(numeroItem);
            if (itemExistente != null)
            {
                itemExistente.IdPro = novoItemNota.IdPro;
                itemExistente.IdNota = novoItemNota.IdNota;
                itemExistente.IdSec = novoItemNota.IdSec;
                itemExistente.QtdPro = novoItemNota.QtdPro;
                itemExistente.PreUnit = novoItemNota.PreUnit;
                itemExistente.TotalItem = novoItemNota.QtdPro * novoItemNota.PreUnit;
                itemExistente.EstLin = novoItemNota.EstLin;

                _itensNotaRepository.AtualizarItemNota(itemExistente);

                var mapper = configurationMapper.CreateMapper();
                return mapper.Map<ItensNotaGetDTO>(itemExistente);
            }
            else
            {
                return null; 
            }
        }


        public ItensNotaGetDTO DeletarItemNota(ItensNota itemNota)
        {
            var itemDeletado = _itensNotaRepository.DeletarItemNota(itemNota);
            if (itemDeletado != null)
            {
                var mapper = configurationMapper.CreateMapper();
                return mapper.Map<ItensNotaGetDTO>(itemDeletado);
            }
            return null; 
        }

    }
}
