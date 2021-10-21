using System;
using System.Collections.Generic;
using System.Text;
using AugustosFashion.Entidades.Endereco;

namespace AugustosFashion.Helpers
{
    public static class ValidadoresCadastro
    {
        public static bool ValidarEndereco(EnderecoModel endereco)
        {
            var retorno = false;

            if (endereco.CEP == string.Empty)
                MessageBox.Show("É necessário informar um CEP.");
            else if (endereco.Bairro == string.Empty)
                MessageBox.Show("É necessário informar um Bairro.");
            else if (endereco.Cidade == string.Empty)
                MessageBox.Show("É necessário informar uma Cidade.");
            else if (endereco.Logradouro == string.Empty)
                MessageBox.Show("É necessário informar um logradouro.");
            else if (endereco.Numero.ToString() == string.Empty)
                MessageBox.Show("É necessário informar um número residencial.");
            else if (endereco.UF == string.Empty)
                MessageBox.Show("É necessário informar um Estado.");
            else
                retorno = true;

            return retorno;
        }
        public static bool ValidarTelefones(string cel, string fixo)
        {
            if (cel == string.Empty && fixo == string.Empty)
            {
                MessageBox.Show("É necessário informar ao menos um telefone para contato.");
                return false;
            }
            else
                return true;
        }
        
        public static ValidarUsuario(string nome, string sobreNome, string email, string cpf, string sexo, DateTime dataNascimento)
        {
            bool retorno = false;

            if (nome == string.Empty)
                MessageBox.Show("É necessário informar um nome.");
            else if (sobreNome == string.Empty)
                MessageBox.Show("É necessário informar um sobrenome.");
            else if (email == string.Empty)
                MessageBox.Show("É necessário informar um email.");
            else if (cpf == string.Empty)
                MessageBox.Show("É necessário informar um cpf.");
            else if (sexo == string.Empty)
                MessageBox.Show("É necessário informar o sexo.");
            else if (dataNascimento == string.Empty)
                MessageBox.Show("É necessário informar a data de nascimento.");
            else
                retorno = true;

            return retorno;
        }
    }
}
