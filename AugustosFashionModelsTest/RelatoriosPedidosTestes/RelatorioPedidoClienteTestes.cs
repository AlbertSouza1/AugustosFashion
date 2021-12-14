using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using AugustosFashionModels.Entidades.Pedidos.Relatorios.Filtros;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AugustosFashionModelsTest.RelatoriosPedidosTestes
{
    [TestClass]
    public class RelatorioPedidoClienteTestes
    {
        [TestMethod]
        public void TotalLiquido_do_item_relatorio_deve_calcular_total_liquido_do_cliente()
        {
            var sut = RelatorioPedidoClienteMock.RetornarItemDeRelatorio();

            Assert.AreEqual(50, sut.TotalLiquido.RetornaValor);
        }

        [TestMethod]
        public void TotalBruto_deve_calcular_total_de_todos_os_itens_do_relatorio()
        {
            var sut = new RelatorioPedidoClienteViewModel();
            var listaRelatorio = RelatorioPedidoClienteMock.RetornarListaDeItensRelatorio();

            sut.Relatorio.AddRange(listaRelatorio);

            Assert.AreEqual(120, sut.TotalBruto.RetornaValor);
        }

        [TestMethod]
        public void TotalLiquido_deve_calcular_total_de_todos_os_itens_do_relatorio()
        {
            var sut = new RelatorioPedidoClienteViewModel();
            var listaRelatorio = RelatorioPedidoClienteMock.RetornarListaDeItensRelatorio();

            sut.Relatorio.AddRange(listaRelatorio);

            Assert.AreEqual(111, sut.TotalLiquido.RetornaValor);
        }

        [TestMethod]
        public void TotalDesconto_deve_calcular_total_de_todos_os_itens_do_relatorio()
        {
            var sut = new RelatorioPedidoClienteViewModel();
            var listaRelatorio = RelatorioPedidoClienteMock.RetornarListaDeItensRelatorio();

            sut.Relatorio.AddRange(listaRelatorio);

            Assert.AreEqual(9, sut.TotalDesconto.RetornaValor);
        }

        [TestMethod]
        public void TotalCompras_deve_calcular_total_de_compras_de_todo_o_relatorio()
        {
            var sut = new RelatorioPedidoClienteViewModel();
            var listaRelatorio = RelatorioPedidoClienteMock.RetornarListaDeItensRelatorio();

            sut.Relatorio.AddRange(listaRelatorio);

            Assert.AreEqual(30, sut.TotalCompras);
        }

        [DataTestMethod]
        [DataRow("ab", "5", false)]
        [DataRow("33", "5a6", false)]
        [DataRow("", "1", true)]
        [DataRow("5", "", true)]
        [DataRow("3", " ", false)]
        [DataRow(" ", "5,8", false)]
        [DataRow("35,6", "1", true)]
        public void Validar_filtros_deve_retornar_falso_se_algum_valor_vier_em_formato_incorreto(string valorBase, string qtdResultados, bool esperado)
        {
            var sut = new FiltroRelatorioPedidoCliente();           
                        
            Assert.AreEqual(esperado, sut.ValidarFiltros(valorBase, qtdResultados));
        }

        [TestMethod]
        [DataRow("", 0)]
        [DataRow("5", 5 )]
        [DataRow(null, 0 )]
        public void Setar_filtros_deve_setar_zero_para_valor_base_se_nao_passado_pelo_usuario(string valorBase, int esperado)
        {
            var sut = new FiltroRelatorioPedidoCliente();

            sut.SetarFiltros(DateTime.Now, DateTime.Now, 0, valorBase, "5", 1);

            Assert.AreEqual(Convert.ToDecimal(esperado), sut.ValorBase);
        }

        [TestMethod]
        [DataRow("", 0)]
        [DataRow("5", 5)]
        [DataRow(null, 0)]
        public void Setar_filtros_deve_setar_zero_para_qtdResultados_se_nao_passado_pelo_usuario(string qtdResultados, int esperado)
        {
            var sut = new FiltroRelatorioPedidoCliente();

            sut.SetarFiltros(DateTime.Now, DateTime.Now, 0, "", qtdResultados, 1);

            Assert.AreEqual(esperado, sut.QuantidadeResultados);
        }
    }
}
