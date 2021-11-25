using AugustosFashionModels.Entidades.Pedidos;
using AugustosFashionModels.Entidades.Produtos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AugustosFashionModelsTest
{
    [TestClass]
    public class PedidoModelTestes
    {
        List<PedidoProduto> _produtosNoPedido = new List<PedidoProduto>()
        {
            new PedidoProduto(){
                IdProduto = 1,
                PrecoVenda = 3,
                PrecoCusto = 1,
                Quantidade = 3,
                Desconto = 1                
            },
            new PedidoProduto(){
                IdProduto = 2,
                PrecoVenda = 4,
                PrecoCusto = 1,
                Quantidade = 5,
                Desconto = 2
            },
        };

        [TestMethod]      
        public void Verificar_se_total_bruto_esta_calculando_corretamente()
        {
            var pedido = new PedidoModel();
            pedido.Produtos = _produtosNoPedido;

            var esperado = 29;

            Assert.AreEqual(esperado, pedido.TotalBruto.RetornaValor);
        }

        [TestMethod]
        public void Verificar_se_total_de_desconto_esta_calculando_corretamente()
        {
            var pedido = new PedidoModel();
            pedido.Produtos = _produtosNoPedido;

            var esperado = 13;

            Assert.AreEqual(esperado, pedido.TotalDesconto.RetornaValor);
        }

        [TestMethod]
        public void Verificar_se_total_liquido_esta_calculando_corretamente()
        {
            var pedido = new PedidoModel();
            pedido.Produtos = _produtosNoPedido;

            var esperado = 16;

            Assert.AreEqual(esperado, pedido.TotalLiquido.RetornaValor);
        }
        [TestMethod]
        public void Verificar_se_lucro_esta_calculando_corretamente()
        {
            var pedido = new PedidoModel();
            pedido.Produtos = _produtosNoPedido;

            var esperado = 8;

            Assert.AreEqual(esperado, pedido.Lucro.RetornaValor);
        }

        [TestMethod]
        public void Selecionar_produto_do_pedido_deve_retornar_produto_se_encontrado()
        {
            var pedido = new PedidoModel();
            pedido.Produtos = _produtosNoPedido;

            var idProcurado = 1;

            var esperado = pedido.Produtos[0];

            Assert.AreEqual(esperado, pedido.SelecionarProdutoDoPedido(idProcurado));
        }

        [TestMethod]
        public void Selecionar_produto_do_pedido_deve_retornar_null_se_produto_nao_esta_na_lista()
        {
            var pedido = new PedidoModel();
            pedido.Produtos = _produtosNoPedido;

            var idProcurado = 99;

            PedidoProduto esperado = null;

            Assert.AreEqual(esperado, pedido.SelecionarProdutoDoPedido(idProcurado));
        }

        [TestMethod]
        public void Alterar_produto_do_pedido_deve_atualizar_quantidade_e_desconto()
        {
            var pedido = new PedidoModel();
            pedido.Produtos = _produtosNoPedido;

            var produtoEncontrado = pedido.SelecionarProdutoDoPedido(_produtosNoPedido[0].IdProduto);
            var produtoComDadosNovos = new PedidoProduto() {Quantidade = 6, Desconto = 0 };

            pedido.AlterarProduto(produtoEncontrado, produtoComDadosNovos);

            var quantidadeEsperada = produtoComDadosNovos.Quantidade;
            var descontoEsperado = produtoComDadosNovos.Desconto.RetornaValor;

            Assert.AreEqual(quantidadeEsperada, pedido.SelecionarProdutoDoPedido(_produtosNoPedido[0].IdProduto).Quantidade);
            Assert.AreEqual(descontoEsperado, pedido.SelecionarProdutoDoPedido(_produtosNoPedido[0].IdProduto).Desconto.RetornaValor);
        }
    }
}
