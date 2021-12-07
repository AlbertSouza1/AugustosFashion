using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AugustosFashionModelsTest.RelatoriosPedidosTestes
{
    [TestClass]
    public class RelatorioPedidoProdutoTestes
    {
        [TestMethod]
        public void LucroPorcentagem_deve_calcular_corretamente_com_base_em_custo_e_lucro_reais()
        {
            var relatorio = new RelatorioPedidoProduto();
            relatorio.TotalCusto = 50;
            relatorio.LucroReais = 100;

            var retorno = relatorio.LucroPorcentagem;

            Assert.AreEqual("200,00 %", retorno);
        }

        [TestMethod]
        public void DataFinalFormatada_deve_retornar_data_junto_ao_ultimo_momento_do_dia()
        {
            var filtro = new FiltroRelatorioPedidoProduto();
            filtro.DataFinal = new DateTime(1999,12,30);

            var retorno = filtro.DataFinalFormatada;

            Assert.AreEqual(new DateTime(1999,12,30,23,59,59), retorno);
        }
    }
}
