using AugustosFashion.Entidades.Cliente;
using AugustosFashionModels.Entidades.Pedidos.Relatorios.Filtros;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AugustosFashionModelsTest.RelatoriosPedidosTestes
{
    [TestClass]
    public class FiltroRelatorioPedidoClienteTeste
    {
        [TestMethod]
        public void Remover_cliente_deve_retornar_se_indice_vier_fora_do_range()
        {
            var sut = new FiltroRelatorioPedidoCliente();
            var list = RelatorioPedidoProdutoMock.RetornarListaGenerica();

            sut.Clientes.AddRange(list);
            var expected = sut.Clientes.Count;
            sut.RemoverCliente(-1);

            Assert.AreEqual(expected, sut.Clientes.Count);
        }

        [TestMethod]
        public void Verificar_se_cliente_ja_esta_inserido_deve_retornar_true_se_indice_for_encontrado()
        {
            var sut = new FiltroRelatorioPedidoCliente();

            sut.Clientes.AddRange(RelatorioPedidoProdutoMock.RetornarListaGenerica());

            Assert.IsTrue(sut.VerificarSeClienteJaEstaInserido(sut.Clientes[0].Id));
        }

        [TestMethod]
        public void Verificar_se_cliente_ja_esta_inserido_deve_retornar_false_se_indice_nao_for_encontrado()
        {
            var sut = new FiltroRelatorioPedidoCliente();

            sut.Clientes.AddRange(RelatorioPedidoProdutoMock.RetornarListaGenerica());

            Assert.IsFalse(sut.VerificarSeClienteJaEstaInserido(0));
        }

        [TestMethod]
        public void Adicionar_cliente_nao_deve_adicionar_se_cliente_ja_existir_na_lista()
        {
            var sut = new FiltroRelatorioPedidoCliente();

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
