using AugustosFashionModels.Entidades.Dinheiros;
using System.ComponentModel;

namespace AugustosFashionModels.Entidades.Produtos
{
    public class ProdutoCarrinho
    {
        [Browsable(false)]
        public int IdPedido { get; set; }
        [DisplayName("Código")]
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string Fabricante { get; set; }
        [Browsable(false)]
        public Dinheiro PrecoCusto { get; set; }

        [DisplayName("Preço de Venda")]
        public Dinheiro PrecoVenda { get; set; }       
        public int Quantidade { get; set; }

        [Browsable(false)]
        public int Estoque { get; set; }

        [DisplayName("Desconto Unitário")]
        public Dinheiro Desconto { get; set; }

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
