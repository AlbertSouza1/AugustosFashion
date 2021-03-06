using AugustosFashionModels.Entidades.Pedidos;
using AugustosFashionModels.Entidades.Produtos;
using AugustosFashionModelsTest.ClientesTestes;
using AugustosFashionModelsTest.PedidosTestes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AugustosFashionModelsTest
{
    [TestClass]
    public class PedidoModelTestes
    {
        
        [TestMethod]      
        public void Verificar_se_total_bruto_esta_calculando_corretamente()
        {
            var pedido = new PedidoModel();
            pedido.Produtos = PedidoModelMock.RetornarPedidoProdutos();

            var esperado = 29;

            Assert.AreEqual(esperado, pedido.TotalBruto.RetornaValor);
        }

        [TestMethod]
        public void Verificar_se_total_de_desconto_esta_calculando_corretamente()
        {
            var pedido = new PedidoModel();
            pedido.Produtos = PedidoModelMock.RetornarPedidoProdutos();

            var esperado = 13;

            Assert.AreEqual(esperado, pedido.TotalDesconto.RetornaValor);
        }

        [TestMethod]
        public void Verificar_se_total_liquido_esta_calculando_corretamente()
        {
            var pedido = new PedidoModel();
            pedido.Produtos = PedidoModelMock.RetornarPedidoProdutos();

            Assert.AreEqual(16, pedido.TotalLiquido.RetornaValor);
        }
        [TestMethod]
        public void Verificar_se_lucro_esta_calculando_corretamente()
        {
            var pedido = new PedidoModel();
            pedido.Produtos = PedidoModelMock.RetornarPedidoProdutos();

            var esperado = 8;

            Assert.AreEqual(esperado, pedido.Lucro.RetornaValor);
        }

        [TestMethod]
        public void Selecionar_produto_do_pedido_deve_retornar_produto_se_encontrado()
        {
            var pedido = new PedidoModel();
            pedido.Produtos = PedidoModelMock.RetornarPedidoProdutos();
            int idProdutoBuscado = 1;

            var indice = pedido.RetornarIndiceDoProduto(idProdutoBuscado);

            var esperado = pedido.Produtos[0];

            Assert.AreEqual(esperado, pedido.SelecionarProdutoDoPedido(indice));
        }

        [TestMethod]
        public void Selecionar_produto_do_pedido_deve_retornar_null_se_indice_nao_for_encontrado()
        {
            var pedido = new PedidoModel();
            pedido.Produtos = PedidoModelMock.RetornarPedidoProdutos();

            int idProdutoBuscado = 55;

            var indice = pedido.RetornarIndiceDoProduto(idProdutoBuscado);

            PedidoProduto esperado = null;

            Assert.AreEqual(esperado, pedido.SelecionarProdutoDoPedido(indice));
        }

        [TestMethod]
        public void Alterar_produto_do_pedido_deve_atualizar_quantidade_e_desconto()
        {
            //arrange
            var pedido = new PedidoModel();
            pedido.Produtos = PedidoModelMock.RetornarPedidoProdutos();

            var indice = pedido.RetornarIndiceDoProduto(pedido.Produtos[0].IdProduto);
            var produtoComDadosNovos = new PedidoProduto() {Quantidade = 6, Desconto = 0 };

            //act
            pedido.AlterarProduto(indice, produtoComDadosNovos);

            //assert
            Assert.AreEqual(produtoComDadosNovos.Quantidade, pedido.SelecionarProdutoDoPedido(indice).Quantidade);
            Assert.AreEqual(produtoComDadosNovos.Desconto.RetornaValor, pedido.SelecionarProdutoDoPedido(indice).Desconto.RetornaValor);
        }

        [TestMethod]
        public void VerificarSeClientePossuiLimite_deve_retornar_false_se_valor_do_pedido_for_maior_que_limite()
        {
            //arrange
            var pedido = new PedidoModel();
            pedido.Produtos = PedidoModelMock.RetornarProdutosDeValoresAltos();
            pedido.Cliente = ClienteModelMock.RetornarCliente();//limite 1000

            //act assert
            Assert.IsFalse(pedido.VerificarSeClientePossuiLimite());
        }

        [TestMethod]
        public void VerificarSeClientePossuiLimite_deve_retornar_true_se_valor_do_pedido_for_menor_que_limite()
        {
            //arrange
            var pedido = new PedidoModel();
            pedido.Produtos = PedidoModelMock.RetornarPedidoProdutos();
            pedido.Cliente = ClienteModelMock.RetornarCliente();//limite 1000

            //act assert
            Assert.IsTrue(pedido.VerificarSeClientePossuiLimite());
        }

        [TestMethod]
        public void AdicionarProdutoAoCarrinho_deve_verificar_se_produto_ja_esta_inserido_e_alteralo()
        {
            //arrange
            var pedido = new PedidoModel();
            pedido.Produtos = PedidoModelMock.RetornarPedidoProdutos();//haviam 2

            //act
            pedido.AdicionarProdutoAoCarrinho(PedidoModelMock.RetornarPedidoProduto());

            //assert
            Assert.AreEqual(2, pedido.Produtos.Count);
        }

        [TestMethod]
        public void AdicionarProdutoAoCarrinho_deve_verificar_se_produto_nao_esta_inserido_e_inserilo()
        {
            //arrange
            var pedido = new PedidoModel();
            pedido.Produtos = PedidoModelMock.RetornarPedidoProdutos();//haviam 2

            //act
            pedido.AdicionarProdutoAoCarrinho(new PedidoProduto()
            {
                IdProduto = 66,
                PrecoVenda = 5000,
                PrecoCusto = 500,
                Quantidade = 5,
                Desconto = 50
            });

            //assert
            Assert.AreEqual(3, pedido.Produtos.Count);
        }
    }
}
