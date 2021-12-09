using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashionModelsTest.RelatoriosPedidosTestes
{
    public class RelatorioPedidoClienteMock
    {
        public static List<RelatorioPedidoCliente> RetornarListaDeItensRelatorio()
        {
            var lista = new List<RelatorioPedidoCliente>();

            lista.Add(new RelatorioPedidoCliente()
            {
                TotalBruto = 20,
                TotalDesconto = 2,
                QuantidadeCompras = 5
            });
            lista.Add(new RelatorioPedidoCliente()
            {
                TotalBruto = 40,
                TotalDesconto = 2,
                QuantidadeCompras = 10
            });
            lista.Add(new RelatorioPedidoCliente()
            {
                TotalBruto = 60,
                TotalDesconto = 5,
                QuantidadeCompras = 15
            });

            return lista;
        }
        public static RelatorioPedidoCliente RetornarItemDeRelatorio()
        {
            return new RelatorioPedidoCliente()
            {
                TotalBruto = 60,
                TotalDesconto = 10
            };
        }
    }
}
