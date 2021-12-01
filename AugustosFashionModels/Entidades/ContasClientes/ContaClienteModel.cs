using AugustosFashionModels.Entidades.Dinheiros;

namespace AugustosFashionModels.Entidades.ContasClientes
{
    public class ContaClienteModel
    {
        public int IdConta { get; set; }
        public int IdCliente { get; set; }
        public int IdPedido { get; set; }
        public Dinheiro Valor { get; set; }
        public bool Pago { get; set; }
    }
}
