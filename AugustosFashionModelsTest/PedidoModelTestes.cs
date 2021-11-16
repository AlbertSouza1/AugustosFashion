using AugustosFashionModels.Entidades.Pedidos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashionModelsTest
{
    [TestClass]
    public class PedidoModelTestes
    {
        List<PedidoProdutoModel> _produtosNoPedido = new List<PedidoProdutoModel>()
        {
            new PedidoProdutoModel(){
                IdProduto = 1,
                PrecoVenda = 3,
                Quantidade = 3,
                Desconto = 1                
            },
            new PedidoProdutoModel(){
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

            Assert.AreEqual(esperado, pedido.TotalBruto);
        }

        [TestMethod]
        public void Verificar_se_total_de_desconto_esta_calculando_corretamente()
        {
            var pedido = new PedidoModel();
            pedido.Produtos = _produtosNoPedido;

            var esperado = 13;

            Assert.AreEqual(esperado, pedido.TotalDesconto);
        }

        [TestMethod]
        public void Verificar_se_total_liquido_esta_calculando_corretamente()
        {
            var pedido = new PedidoModel();
            pedido.Produtos = _produtosNoPedido;

            var esperado = 29;

            Assert.AreEqual(esperado, pedido.TotalLiquido);
        }
    }
}
