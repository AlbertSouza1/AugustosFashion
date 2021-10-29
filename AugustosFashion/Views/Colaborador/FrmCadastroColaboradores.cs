﻿using AugustosFashion.Controllers;
using AugustosFashion.Entidades.Cliente;
using AugustosFashion.Entidades.Colaborador;
using AugustosFashion.Entidades.ContaBancaria;
using AugustosFashion.Entidades.Endereco;
using AugustosFashion.Entidades.Telefone;
using AugustosFashion.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AugustosFashion.Views
{
    public partial class FrmCadastroColaboradores : Form
    {
        private readonly CadastroColaboradorController _cadastroColaboradorController;
        public FrmCadastroColaboradores(CadastroColaboradorController cadastroColaboradorController)
        {
            InitializeComponent();
            _cadastroColaboradorController = cadastroColaboradorController;
        }

        private void FrmCadastroColaboradores_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastrarColaborador_Click(object sender, EventArgs e)
        {
            var cpfSemPontos = RemoveMaskCpf.RemoverMaskCpf(mtxtCpf.Text);

            if (VerificarValidacoesDeColaborador(cpfSemPontos))
            {
                var colaborador = InstanciarColaboradorParaCadastro(cpfSemPontos);
                colaborador.Endereco = InstanciarEnderecoParaCadastro();
                colaborador.Telefones = InstanciarTelefonesParaCadastro();
                colaborador.ContaBancaria = InstanciarContaBancariaParaCadastro();

                try
                {
                    if (_cadastroColaboradorController.CadastrarColaborador(colaborador))
                    {
                        MessageBox.Show("Colaborador cadastrado com sucesso!");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha ao cadastrar colaborador. Erro: " + ex.Message);
                }
            }
        }
        private bool VerificarValidacoesDeColaborador(string cpf)
        {
            bool validacoes = true;
            if (!ValidadoresCadastro.ValidarSexo(cbSexo.SelectedItem))
            {
                validacoes = false;
                MessageBox.Show("Sexo inválido.");
            }
            else if (!ValidadoresCadastro.ValidarUf(cbUf.SelectedItem))
            {
                validacoes = false;
                MessageBox.Show("UF inválida.");
            }
            else if (!ValidadoresCadastro.ValidarNumeroResidencial(txtNumero.Text))
            {
                validacoes = false;
                MessageBox.Show("Número residencial inválido.");
            }
            else if (!ValidadoresCadastro.ValidarCEP(txtCep.Text))
            {
                validacoes = false;
                MessageBox.Show("CEP inválido.");
            }
            else if (!ValidadoresCadastro.ValidarCPF(cpf))
            {
                MessageBox.Show("CPF inválido.");
                validacoes = false;
            }
            else if (!ValidadoresCadastro.ValidarNome(txtNome.Text))
            {
                MessageBox.Show("Nome inválido.");
                validacoes = false;
            }
            else if (!ValidadoresCadastro.ValidarSobreNome(txtSobreNome.Text))
            {
                MessageBox.Show("Sobrenome inválido.");
                validacoes = false;
            }
            else if (!ValidadoresCadastro.ValidarEmail(txtEmail.Text))
            {
                MessageBox.Show("Email inválido.");
                validacoes = false;
            }
            else if (!ValidadoresCadastro.ValidarDataNascimento(dtpDataNascimento.Value))
            {
                MessageBox.Show("Data de nascimento inválido.");
                validacoes = false;
            }
            else if (!ValidadoresCadastro.ValidarLogradouro(txtLogradouro.Text))
            {
                MessageBox.Show("Logradouro inválido.");
                validacoes = false;
            }
            else if (!ValidadoresCadastro.ValidarBairro(txtBairro.Text))
            {
                MessageBox.Show("Bairro inválido.");
                validacoes = false;
            }
            else if (!ValidadoresCadastro.ValidarCidade(txtCidade.Text))
            {
                MessageBox.Show("Cidade inválida.");
                validacoes = false;
            }
            else if (!ValidarCamposDeColaborador())
                validacoes = false;
            else if (!ValidadoresCadastro.ValidarTelefones(txtCelular.Text, txtTelefoneFixo.Text))
            {
                validacoes = false;
                MessageBox.Show("É necessário informar um número para contato.");
            }
            else if (!ValidadoresCadastro.ValidarBanco(txtBanco.Text))
            {
                validacoes = false;
                MessageBox.Show("Banco inválido.");
            }
            else if (!ValidadoresCadastro.ValidarAgencia(txtAgencia.Text))
            {
                validacoes = false;
                MessageBox.Show("Agência inválida.");
            }
            else if (!ValidadoresCadastro.ValidarConta(txtConta.Text))
            {
                validacoes = false;
                MessageBox.Show("Conta inválida.");
            }
            else if (!ValidadoresCadastro.ValidarTipoConta(cbTipoConta.SelectedItem))
            {
                validacoes = false;
                MessageBox.Show("Tipo da conta inválido.");
            }

            return validacoes;
        }

        private bool ValidarCamposDeColaborador()
        {
            var retorno = false;

            if (txtSalario.Text == string.Empty)
            {
                MessageBox.Show("É necessário informar o salário do colaborador.");
            }
            else if (txtComissao.Text == string.Empty)
            {
                MessageBox.Show("É necessário informar a porcentagem de comissão.");
            }
            else
                retorno = true;

            return retorno;
        }

        public ColaboradorModel InstanciarColaboradorParaCadastro(string cpfSemPontos)
        {
            ColaboradorModel colaborador = new ColaboradorModel(
                nome: txtNome.Text,
                sobreNome: txtSobreNome.Text,
                sexo: cbSexo.SelectedItem.ToString() == "Masculino" ? 'm' : 'f',
                dataNascimento: dtpDataNascimento.Value,
                email: txtEmail.Text,
                cpf: cpfSemPontos,
                salario: double.Parse(txtSalario.Text),
                porcentagemComissao: int.Parse(txtComissao.Text),
                endereco: InstanciarEnderecoParaCadastro(),
                telefones: InstanciarTelefonesParaCadastro()
                );

            return colaborador;
        }

        public EnderecoModel InstanciarEnderecoParaCadastro()
        {
            var endereco = new EnderecoModel(
                cep: txtCep.Text,
                logradouro: txtLogradouro.Text,
                numero: int.Parse(txtNumero.Text),
                cidade: txtCidade.Text,
                uf: cbUf.Text,
                complemento: txtComplemento.Text,
                bairro: txtBairro.Text
                );

            return endereco;
        }

        public List<TelefoneModel> InstanciarTelefonesParaCadastro()
        {
            var celular = new TelefoneModel
            {
                Numero = txtCelular.Text,
                TipoTelefone = TipoTelefone.Celular
            };

            var fixo = new TelefoneModel
            {
                Numero = txtTelefoneFixo.Text,
                TipoTelefone = TipoTelefone.Fixo
            };
            var telefones = new List<TelefoneModel>();

            telefones.Add(celular);
            telefones.Add(fixo);

            return telefones;
        }

        public ContaBancariaModel InstanciarContaBancariaParaCadastro()
        {
            TipoConta tipoConta = 0;

            if (cbTipoConta.SelectedItem.ToString() == "Corrente")
            {
                tipoConta = TipoConta.ContaCorrente;
            }
            else if (cbTipoConta.SelectedItem.ToString() == "Poupança")
            {
                tipoConta = TipoConta.ContaPoupanca;
            }
            else
            {
                tipoConta = TipoConta.ContaSalario;
            }

            var contaBancaria = new ContaBancariaModel
            {
                Banco = txtBanco.Text,
                Agencia = int.Parse(txtAgencia.Text),
                Conta = int.Parse(txtConta.Text),
                TipoConta = tipoConta
            };

            return contaBancaria;
        }
    }
}