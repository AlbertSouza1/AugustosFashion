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
        public EFormaPagamento FormaPagamento { get; set; }        
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
        public Dinheiro TotalLiquidoPreAlteracao { get; private set; }

        public PedidoProduto SelecionarProdutoDoPedido(int indice)
        {
            if(indice == -1)
                return null;

            return Produtos[indice];
        }

        public void SetarTotalLiquidoPreAlteracao(decimal valor) => TotalLiquidoPreAlteracao = valor;

        public void AlterarProduto(int index, PedidoProduto produtoComDadosNovos)
        {
            Produtos[index].Quantidade = produtoComDadosNovos.Quantidade;
            Produtos[index].Desconto = produtoComDadosNovos.Desconto.RetornaValor;
        }

        public void AdicionarProdutoAoCarrinho(PedidoProduto produto)
        {
            var indice = RetornarIndiceDoProduto(produto.IdProduto);

            if (indice != -1)
                AlterarProduto(indice, produto);
            else
                Produtos.Add(produto);
        }

        public void RemoverProduto(int id) => Produtos.RemoveAt(RetornarIndiceDoProduto(id));

        public int RetornarIndiceDoProduto(int id) => Produtos.FindIndex(x => x.IdProduto == id);

        public void SetarInformacoes(int formaPagamento)
        {
            FormaPagamento = (EFormaPagamento)formaPagamento;
            DataEmissao = DateTime.Now;
        }
     
        public bool VerificarSeClientePossuiLimite()
        {
            decimal limiteAtual;

            if (IdPedido == 0)
                limiteAtual = Cliente.RetornarLimiteParaNovaCompra();
            else
                limiteAtual = Cliente.RetornarLimiteParaAlteracaoDeCompra(TotalLiquidoPreAlteracao.RetornaValor);

            limiteAtual -= TotalLiquido.RetornaValor;

            if (limiteAtual < 0)
                return false;
            
            return true;
        }
    }
}
