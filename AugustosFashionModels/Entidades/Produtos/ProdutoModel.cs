using AugustosFashionModels.Entidades.Dinheiros;

namespace AugustosFashionModels.Entidades.Produtos
{
    public class ProdutoModel
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string CodigoBarras { get; set; }
        public string Fabricante { get; set; }
        public Dinheiro PrecoCusto { get; set; }
        public Dinheiro PrecoVenda { get; set; }
        public int Estoque { get; set; }
        public EStatusProduto Status { get; set; }      
    }
}
