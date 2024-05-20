using AlmoxarifadoDomain.Models;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface IItensRequisicaoRepository
    {
        List<ItensRequisicao> ObterTodosItensRequisicao();
        ItensRequisicao ObterItemRequisicaoPorNumero(int numeroItem);
        ItensRequisicao CriarItemRequisicao(ItensRequisicao itemRequisicao);
        ItensRequisicao AtualizarItemRequisicao(ItensRequisicao itemRequisicao);
        ItensRequisicao DeletarItemRequisicao(ItensRequisicao itemRequisicao);
    }
}
