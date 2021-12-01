using AugustosFashion.Entidades.Cliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AugustosFashionModelsTest
{
    [TestClass]
    public class UsuarioModelTestes
    {
        [TestMethod]
        [DataRow("email.com", "E-mail inválido")]
        [DataRow("email@com", "E-mail inválido")]
        [DataRow("emailcom", "E-mail inválido")]
        [DataRow("email@email.com", "")]
        public void Se_email_for_invalido_deve_retornar_mensagem_erro(string email, string resultadoEsperado)
        {
            //arrange
            ClienteModel cliente = new ClienteModel();
            cliente.NomeCompleto.Nome = "José";
            cliente.NomeCompleto.SobreNome = "Aldo";
            cliente.Email = email;
            cliente.LimiteCompraAPrazo = 10m;

            //act
            var mensagem = cliente.ValidarCliente();

            //assert
            Assert.AreEqual(resultadoEsperado, mensagem);
        }

        [TestMethod]
        [DataRow("1571000011", "CPF deve ter 11 números")]
        [DataRow("412341234512", "CPF deve ter 11 números")]
        [DataRow("", "CPF deve ter 11 números")]
        [DataRow("41231231234", "")]
        public void Se_CPF_nao_tiver_11_numeros_deve_retornar_mensagem_erro(string cpf, string resultadoEsperado)
        {
            //arrange
            ClienteModel cliente = new ClienteModel();
            cliente.NomeCompleto.Nome = "José";
            cliente.NomeCompleto.SobreNome = "Aldo";
            cliente.Email = "email@teste.com";
            cliente.CPF = cpf;
            cliente.LimiteCompraAPrazo = 10m;

            //act
            var mensagem = cliente.ValidarCliente();

            //assert
            Assert.AreEqual(resultadoEsperado, mensagem);
        }

        [TestMethod]
        [DataRow("46777777787", "")]
        [DataRow("44444444441", "")]
        [DataRow("10000000000", "")]
        [DataRow("00000200000", "")]
        [DataRow("55555555555", "CPF inválido")]
        public void Se_todos_os_numeros_de_cpf_forem_iguais_deve_retornar_mensagem_erro(string cpf, string resultadoEsperado)
        {
            //arrange
            ClienteModel cliente = new ClienteModel();
            cliente.NomeCompleto.Nome = "José";
            cliente.NomeCompleto.SobreNome = "Aldo";
            cliente.Email = "email@teste.com";
            cliente.CPF = cpf;
            cliente.LimiteCompraAPrazo = 10m;

            //act
            var mensagem = cliente.ValidarCliente();

            //assert
            Assert.AreEqual(resultadoEsperado, mensagem);
        }
    }
}
