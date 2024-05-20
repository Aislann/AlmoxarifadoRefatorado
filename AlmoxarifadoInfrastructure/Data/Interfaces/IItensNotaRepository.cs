using AlmoxarifadoDomain.Models;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface IItensNotaRepository
    {
        List<ItensNota> ObterTodosItensNota();
        ItensNota ObterItemNotaPorNumero(int numeroItem);
        ItensNota CriarItemNota(ItensNota itemNota);
        ItensNota AtualizarItemNota(ItensNota itemNota);
        ItensNota DeletarItemNota(ItensNota itemNota);
    }
}
