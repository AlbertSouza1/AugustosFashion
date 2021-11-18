using System.ComponentModel;

namespace AugustosFashionModels.Entidades.Produtos
{
    public class ProdutoListagem
    {
        [DisplayName("Id")]
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string Fabricante { get; set; }

        [Browsable(false)]
        public double PrecoCusto { get; set; }

        [DisplayName("Preço")]
        public double PrecoVenda { get; set; }
        public int Estoque { get; set; }
    }
}
