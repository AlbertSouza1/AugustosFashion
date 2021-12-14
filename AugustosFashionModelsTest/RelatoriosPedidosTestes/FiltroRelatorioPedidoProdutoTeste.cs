using AugustosFashionModels.Entidades.Pedidos.Relatorios.Filtros;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AugustosFashionModelsTest.RelatoriosPedidosTestes
{
    [TestClass]
    public class FiltroRelatorioPedidoProdutoTeste
    {
        [TestMethod]
        public void Remover_produto_deve_retornar_se_indice_vier_fora_do_range()
        {
            var sut = new FiltroRelatorioPedidoProduto();
            var list = RelatorioPedidoProdutoMock.RetornarListaGenerica();

            sut.Produtos.AddRange(list);
            var expected = sut.Produtos.Count;
            sut.RemoverProduto(-1);

            Assert.AreEqual(expected, sut.Produtos.Count);
        }

        [TestMethod]
        public void Remover_produto_deve_retirar_item_se_indice_for_encontrado()
        {
            var sut = new FiltroRelatorioPedidoProduto();
            var list = RelatorioPedidoProdutoMock.RetornarListaGenerica();

            sut.Produtos.AddRange(list);
            var expected = sut.Produtos.Count-1;
            sut.RemoverProduto(0);

            Assert.AreEqual(expected, sut.Produtos.Count);
        }

        [TestMethod]
        public void Remover_cliente_deve_retornar_se_indice_vier_fora_do_range()
        {
            var sut = new FiltroRelatorioPedidoProduto();
            var list = RelatorioPedidoProdutoMock.RetornarListaGenerica();

            sut.Clientes.AddRange(list);
            var expected = sut.Clientes.Count;
            sut.RemoverCliente(-1);

            Assert.AreEqual(expected, sut.Clientes.Count);
        }

        [TestMethod]
        public void Remover_cliente_deve_retirar_item_se_indice_for_encontrado()
        {
            var sut = new FiltroRelatorioPedidoProduto();
            var list = RelatorioPedidoProdutoMock.RetornarListaGenerica();

            sut.Clientes.AddRange(list);
            var expected = sut.Clientes.Count - 1;
            sut.RemoverCliente(0);

            Assert.AreEqual(expected, sut.Clientes.Count);
        }
    }
}
