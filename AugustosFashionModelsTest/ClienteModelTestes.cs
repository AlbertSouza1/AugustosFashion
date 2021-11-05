using AugustosFashion.Entidades.Cliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AugustosFashionModelsTest
{
    [TestClass]
    public class ClienteModelTestes
    {      
        [TestMethod]
        [DataRow("2021/01/11", "")]
        [DataRow("2021/11/05", "Carlos está fazendo aniversário hoje.")]
        [DataRow("2022/06/11", "")]
        [DataRow("2021/12/11", "")]
        public void Se_data_nascimento_cliente_for_igual_a_data_de_hoje_retornar_mensagem_avisando_aniversario(string data, string esperado)
        {

            var teste = Convert.ToDateTime(data);
            //arrange
            ClienteModel cliente = new ClienteModel();
            cliente.NomeCompleto.Nome = "Carlos";
            cliente.DataNascimento = teste;

            //act
            string mensagemRetorno = cliente.VerificarSeEhAniversarioDoCliente();

            //assert
            Assert.AreEqual(esperado, mensagemRetorno);
        }

        [TestMethod]
        public void Se_data_nascimento_cliente_for_diferente_da_data_de_hoje_retornar_string_vazia()
        {
            //arrange
            ClienteModel cliente = new ClienteModel();
            cliente.NomeCompleto.Nome = "Carlos";
            cliente.DataNascimento = new DateTime(2001, 10, 09);

            //act
            string mensagemRetorno = cliente.VerificarSeEhAniversarioDoCliente();

            //assert
            Assert.AreEqual(string.Empty, mensagemRetorno);
        }

        [TestMethod]
        public void Se_limite_compra_a_prazo_for_maior_que_10000_deve_retornar_mensagem_erro()
        {
            //arrange
            ClienteModel cliente = new ClienteModel();
            cliente.Email = "email@email.com";
            cliente.NomeCompleto.Nome = "José";
            cliente.NomeCompleto.SobreNome = "Aldo";
            cliente.LimiteCompraAPrazo = 11000;

            //act
            var mensagem = cliente.ValidarCliente();

            //assert
            Assert.AreEqual("O limite de compra a prazo deve ser menor que R$ 10.000", mensagem);
        }
    }
}
