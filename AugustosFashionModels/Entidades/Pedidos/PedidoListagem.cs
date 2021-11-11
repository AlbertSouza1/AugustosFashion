namespace AugustosFashionModels.Entidades.Pedidos
{
    public class PedidoListagem
    {
        public int IdPedido { get; set; }
        public string NomeCliente { get; set; }
        public string NomeColaborador { get; set; }
        public string FormaPagamento { get; set; }
        public double TotalBruto { get; set; }
        public double TotalDesconto { get; set; }
        public double TotalLiquido { get; set; }
        public double Lucro { get; set; }
    }
}
