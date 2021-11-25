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
                Quantidade = 3,
                Desconto = 1                
            },
            new PedidoProduto(){
                IdProduto = 2,
                PrecoVenda = 4,
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
    }
}
