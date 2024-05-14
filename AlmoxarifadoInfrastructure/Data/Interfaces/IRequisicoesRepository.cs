using AlmoxarifadoDomain.Models;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface IRequisicaoRepository
    {
        List<Requisicao> ObterTodasRequisicoes();
        Requisicao ObterRequisicaoPorId(int idRequisicao);
        List<Requisicao> ObterRequisicoesPorCliente(int idCliente);
        List<Requisicao> ObterRequisicoesPorSetor(int idSetor);
        List<Requisicao> ObterRequisicoesPorPeriodo(DateTime dataInicio, DateTime dataFim);

        Requisicao CriarRequisicao(Requisicao requisicao);
    }
}
