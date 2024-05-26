using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly xAlmoxarifadoContext _context;

        public ProdutoRepository(xAlmoxarifadoContext context)
        {
            _context = context;
        }

        public Produto ObterProdutoPorId(int idProduto)
        {
            return _context.Produtos.FirstOrDefault(produto => produto.IdPro == idProduto);
        }
    }
}
