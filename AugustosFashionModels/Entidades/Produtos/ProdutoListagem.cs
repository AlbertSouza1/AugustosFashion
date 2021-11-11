using System.ComponentModel;

namespace AugustosFashionModels.Entidades.Produtos
{
    public class ProdutoListagem
    {
        [DisplayName("Id")]
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string Fabricante { get; set; }
        [DisplayName("Preço")]
        public double PrecoVenda { get; set; }
    }
}
