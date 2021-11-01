using AugustosFashion.Entidades.Cliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AugustosFashionModelsTest
{
    [TestClass]
    public class ClienteModelTestes
    {
        [TestMethod]
        public void Se_data_nascimento_cliente_for_igual_a_data_de_hoje_retornar_mensagem_avisando_aniversario()
        {
            //arrange
            ClienteModel cliente = new ClienteModel();
            cliente.NomeCompleto.Nome = "Carlos";
            cliente.DataNascimento = DateTime.Now;
            
            //act
            string mensagemRetorno = cliente.VerificarSeEhAniversarioDoCliente();

            //assert
            Assert.AreEqual("Carlos está fazendo aniversário hoje.", mensagemRetorno);
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
    }
}
