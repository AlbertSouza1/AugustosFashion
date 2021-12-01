using AugustosFashion.Entidades.Cliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AugustosFashionModelsTest
{
    [TestClass]
    public class CEPTestes
    {
        [TestMethod]
        public void Remover_formatacao_deve_retornar_cep_apenas_com_numeros()
        {
            var cliente = new ClienteModel();
            cliente.Endereco.CEP = "15710000";

            cliente.Endereco.CEP.RemoverMascara();

            Assert.AreEqual("15710000", cliente.Endereco.CEP.RetornaValor);
        }

        [TestMethod]
        [DataRow("15710000", "")]
        [DataRow("157100001", "CEP inválido")]
        [DataRow("1571000", "CEP inválido")]
        [DataRow("-", "CEP inválido")]
        public void Se_CEP_nao_possuir_tamanho_oito_deve_retornar_mensagem_de_erro(string cep, string retornoEsperado)
        {
            var cliente = new ClienteModel();
            cliente.NomeCompleto.Nome = "José";
            cliente.NomeCompleto.SobreNome = "Aldo";
            cliente.Email = "email@email.com";
            cliente.Endereco.CEP = cep;
            cliente.LimiteCompraAPrazo = 10m;

            var retorno = cliente.ValidarCliente();

            Assert.AreEqual(retornoEsperado, retorno);
        }

        [TestMethod]
        public void Retorna_valor_formatado_deve_retornar_cep_com_traco()
        {
            //arrange
            var cliente = new ClienteModel();         
            cliente.Endereco.CEP = "15710000";

            //act
            var retorno = cliente.Endereco.CEP.RetornaValorFormatado;

            //assert
            Assert.AreEqual("15710-000", retorno);
        }
    }
}
