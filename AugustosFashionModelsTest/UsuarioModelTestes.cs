using AugustosFashion.Entidades.Cliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            cliente.Email = email;

            //act
            var mensagem = cliente.ValidarCliente();

            //assert
            Assert.AreEqual(resultadoEsperado, mensagem);
        }
    }
}
