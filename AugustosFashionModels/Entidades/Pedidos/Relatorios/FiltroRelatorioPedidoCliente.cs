using System;
using System.Collections.Generic;

namespace AugustosFashionModels.Entidades.Pedidos.Relatorios
{
    public class FiltroRelatorioPedidoCliente
    {
        public List<ListaGenericaModel> Clientes { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public int QuantidadeResultados { get; set; }
        public EOrdenacaoPedidoCliente Ordenacao { get; set; }
        public decimal ValorComprado { get; set; }

        public DateTime DataFinalFormatada { get => new DateTime(DataFinal.Year, DataFinal.Month, DataFinal.Day, 23, 59, 59); }
        public FiltroRelatorioPedidoCliente()
        {
            Clientes = new List<ListaGenericaModel>();
        }
    }
}
