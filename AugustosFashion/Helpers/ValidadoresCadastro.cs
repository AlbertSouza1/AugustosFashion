﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
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
            bool retorno = true;

            if (cel == string.Empty && fixo == string.Empty)
            {
                MessageBox.Show("É necessário informar ao menos um telefone para contato.");
                retorno = false;           
            }
            else
            {
                if (!ValidarSePossuiApenasNumeros(cel))
                    retorno = false;
                else if (!ValidarSePossuiApenasNumeros(fixo))
                    retorno = false;

                if(retorno == false)
                    MessageBox.Show("Telefones para contato inválidos");
            }
            return retorno;
        }

        public static bool ValidarUsuario(string nome, string sobreNome, string email, string cpf, string sexo, DateTime dataNascimento)
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
            else if (dataNascimento.ToString() == string.Empty)
                MessageBox.Show("É necessário informar a data de nascimento.");
            else
                retorno = true;

            return retorno;
        }

        internal static bool ValidarContaBancaria(TextBox txtBanco, TextBox txtAgencia, TextBox txtConta, ComboBox cbTipoConta)
        {
            var retorno = true;

            if (string.IsNullOrEmpty(txtConta.Text))
            {
                retorno = false;
                MessageBox.Show("Número da conta não pode ser vazio");
            }
            else if (string.IsNullOrEmpty(txtAgencia.Text))
            {
                retorno = false;
                MessageBox.Show("Agência não pode ser vazia");
            }
            else if (string.IsNullOrEmpty(txtBanco.Text))
            {
                retorno = false;
                MessageBox.Show("Banco não pode ser vazio");
            }
            else if (cbTipoConta.SelectedItem == null)
            {
                retorno = false;
                MessageBox.Show("Tipo da conta não pode ser vazio");
            }

            else
            {
                if (!ValidarSePossuiApenasNumeros(txtAgencia.Text))
                {
                    retorno = false;
                    MessageBox.Show("Agência inválida");
                }

                else if (!ValidarSePossuiApenasNumeros(txtConta.Text))
                {
                    retorno = false;
                    MessageBox.Show("Conta inválida");
                }
            }
            return retorno;
        }

        public static bool ValidarSexoEUf(object sexo, object uf)
        {
            bool retorno = true;

            if (sexo == null)
            {
                MessageBox.Show("É necessário informar o sexo.");
                retorno = false;
            }
            else if (uf == null)
            {
                MessageBox.Show("É necessário informar um estado.");
                retorno = false;
            }

            return retorno;
        }

        public static bool ValidarNumeroResidencial(string txtNumero)
        {
            var retorno = true;

            if (txtNumero != string.Empty)
            {
                retorno = ValidarSePossuiApenasNumeros(txtNumero);
            }
            else
            {
                retorno = false;
            }

            if (retorno == false)
                MessageBox.Show("Número residencial inválido");
            return retorno;
        }

        internal static bool ValidarCPF(string cpf)
        {
            var retorno = true;

            if (cpf != string.Empty)
            {
                retorno = ValidarSePossuiApenasNumeros(cpf);
            }
            else
            {
                retorno = false;
            }

            if (retorno == false)
                MessageBox.Show("CPF inválido");
            return retorno;
        }

        public static bool ValidarCEP(string txtCep)
        {
            var retorno = true;

            if (txtCep != string.Empty)
            {
                retorno = ValidarSePossuiApenasNumeros(txtCep);
            }
            else
            {
                retorno = false;
            }

            if (retorno == false)
                MessageBox.Show("CEP inválido");
            return retorno;
        }

        internal static bool ValidarSePossuiApenasNumeros(string text)
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
    }
}
