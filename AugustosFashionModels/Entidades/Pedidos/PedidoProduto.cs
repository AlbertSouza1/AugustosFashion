using AugustosFashionModels.Entidades.Dinheiros;
using System;
using System.ComponentModel;
using System.Reflection;

namespace AugustosFashionModels.Entidades.Pedidos
{
    public class PedidoProduto
    {
        [Browsable(false)]
        public int IdPedido { get; set; }
        [DisplayName("Código")]
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string Fabricante { get; set; }

        [DisplayName("Preço de Custo")]
        //[Browsable(false)]
        public Dinheiro PrecoCusto { get; set; }

        [DisplayName("Preço de Venda")]
        public Dinheiro PrecoVenda { get; set; }
        public int Quantidade { get; set; }

        [Browsable(false)]
        public int Estoque { get; set; }

        [DisplayName("Desconto Unitário")]
        public Dinheiro Desconto { get; set; } = 0;

        [DisplayName("Preço Líquido")]
        public Dinheiro PrecoLiquido
        {
            get => PrecoVenda.RetornaValor - Desconto.RetornaValor;
        }
        public Dinheiro Total
        {
            get => PrecoLiquido.RetornaValor * Quantidade;
        }
    }
}
