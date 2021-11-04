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

            cliente.Endereco.CEP.RemoverFormatacao();

            Assert.AreEqual("15710000", cliente.Endereco.CEP.RetornaValor);
        }

        [TestMethod]
        public void Se_CEP_nao_possuir_tamanho_oito_deve_retornar_mensagem_de_erro()
        {
            var cliente = new ClienteModel();
            cliente.NomeCompleto.Nome = "José";
            cliente.NomeCompleto.SobreNome = "Aldo";
            cliente.Email = "email@email.com";
            cliente.Endereco.CEP = "1571000012";

            var retorno = cliente.ValidarCliente();

            Assert.AreEqual("CEP inválido", retorno);
        }
    }
}
