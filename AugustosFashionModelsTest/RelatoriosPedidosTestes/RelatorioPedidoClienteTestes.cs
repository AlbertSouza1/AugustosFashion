using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
