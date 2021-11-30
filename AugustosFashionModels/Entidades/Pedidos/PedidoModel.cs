using AugustosFashion.Entidades.Cliente;
using AugustosFashionModels.Entidades.Dinheiros;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AugustosFashionModels.Entidades.Pedidos
{
    public class PedidoModel
    {
        public PedidoModel()
        {
            Produtos = new List<PedidoProduto>();
            Cliente = new ClienteModel();
        }

        public int IdPedido { get; set; }
        public ClienteModel Cliente { get; set; }
        public int IdColaborador { get; set; }
        public string FormaPagamento { get; set; }
        public DateTime DataEmissao { get; set; }
        public Dinheiro TotalBruto 
        {
            get => Produtos.Sum(p => (p.PrecoVenda.RetornaValor * p.Quantidade));
        }
        public Dinheiro TotalDesconto
        {
            get => Produtos.Sum(p => (p.Desconto.RetornaValor * p.Quantidade));
        }
        public Dinheiro TotalLiquido
        {
            get => Produtos.Sum(p => p.Total.RetornaValor);
        }
        public List<PedidoProduto> Produtos { get; set; }
        public Dinheiro Lucro
        {
            get => Produtos.Sum(p => p.Total.RetornaValor) - Produtos.Sum(p => p.PrecoCusto.RetornaValor * p.Quantidade);
        }      
        public bool Eliminado { get; set; }
       
        public void AdicionarProduto(PedidoProduto produto) => Produtos.Add(produto);

        public PedidoProduto SelecionarProdutoDoPedido(int id)
        {
            return (from x in Produtos
                    where x.IdProduto == id
                    select x).FirstOrDefault();
        }

        public void AlterarProduto(PedidoProduto produtoEncontrado, PedidoProduto produtoComDadosNovos)
        {
            var index = Produtos.IndexOf(produtoEncontrado);

            Produtos[index].Quantidade = produtoComDadosNovos.Quantidade;
            Produtos[index].Desconto = produtoComDadosNovos.Desconto.RetornaValor;
        }

        public void AdicionarProdutoAoCarrinho(PedidoProduto produto)
        {
            var produtoJaInserido = SelecionarProdutoDoPedido(produto.IdProduto);

            if (produtoJaInserido != null)
            {
                AlterarProduto(produtoJaInserido, produto);
            }
            else
            {
                AdicionarProduto(produto);
            }
        }
    }
}
