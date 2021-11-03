using AugustosFashion.Entidades.Cliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        [DataRow("46772229835", true)]
        [DataRow("467722298351", false)]
        [DataRow("11111111111", false)]
        public void Validar_cpf_deve_retornar_mensagem_de_erro_se_cpf_for_invalido(string valor, bool retornoEsperado)
        {
            var cliente = new ClienteModel();
            cliente.CPF = valor;

            var retorno = cliente.CPF.ValidarCPF();           

            //var mensagemErro = cliente.CPF.RecuperarMensagemErro;

            Assert.AreEqual(retornoEsperado, retorno.IsValid);
        }
    }
}
