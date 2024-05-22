using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using CsvHelper;
using System.Globalization;

namespace AlmoxarifadoServices
{
    public class EstoqueService
    {
        private readonly IEstoqueRepository _estoqueRepository;
        private readonly IProdutoRepository _produtoRepository;

        public EstoqueService(IEstoqueRepository estoqueRepository, IProdutoRepository produtoRepository)
        {
            _estoqueRepository = estoqueRepository;
            _produtoRepository = produtoRepository;
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
                var produto = _produtoRepository.ObterProdutoPorId(estoque.IdPro);

                if (produto != null)
                {
                    VerificarQuantidadeEmEstoqueSuficiente(estoque, itemRequisicao.QtdPro);

                    if (estoque.QtdPro >= itemRequisicao.QtdPro)
                    {
                        estoque.QtdPro -= itemRequisicao.QtdPro;
                        _estoqueRepository.AtualizarEstoque(estoque);

                        if (estoque.QtdPro < produto.EstoqueMin)
                        {
                            CriarArquivoLog(estoque, itemRequisicao);
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("Quantidade requisitada excede a quantidade em estoque");
                    }
                }
                else
                {
                    throw new InvalidOperationException("Produto não encontrado");
                }
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
        private void CriarArquivoLog(Estoque estoque, ItensRequisicao itemRequisicao)
        {
            string nomeArquivo = $"produtosAbaixoMinimoEm_{DateTime.Now:yyyyMMdd}_{itemRequisicao.IdReq}.csv";
            var dados = new List<string[]>
            { 
                new string[] { "Código Produto", "Código Secretaria", "Código Requisição", "Quantidade Atual", "Data do Registro" },
                new string[] { estoque.IdPro.ToString(), itemRequisicao.IdSec.ToString(), itemRequisicao.IdReq.ToString(), estoque.QtdPro.ToString(), DateTime.Now.ToString() }
            };
            using (var writer = new StreamWriter(nomeArquivo))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(dados);
            }
        }

    }

}
