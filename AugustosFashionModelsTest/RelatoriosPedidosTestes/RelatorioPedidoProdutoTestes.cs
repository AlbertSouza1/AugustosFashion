using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AugustosFashionModelsTest.RelatoriosPedidosTestes
{
    [TestClass]
    public class RelatorioPedidoProdutoTestes
    {
        [TestMethod]
        public void TotalLiquido_deve_calcular_corretamente_com_base_em_bruto_e_desconto()
        {
            var sut = RelatorioPedidoProdutoMock.RetornarItemDeRelatorio();

            Assert.AreEqual(50, sut.TotalLiquido.RetornaValor);
        }
        [TestMethod]
        public void LucroReais_deve_calcular_corretamente_com_base_em_liquido_e_custo()
        {
            var sut = RelatorioPedidoProdutoMock.RetornarItemDeRelatorio();

            Assert.AreEqual(30, sut.LucroReais.RetornaValor);
        }
        [TestMethod]
        public void LucroPorcentagem_deve_calcular_corretamente_com_base_em_custo_e_lucro_reais()
        {
            var sut = RelatorioPedidoProdutoMock.RetornarItemDeRelatorio();            

            Assert.AreEqual("150,00 %", sut.LucroPorcentagem);
        }

        [TestMethod]
        public void DataFinalFormatada_deve_retornar_data_junto_ao_ultimo_momento_do_dia()
        {
            var sut = new FiltroRelatorioPedidoProduto();

            sut.SetarFiltros(new DateTime(2021,11,01), new DateTime(1999, 12, 30), 1);

            Assert.AreEqual(new DateTime(1999,12,30,23,59,59), sut.DataFinalFormatada);
        }

        [TestMethod]
        public void TotalBruto_deve_calcular_total_de_todos_os_itens_do_relatorio()
        {
            var sut = new RelatorioPedidoProdutoViewModel();
            var listaRelatorio = RelatorioPedidoProdutoMock.RetornarListaDeItensRelatorio();
            
            sut.Relatorio.AddRange(listaRelatorio);

            Assert.AreEqual(120, sut.TotalBruto.RetornaValor);
        }

        [TestMethod]
        public void TotalLiquido_deve_calcular_total_de_todos_os_itens_do_relatorio()
        {
            var sut = new RelatorioPedidoProdutoViewModel();
            var listaRelatorio = RelatorioPedidoProdutoMock.RetornarListaDeItensRelatorio();        
            
            sut.Relatorio.AddRange(listaRelatorio);

            Assert.AreEqual(104, sut.TotalLiquido.RetornaValor);
        }

        [TestMethod]
        public void TotalDesconto_deve_calcular_total_de_todos_os_itens_do_relatorio()
        {
            var sut = new RelatorioPedidoProdutoViewModel();
            var listaRelatorio = RelatorioPedidoProdutoMock.RetornarListaDeItensRelatorio();
            
            sut.Relatorio.AddRange(listaRelatorio);

            Assert.AreEqual(16, sut.TotalDesconto.RetornaValor);
        }
        [TestMethod]
        public void TotalLucro_deve_calcular_total_de_todos_os_itens_do_relatorio()
        {
            var sut = new RelatorioPedidoProdutoViewModel();
            var listaRelatorio = RelatorioPedidoProdutoMock.RetornarListaDeItensRelatorio();
            
            sut.Relatorio.AddRange(listaRelatorio);

            Assert.AreEqual(79, sut.TotalLucro.RetornaValor);
        }
    }
}
