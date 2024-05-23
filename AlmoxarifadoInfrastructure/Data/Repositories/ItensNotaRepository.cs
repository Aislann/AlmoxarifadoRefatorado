using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class ItensNotaRepository : IItensNotaRepository
    {
        private readonly xAlmoxarifadoContext _context;
        public ItensNotaRepository(xAlmoxarifadoContext contexto)
        {
            _context = contexto;
        }
        public List<ItensNota> ObterTodosItensNota()
        {
            return _context.ItensNota.Select(itemNota => new ItensNota
            {
                ItemNum = itemNota.ItemNum,
                IdPro = itemNota.IdPro,
                IdNota = itemNota.IdNota,
                IdSec = itemNota.IdSec,
                QtdPro = itemNota.QtdPro,
                PreUnit = itemNota.PreUnit,
                TotalItem = itemNota.TotalItem,
                EstLin = itemNota.EstLin
            }).ToList();
        }
        public ItensNota ObterItemNotaPorNumero(int numeroItem)
        {
            return _context.ItensNota.Select(itemNota => new ItensNota
            {
                ItemNum = itemNota.ItemNum,
                IdPro = itemNota.IdPro,
                IdNota = itemNota.IdNota,
                IdSec = itemNota.IdSec,
                QtdPro = itemNota.QtdPro,
                PreUnit = itemNota.PreUnit,
                TotalItem = itemNota.TotalItem,
                EstLin = itemNota.EstLin
            }).ToList().First(item => item.ItemNum == numeroItem);
        }

        public ItensNota CriarItemNota(ItensNota itemNota)
        {
            _context.ItensNota.Add(itemNota);
            _context.SaveChanges();
            return itemNota;
        }

        public ItensNota AtualizarItemNota(ItensNota itemNota)
        {
            var itemExistente = _context.ItensNota.FirstOrDefault(item => item.ItemNum == itemNota.ItemNum);
            if (itemExistente != null)
            {
                itemExistente.IdPro = itemNota.IdPro;
                itemExistente.IdNota = itemNota.IdNota;
                itemExistente.IdSec = itemNota.IdSec;
                itemExistente.QtdPro = itemNota.QtdPro;
                itemExistente.PreUnit = itemNota.PreUnit;
                itemExistente.TotalItem = itemNota.TotalItem;
                itemExistente.EstLin = itemNota.EstLin;

                _context.SaveChanges();
                return itemExistente;
            }
            else
            {
                throw new InvalidOperationException("Item não encontrado");
            }
        }

        public ItensNota DeletarItemNota(ItensNota itemNota)
        {
            _context.ItensNota.Remove(itemNota);
            _context.SaveChanges();
            return itemNota;
        }

    }
}
