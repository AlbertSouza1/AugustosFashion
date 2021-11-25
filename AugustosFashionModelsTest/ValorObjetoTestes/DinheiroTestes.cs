using AugustosFashionModels.Entidades.Produtos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AugustosFashionModelsTest
{
    [TestClass]
    public class DinheiroTestes
    {
        [TestMethod]
        public void RetornaValor_deve_retornar_valor_corretamente_em_decimal()
        {
            ProdutoListagem produtoListagem = new ProdutoListagem();

            produtoListagem.PrecoVenda = 55.3m;

            var resultado = produtoListagem.PrecoVenda.RetornaValor;

            Assert.AreEqual(55.30m, resultado);
        }
    }
}
