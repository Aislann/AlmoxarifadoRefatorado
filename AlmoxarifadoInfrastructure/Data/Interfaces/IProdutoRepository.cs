using AlmoxarifadoDomain.Models;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface IProdutoRepository
    {
        Produto ObterProdutoPorId(int idProduto);
    }
}
