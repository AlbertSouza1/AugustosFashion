using System.ComponentModel;

namespace AugustosFashionModels.Entidades.Produtos
{
    public class ProdutoCarrinho
    {
        [DisplayName("Código")]
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string Fabricante { get; set; }
        [DisplayName("Preço de Venda")]
        public double PrecoVenda { get; set; }
        public int Quantidade { get; set; }
        [Browsable(false)]
        public int Estoque { get; set; }
        [DisplayName("Desconto Unitário")]
        public double Desconto { get; set; }
        [DisplayName("Preço Líquido")]
        public double PrecoLiquido
        {
            get => PrecoVenda - Desconto;
        }
        public double Total
        {
            get => PrecoLiquido * Quantidade;
        }
    }
}
