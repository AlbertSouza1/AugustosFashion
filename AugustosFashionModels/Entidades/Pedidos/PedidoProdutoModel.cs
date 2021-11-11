namespace AugustosFashionModels.Entidades.Pedidos
{
    public class PedidoProdutoModel
    {
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public double PrecoLiquido { get; set; }
        public double Desconto { get; set; }
        public double Total { get; set; }
    }
}
