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
            colaborador.PorcentagemComissao = 50;
            colaborador.CPF = "41231231231";

            //act
            var mensagem = colaborador.ValidarColaborador();

            //assert
            Assert.AreEqual(retornoEsperado, mensagem);
        }

        [TestMethod]
        [DataRow(-10, "Porcentagem de comissão não pode ser negativa")]
        [DataRow(0, "")]
        [DataRow(10, "")]
        public void Se_porcentagem_comissao_for_menor_que_0_deve_retornar_mensagem_erro(int porcentagem, string retornoEsperado)
        {
            //arrange
            ColaboradorModel colaborador = new ColaboradorModel();
            colaborador.Email = "email@email.com";
            colaborador.NomeCompleto.Nome = "José";
            colaborador.NomeCompleto.SobreNome = "Aldo";
            colaborador.Salario = 100;
            colaborador.PorcentagemComissao = porcentagem;
            colaborador.CPF = "41231231231";

            //act
            var mensagem = colaborador.ValidarColaborador();

            //assert
            Assert.AreEqual(retornoEsperado, mensagem);
        }

        [TestMethod]
        [DataRow(150, "Porcentagem de comissão não pode ser maior do que 100%")]
        [DataRow(100, "")]
        [DataRow(14, "")]
        public void Se_porcentagem_comissao_for_maior_que_100_deve_retornar_mensagem_erro(int porcentagem, string retornoEsperado)
        {
            //arrange
            ColaboradorModel colaborador = new ColaboradorModel();
            colaborador.Email = "email@email.com";
            colaborador.NomeCompleto.Nome = "José";
            colaborador.NomeCompleto.SobreNome = "Aldo";
            colaborador.CPF = "41231231231";
            colaborador.Salario = 100;
            colaborador.PorcentagemComissao = porcentagem;

            //act
            var mensagem = colaborador.ValidarColaborador();

            //assert
            Assert.AreEqual(retornoEsperado, mensagem);
        }
    }
}
