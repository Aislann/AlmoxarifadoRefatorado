using AlmoxarifadoDomain.Models;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface IEstoqueRepository
    {
        Estoque ObterEstoquePorProduto(int idProduto);
        void AtualizarEstoque(Estoque estoque);
        void CriarEstoque(Estoque estoque);
        List<Estoque> ObterTodosOsProdutosNoEstoque();
    }
}
