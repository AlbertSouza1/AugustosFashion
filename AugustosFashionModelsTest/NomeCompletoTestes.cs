using AugustosFashion.Entidades.Cliente;
using AugustosFashionModels.Entidades.NomesCompletos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AugustosFashionModelsTest
{
    [TestClass]
    public class NomeCompletoTestes
    {
        [TestMethod]
        [DataRow("Albert", "Albert", "Nome e sobrenome não podem ser iguais")]
        [DataRow("Albert", "Alberte", "")]
        [DataRow("Alberte", "Albert", "")]
        public void Se_nome_e_sobrenome_forem_iguais_deve_retornar_mensagem_erro(string nome, string sobrenome, string resultadoEsperado)
        {
            //arrange
            ClienteModel cliente = new ClienteModel();
            cliente.NomeCompleto.Nome = nome;
            cliente.NomeCompleto.SobreNome = sobrenome;

            //act
            var retorno = new NomeCompletoValidator().Validate(cliente.NomeCompleto);
          
            //assert
            Assert.AreEqual(resultadoEsperado, retorno.ToString());
        }
    }
}
