using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashionModelsTest.RelatoriosPedidosTestes
{
    public static class RelatorioPedidoProdutoMock
    {
        public static List<RelatorioPedidoProduto> RetornarListaDeItensRelatorio()
        {
            var lista = new List<RelatorioPedidoProduto>();

            lista.Add(new RelatorioPedidoProduto()
            {
                TotalBruto = 20,
                TotalCusto = 5,
                TotalDesconto = 1,
            });
            lista.Add(new RelatorioPedidoProduto()
            {
                TotalBruto = 40,
                TotalCusto = 10,
                TotalDesconto = 5
            });
            lista.Add(new RelatorioPedidoProduto()
            {
                TotalBruto = 60,
                TotalCusto = 10,
                TotalDesconto = 10
            });

            return lista;
        }

        public static RelatorioPedidoProduto RetornarItemDeRelatorio()
        {
            return new RelatorioPedidoProduto()
            {
                TotalBruto = 60,
                TotalCusto = 20,
                TotalDesconto = 10
            };
        }

        public static List<ListaGenericaModel> RetornarListaGenerica()
        {
            var lista = new List<ListaGenericaModel>();

            lista.Add(new ListaGenericaModel()
            {
                Id = 1,
                Nome = "um"
            });
            lista.Add(new ListaGenericaModel()
            {
                Id = 2,
                Nome = "dois"
            });
            lista.Add(new ListaGenericaModel()
            {
                Id = 3,
                Nome = "tres"
            });

            return lista;
        }      
    }
}
