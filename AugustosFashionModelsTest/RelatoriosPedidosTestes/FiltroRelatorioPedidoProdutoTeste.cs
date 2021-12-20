using AugustosFashion.Entidades.Cliente;
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

        [TestMethod]
        public void Verificar_se_produto_ja_esta_inserido_deve_retornar_true_se_indice_for_encontrado()
        {
            var sut = new FiltroRelatorioPedidoProduto();
            
            sut.Produtos.AddRange(RelatorioPedidoProdutoMock.RetornarListaGenerica());

            Assert.IsTrue(sut.VerificarSeProdutoJaEstaInserido(sut.Produtos[0].Id));
        }

        [TestMethod]
        public void Verificar_se_produto_ja_esta_inserido_deve_retornar_false_se_indice_nao_for_encontrado()
        {
            var sut = new FiltroRelatorioPedidoProduto();
            
            sut.Produtos.AddRange(RelatorioPedidoProdutoMock.RetornarListaGenerica());

            Assert.IsFalse(sut.VerificarSeProdutoJaEstaInserido(0));
        }

        [TestMethod]
        public void Verificar_se_cliente_ja_esta_inserido_deve_retornar_true_se_indice_for_encontrado()
        {
            var sut = new FiltroRelatorioPedidoProduto();
            
            sut.Clientes.AddRange(RelatorioPedidoProdutoMock.RetornarListaGenerica());

            Assert.IsTrue(sut.VerificarSeClienteJaEstaInserido(sut.Clientes[0].Id));
        }

        [TestMethod]
        public void Verificar_se_cliente_ja_esta_inserido_deve_retornar_false_se_indice_nao_for_encontrado()
        {
            var sut = new FiltroRelatorioPedidoProduto();
           
            sut.Clientes.AddRange(RelatorioPedidoProdutoMock.RetornarListaGenerica());

            Assert.IsFalse(sut.VerificarSeClienteJaEstaInserido(0));
        }

        [TestMethod]
        public void Adicionar_cliente_nao_deve_adicionar_se_cliente_ja_existir_na_lista()
        {
            var sut = new FiltroRelatorioPedidoProduto();
            
            sut.Clientes.AddRange(RelatorioPedidoProdutoMock.RetornarListaGenerica());
            var expected = sut.Clientes.Count;
            sut.AdicionarCliente(new ClienteModel()
            {
                IdCliente = sut.Clientes[0].Id
            });            

            Assert.AreEqual(expected, sut.Clientes.Count);
        }
    }
}
