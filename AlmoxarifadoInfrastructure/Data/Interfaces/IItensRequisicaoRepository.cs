using AlmoxarifadoDomain.Models;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface IItensRequisicaoRepository
    {
        List<ItensRequisicao> ObterTodosItensRequisicao();
        ItensRequisicao ObterItemRequisicaoPorNumero(int numeroItem);
        List<ItensRequisicao> ObterItensRequisicaoPorRequisicao(int idRequisicao);

        ItensRequisicao CriarItemRequisicao(ItensRequisicao itemRequisicao);
    }
}
