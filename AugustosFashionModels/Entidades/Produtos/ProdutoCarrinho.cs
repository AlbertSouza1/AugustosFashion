using System.ComponentModel;

namespace AugustosFashionModels.Entidades.Produtos
{
    public class ProdutoCarrinho
    {
        [Browsable(false)]
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string Fabricante { get; set; }
        public double PrecoVenda { get; set; }
        public int Quantidade { get; set; }
        public double Desconto { get; set; }
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
