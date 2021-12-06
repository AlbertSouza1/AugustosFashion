using System;

namespace AugustosFashionModels.Entidades.Pedidos.Relatorios
{
    public class FiltroRelatorioPedidoCliente
    {
        public int IdCliente { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public int QuantidadeResultados { get; set; }
        public EOrdenacaoPedidoCliente Ordenacao { get; set; }
        public decimal ValorComprado { get; set; }

    }
}
