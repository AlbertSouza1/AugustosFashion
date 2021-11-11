namespace AugustosFashionModels.Entidades.Pedidos
{
    public class PedidoProdutoModel
    {
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
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
