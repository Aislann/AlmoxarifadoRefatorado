using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;

namespace AlmoxarifadoServices
{
    public class EstoqueService
    {
        private readonly IEstoqueRepository _estoqueRepository;

        public EstoqueService(IEstoqueRepository estoqueRepository)
        {
            _estoqueRepository = estoqueRepository;
        }

        public void AtualizarEstoqueAoEntrarNotaFiscal(ItensNota itemNota)
        {
            var estoque = _estoqueRepository.ObterEstoquePorProduto(itemNota.IdPro);

            if (estoque != null)
            {
                estoque.QtdPro += itemNota.QtdPro ?? 0;
                _estoqueRepository.AtualizarEstoque(estoque);
            }
            else
            {
                estoque = new Estoque
                {
                    IdPro = itemNota.IdPro,
                    QtdPro = itemNota.QtdPro ?? 0
                };
                _estoqueRepository.CriarEstoque(estoque);
            }
        }

        public void AtualizarEstoqueAoSairRequisicao(ItensRequisicao itemRequisicao)
        {
            var estoque = _estoqueRepository.ObterEstoquePorProduto(itemRequisicao.IdPro);

            if (estoque != null)
            {
                VerificarQuantidadeEmEstoqueSuficiente(estoque, itemRequisicao.QtdPro);

                estoque.QtdPro -= itemRequisicao.QtdPro;
                _estoqueRepository.AtualizarEstoque(estoque);
            }
            else
            {
                throw new InvalidOperationException("Produto não encontrado no estoque");
            }
        }
        private void VerificarQuantidadeEmEstoqueSuficiente(Estoque estoque, decimal quantidadeRequisitada)
        {
            if (quantidadeRequisitada > estoque.QtdPro)
            {
                throw new InvalidOperationException("Quantidade requisitada excede a quantidade em estoque");
            }
        }

    }

}
