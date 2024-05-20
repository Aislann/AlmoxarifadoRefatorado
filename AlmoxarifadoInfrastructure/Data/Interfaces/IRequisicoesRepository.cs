using AlmoxarifadoDomain.Models;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface IRequisicoesRepository
    {
        List<Requisicao> ObterTodasRequisicoes();
        Requisicao ObterRequisicaoPorId(int idRequisicao);
        Requisicao CriarRequisicao(Requisicao requisicao);
        Requisicao AtualizarRequisicao(Requisicao requisicao);
        Requisicao DeletarRequisicao(Requisicao requisicao);

    }
}
