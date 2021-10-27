using AugustosFashion.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AugustosFashionTestes
{
    [TestClass]
    public class ValidadoresCadastroTestes
    {
        [TestMethod]
        public void Validar_se_possui_apenas_numeros_apenas_numeros_deve_retornar_true()
        {
            //arrange
            string text = "5323";

            //act
            var retorno = ValidadoresCadastro.ValidarSePossuiApenasNumeros(text);

            //assert
            Assert.IsTrue(retorno);
        }

        [TestMethod]
        public void Vakidar_se_valor_for_nulo_ou_vazio_deve_retornar_true()
        {
            //arrange
            string text = "";

            //act
            var retorno = ValidadoresCadastro.ValidarSeEhNuloOuVazio(text);

            //assert
            Assert.IsTrue(retorno);
        }

        [TestMethod]
        public void Se_numero_residencial_possuir_apenas_numeros_deve_retornar_true()
        {
            //arrange
            string numero = "44";

            //act
            var retorno = ValidadoresCadastro.ValidarNumeroResidencial(numero);

            //assert
            Assert.IsTrue(retorno);
        }

        [TestMethod]
        public void Validar_se_bairro_for_vazio_deve_retornar_false()
        {
            //arrange
            string text = "";

            //act
            var retorno = ValidadoresCadastro.ValidarBairro(text);

            //assert
            Assert.IsFalse(retorno);
        }

        [TestMethod]
        public void Validar_se_cidade_for_vazia_deve_retornar_false()
        {
            //arrange
            string text = "";

            //act
            var retorno = ValidadoresCadastro.ValidarCidade(text);

            //assert
            Assert.IsFalse(retorno);
        }
        [TestMethod]
        public void Validar_se_cidade_nao_for_vazia_deve_retornar_true()
        {
            //arrange
            string text = "Jales";

            //act
            var retorno = ValidadoresCadastro.ValidarCidade(text);

            //assert
            Assert.IsTrue(retorno);
        }

        //[DataTestMethod]
        //[DataRow("Jales", true)]
        //[DataRow(2, 3)]
        //[DataRow(3, 4)]
        //public void Teste(string a, bool esperado)
        //{
        //    Assert.AreEqual(ValidadoresCadastro.ValidarCidade(a), esperado);
        //}

        [TestMethod]
        public void Validar_se_logradouro_for_vazio_deve_retornar_false()
        {
            //arrange
            string text = "";

            //act
            var retorno = ValidadoresCadastro.ValidarLogradouro(text);

            //assert
            Assert.IsFalse(retorno);
        }

        [TestMethod]
        public void Validar_todos_telefone_forem_vazios_deve_retornar_true()
        {
            //arrange
            string cel = "";
            string fixo = "";

            //act
            var retorno = ValidadoresCadastro.ValidarSeTelefonesEstaoVazios(cel, fixo);

            //assert
            Assert.IsTrue(retorno);
        }

        [TestMethod]
        public void Validar_se_telefones_forem_validos_deve_retornar_true()
        {
            //arrange
            string cel = "541234";
            string fixo = "999999";

            //act
            var retorno = ValidadoresCadastro.ValidarTelefones(cel, fixo);

            //assert
            Assert.IsTrue(retorno);
        }

        [TestMethod]
        public void Validar_se_nome_for_vazio_deve_retornar_false()
        {
            //arrange
            string text = "";

            //act
            var retorno = ValidadoresCadastro.ValidarNome(text);

            //assert
            Assert.IsFalse(retorno);
        }

        [TestMethod]
        public void Validar_se_sobrenome_for_vazio_deve_retornar_false()
        {
            //arrange
            string text = "";

            //act
            var retorno = ValidadoresCadastro.ValidarSobreNome(text);

            //assert
            Assert.IsFalse(retorno);
        }

        [TestMethod]
        public void Validar_se_email_for_vazio_deve_retornar_false()
        {
            //arrange
            string text = "";

            //act
            var retorno = ValidadoresCadastro.ValidarEmail(text);

            //assert
            Assert.IsFalse(retorno);
        }

        [TestMethod]
        public void Validar_se_data_nascimento_eh_menor_que_data_atual_retornar_true()
        {
            //arrange
            DateTime data = new DateTime(day: 05, month: 10, year: 2018);

            //act
            var retorno = ValidadoresCadastro.ValidarDataNascimento(data);

            //assert
            Assert.IsTrue(retorno);
        }

        [TestMethod]
        public void Validar_se_UF_for_null_deve_retornar_false()
        {
            //arrange
            string text = null;

            //act
            var retorno = ValidadoresCadastro.ValidarUf(text);

            //assert
            Assert.IsFalse(retorno);
        }
        [TestMethod]
        public void Validar_se_sexo_for_null_deve_retornar_false()
        {
            //arrange
            string text = null;

            //act
            var retorno = ValidadoresCadastro.ValidarSexo(text);

            //assert
            Assert.IsFalse(retorno);
        }

        [TestMethod]
        public void Validar_se_CPF_ter_letras_ou_nao_ter_11_numeros_deve_retornar_false()
        {
            //arrange
            string text = "999999";

            //act
            var retorno = ValidadoresCadastro.ValidarCPF(text);

            //assert
            Assert.IsFalse(retorno);
        }

        [TestMethod]
        public void Validar_se_CEP_for_vazio_ou_ter_letras_deve_retornar_false()
        {
            //arrange
            string text = null;

            //act
            var retorno = ValidadoresCadastro.ValidarCEP(text);

            //assert
            Assert.IsFalse(retorno);
        }

        [TestMethod]
        public void Validar_se_agencia_for_vazio_ou_ter_letras_deve_retornar_false()
        {
            //arrange
            string text = "";

            //act
            var retorno = ValidadoresCadastro.ValidarAgencia(text);

            //assert
            Assert.IsFalse(retorno);
        }

        [TestMethod]
        public void Validar_se_conta_for_vazio_ou_ter_letras_deve_retornar_false()
        {
            //arrange
            string text = "";

            //act
            var retorno = ValidadoresCadastro.ValidarConta(text);

            //assert
            Assert.IsFalse(retorno);
        }

        [TestMethod]
        public void Validar_se_banco_for_vazio_deve_retornar_false()
        {
            //arrange
            string text = "";

            //act
            var retorno = ValidadoresCadastro.ValidarBanco(text);

            //assert
            Assert.IsFalse(retorno);
        }

        [TestMethod]
        public void Validar_se_tipo_conta_for_null_deve_retornar_false()
        {
            //arrange
            string text = null;

            //act
            var retorno = ValidadoresCadastro.ValidarTipoConta(text);

            //assert
            Assert.IsFalse(retorno);
        }
    }
}
