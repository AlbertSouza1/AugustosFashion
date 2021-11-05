using AugustosFashion.Entidades.Colaborador;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AugustosFashionModelsTest
{
    [TestClass]
    public class ColaboradorModelTestes
    {
        [TestMethod]
        [DataRow(-100, "Salário deve ser maior do que 0")]
        [DataRow(0, "Salário deve ser maior do que 0")]
        [DataRow(100, "")]
        public void Se_salario_for_menor_ou_igual_a_0_deve_retornar_mensagem_erro_caso_contrario_retornar_string_vazia(double salario, string retornoEsperado)
        {
            //arrange
            ColaboradorModel colaborador = new ColaboradorModel();
            colaborador.Email = "email@email.com";
            colaborador.NomeCompleto.Nome = "José";
            colaborador.NomeCompleto.SobreNome = "Aldo";
            colaborador.Salario = salario;

            //act
            var mensagem = colaborador.ValidarColaborador();

            //assert
            Assert.AreEqual(retornoEsperado, mensagem);
        }       
    }
}
