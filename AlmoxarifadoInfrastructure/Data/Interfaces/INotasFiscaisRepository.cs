using AlmoxarifadoDomain.Models;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface INotaFiscalRepository
    {
        List<NotaFiscal> ObterTodasNotasFiscais();
        NotaFiscal ObterNotaFiscalPorId(int idNota);
        List<NotaFiscal> ObterNotasFiscaisPorFornecedor(int idFornecedor);
        List<NotaFiscal> ObterNotasFiscaisPorTipo(int idTipoNota);
        List<NotaFiscal> ObterNotasFiscaisPorPeriodo(DateTime dataInicio, DateTime dataFim);

        NotaFiscal CriarNotaFiscal(NotaFiscal notaFiscal);
    }
}
