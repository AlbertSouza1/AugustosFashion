using AugustosFashion.Entidades.Cliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AugustosFashionModelsTest
{
    [TestClass]
    public class CPFTestes
    {
        [TestMethod]
        public void Cpf_ValorFormatado_deve_retornar_valor_com_pontos_e_traco()
        {
            var cliente = new ClienteModel();
            cliente.CPF = "46772229835";

            Assert.AreEqual("467.722.298-35", cliente.CPF.ValorFormatado);
        }

        [DataTestMethod]     
        [DataRow("46772229835", "")]
        [DataRow("467722298351", "CPF inválido")]
        public void Validar_cpf_deve_retornar_mensagem_de_erro_se_cpf_for_invalido(string valor, string retornoEsperado)
        {
            var cliente = new ClienteModel();
            cliente.CPF = valor;

            cliente.CPF.ValidarCPF();
            var mensagemErro = cliente.CPF.RecuperarMensagemErro;

            Assert.AreEqual(retornoEsperado, mensagemErro);
        }
    }
}
