using AlmoxarifadoDomain.Models;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface IItensNotaRepository
    {
        List<ItensNota> ObterTodosItensNota();
        ItensNota ObterItemNotaPorNumero(int numeroItem);
        List<ItensNota> ObterItensNotaPorNota(int idNota);

        ItensNota CriarItemNota(ItensNota itemNota);
    }
}
