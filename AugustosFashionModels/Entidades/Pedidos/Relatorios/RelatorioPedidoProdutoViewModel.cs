using AugustosFashionModels.Entidades.Dinheiros;
using System.Collections.Generic;
using System.Linq;

namespace AugustosFashionModels.Entidades.Pedidos.Relatorios
{
    public class RelatorioPedidoProdutoViewModel
    {
        public RelatorioPedidoProdutoViewModel()
        {
            Relatorio = new List<RelatorioPedidoProduto>();
        }

        public List<RelatorioPedidoProduto> Relatorio { get; set; }
        public Dinheiro TotalBruto { get => Relatorio.Sum(x => x.TotalBruto.RetornaValor); }
        public Dinheiro TotalDesconto { get => Relatorio.Sum(x => x.TotalDesconto.RetornaValor); }
        public Dinheiro TotalLiquido { get => Relatorio.Sum(x => x.TotalLiquido.RetornaValor); }
        public Dinheiro TotalLucro { get => Relatorio.Sum(x => x.LucroReais.RetornaValor); }
        public int TotalProdutosVendidos { get => Relatorio.Sum(x => x.QuantidadeVendida); }
    }
}
