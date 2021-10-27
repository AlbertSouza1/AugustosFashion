using System;

namespace AugustosFashion.Helpers
{
    public static class ValidadoresCadastro
    {
        public static bool ValidarBairro(string bairro) => !ValidarSeEhNuloOuVazio(bairro);
        public static bool ValidarCidade(string cidade) => !ValidarSeEhNuloOuVazio(cidade);
        public static bool ValidarLogradouro(string logradouro) => !ValidarSeEhNuloOuVazio(logradouro);

        public static bool ValidarTelefones(string cel, string fixo)
        {
            bool retorno = true;

            if (ValidarSeTelefonesEstaoVazios(cel, fixo))
            {
                retorno = false;           
            }
            else
            {
                if (!ValidarSePossuiApenasNumeros(cel))
                    retorno = false;
                else if (!ValidarSePossuiApenasNumeros(fixo))
                    retorno = false;
            }
            return retorno;
        }

        public static bool ValidarSeTelefonesEstaoVazios(string cel, string fixo) =>  ValidarSeEhNuloOuVazio(cel) && ValidarSeEhNuloOuVazio(fixo);


        public static bool ValidarNome(string nome) => !ValidarSeEhNuloOuVazio(nome);
        public static bool ValidarSobreNome(string sobreNome) => !ValidarSeEhNuloOuVazio(sobreNome);
        public static bool ValidarEmail(string email) => !ValidarSeEhNuloOuVazio(email);
        public static bool ValidarDataNascimento(DateTime data) => data < DateTime.Now;

        public static bool ValidarBanco(string banco) => !ValidarSeEhNuloOuVazio(banco);
        public static bool ValidarAgencia(string agencia) => (!ValidarSeEhNuloOuVazio(agencia)) && ValidarSePossuiApenasNumeros(agencia);
        public static bool ValidarConta(string conta) => (!ValidarSeEhNuloOuVazio(conta)) && ValidarSePossuiApenasNumeros(conta);
        public static bool ValidarTipoConta(object cbTipoConta) => cbTipoConta != null;

        public static bool ValidarUf(object uf) => uf != null;

        public static bool ValidarSexo(object sexo) => sexo != null;

        public static bool ValidarNumeroResidencial(string txtNumero) => (!ValidarSeEhNuloOuVazio(txtNumero)) && ValidarSePossuiApenasNumeros(txtNumero);

        public static bool ValidarCPF(string cpf) => (!ValidarSeEhNuloOuVazio(cpf)) && ValidarSePossuiApenasNumeros(cpf) && cpf.Length == 11;

        public static bool ValidarCEP(string txtCep) => (!ValidarSeEhNuloOuVazio(txtCep)) && ValidarSePossuiApenasNumeros(txtCep);

        public static bool ValidarSePossuiApenasNumeros(string text)
        {
            var retorno = true;

            var txtEmArrayChar = text.ToCharArray();

            foreach (var x in txtEmArrayChar)
            {
                if (!Char.IsDigit(x))
                {
                    retorno = false;
                    break;
                }
            }
            return retorno;
        }

        public static bool ValidarSeEhNuloOuVazio(string text)
        {
            if (string.IsNullOrEmpty(text))
                return true;
            else
                return false;
        }
    }
}
