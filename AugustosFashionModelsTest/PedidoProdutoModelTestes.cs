using AugustosFashionModels.Entidades.Produtos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AugustosFashionModelsTest
{
    [TestClass]
    public class PedidoProdutoModelTestes
    {
        [TestMethod]
        [DataRow(5.5, 2.5, 3)]
        [DataRow(5, 1, 4)]
        [DataRow(7, 0, 7)]
        [DataRow(15, 6, 9)]
        public void VerificarSePrecoLiquidoEstaCalculandoCorretamente(double precoVenda, double desconto, double esperado)
        {
            var produtoCarrinho = new ProdutoCarrinho();
            produtoCarrinho.PrecoVenda = Convert.ToDecimal(precoVenda);
            produtoCarrinho.Desconto =Convert.ToDecimal(desconto);

            Assert.AreEqual(Convert.ToDecimal(esperado), produtoCarrinho.PrecoLiquido.RetornaValor);
        }

        [TestMethod]
        [DataRow(5.5, 5, 27.5)]
        [DataRow(5, 3, 15)]
        [DataRow(7, 1, 7)]
        [DataRow(15, 2, 30)]
        public void VerificarSeTotalEstaCalculandoCorretamente(double preco, int quantidade, double esperado)
        {
            var produtoCarrinho = new ProdutoCarrinho();
            produtoCarrinho.PrecoVenda = Convert.ToDecimal(preco);
            produtoCarrinho.Quantidade = quantidade;
            produtoCarrinho.Desconto = 0;

            Assert.AreEqual(Convert.ToDecimal(esperado), produtoCarrinho.Total.RetornaValor);
        }
    }
}
