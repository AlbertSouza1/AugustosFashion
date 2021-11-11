namespace AugustosFashionModels.Entidades.Produtos
{
    public class ProdutoModel
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string CodigoBarras { get; set; }
        public string Fabricante { get; set; }
        public double PrecoCusto { get; set; }
        public double PrecoVenda { get; set; }
        public int Estoque { get; set; }
        public StatusProduto Status { get; set; }      
    }
}
