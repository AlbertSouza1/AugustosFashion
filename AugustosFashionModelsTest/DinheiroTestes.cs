using AugustosFashionModels.Entidades.Produtos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AugustosFashionModelsTest
{
    [TestClass]
    public class DinheiroTestes
    {
        [TestMethod]
        [DataRow("90.34", 90.34)]
        [DataRow("10.5", 10.50)]
        [DataRow("34", 34.00)]
        [DataRow("23", 23.00)]
        public void RetornaValor_deve_retornar_valor_corretamente_em_double(string valor, double esperado)
        {
            ProdutoListagem produtoListagem = new ProdutoListagem();

            produtoListagem.PrecoVenda = valor;

            var resultado = produtoListagem.PrecoVenda.RetornaValor;

            Assert.AreEqual(esperado, resultado);
        }
    }
}
