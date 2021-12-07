using System;
using System.Collections.Generic;

namespace AugustosFashionModels.Entidades.Pedidos.Relatorios
{
    public class FiltroRelatorioPedidoProduto
    {
        public List<ListaGenericaModel> Produtos { get; set; }
        public List<ListaGenericaModel> Clientes { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public DateTime DataFinalFormatada { get => new DateTime(DataFinal.Year, DataFinal.Month, DataFinal.Day, 23, 59, 59); }
        public FiltroRelatorioPedidoProduto()
        {
            Clientes = new List<ListaGenericaModel>();
            Produtos = new List<ListaGenericaModel>();
        }
    }
}
