using AugustosFashion.Entidades.Endereco;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit.Sdk;

namespace TestesUnitarios
{
    [TestClass]
    public class TesteEndereco
    {
        [TestMethod]
        public void Endereco_com_algum_campo_vazio_ou_errado_deve_retornar_false()
        {
            //assert
            var endereco = new EnderecoModel();
        }
    }
}
