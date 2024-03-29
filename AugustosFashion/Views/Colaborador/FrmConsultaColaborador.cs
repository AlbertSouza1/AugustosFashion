﻿using AugustosFashion.Controllers.Colaborador;
using AugustosFashion.Entidades.Colaborador;
using AugustosFashion.Entidades.ContaBancaria;
using AugustosFashion.Entidades.Endereco;
using AugustosFashion.Entidades.Telefone;
using AugustosFashion.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AugustosFashion.Views.Colaborador
{
    public partial class FrmConsultaColaborador : Form
    {
        int idCelular;
        int idFixo;
        private readonly ConsultaColaboradorController _consultaColaboradorController;
        public FrmConsultaColaborador(ConsultaColaboradorController consultaColaboradorController)
        {
            InitializeComponent();
            _consultaColaboradorController = consultaColaboradorController;
        }

        internal void ObterDadosParaAlteracao(ColaboradorModel colaborador)
        {
            foreach (var tel in colaborador.Telefones)
            {
                if (tel.Numero.ToString() == string.Empty)
                    continue;
                else
                {
                    if (tel.TipoTelefone == TipoTelefone.Celular)
                    {
                        idCelular = tel.IdTelefone;

                        txtCelular.Text = tel.Numero;
                    }
                    else
                    {
                        idFixo = tel.IdTelefone;

                        txtTelefoneFixo.Text = tel.Numero;
                    }
                }
            }

            txtIdColaborador.Text = colaborador.IdColaborador.ToString();
            txtSalario.Text = colaborador.Salario.ToString();
            txtComissao.Text = colaborador.PorcentagemComissao.ToString();

            txtNome.Text = colaborador.NomeCompleto.Nome;
            txtSobreNome.Text = colaborador.NomeCompleto.SobreNome;
            txtEmail.Text = colaborador.Email.RetornaValor;
            cbSexo.SelectedIndex = SexoIndexComboBoxHelper.RetornarIndexComboBoxSexoCadastrado(colaborador.Sexo);
            dtpDataNascimento.Value = colaborador.DataNascimento;
            mtxtCpf.Text = colaborador.CPF.ValorFormatado;

            txtLogradouro.Text = colaborador.Endereco.Logradouro;
            txtCidade.Text = colaborador.Endereco.Cidade;
            txtComplemento.Text = colaborador.Endereco.Complemento;
            txtBairro.Text = colaborador.Endereco.Bairro;
            txtNumero.Text = colaborador.Endereco.Numero.ToString();
            mtxtCep.Text = colaborador.Endereco.CEP.RetornaValor;
            cbUf.SelectedIndex = EstadoIndexHelper.RetornarIndexComboBoxUfCadastrado(colaborador.Endereco.UF);

            txtBanco.Text = colaborador.ContaBancaria.Banco;
            txtConta.Text = colaborador.ContaBancaria.Conta.ToString();
            txtAgencia.Text = colaborador.ContaBancaria.Agencia.ToString();
            cbTipoConta.SelectedIndex = (int)colaborador.ContaBancaria.TipoConta;
        }

        private void btnAlterarColaborador_Click(object sender, EventArgs e)
        {          
            if (VerificarValidacoesDeColaborador())
            {
                try
                {
                    var colaborador = InstanciarColaboradorParaAlteracao();
                    colaborador.Endereco.CEP.RemoverMascara();
                    colaborador.CPF.RemoverMascara();
                 
                    var retorno = _consultaColaboradorController.AlterarColaborador(colaborador);

                    if (string.IsNullOrEmpty(retorno))
                        MessageBox.Show("Colaborador alterado com sucesso!");
                    else
                        MessageBox.Show(retorno);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Falha ao alterar colaborador. Erro: "+ex.Message);
                }
            }
        }

        private bool VerificarValidacoesDeColaborador()
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
            else if (!ValidadoresCadastro.ValidarCEP(mtxtCep.Text))
            {
                validacoes = false;
                MessageBox.Show("CEP inválido.");
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
            if (txtSalario.Text == string.Empty)
            {
                MessageBox.Show("É necessário informar o salário do colaborador.");
                return false;
            }
            if (!decimal.TryParse(txtSalario.Text, out _))
            {
                MessageBox.Show("Salário inválido.");
                return false;
            }
            else if (txtComissao.Text == string.Empty)
            {
                MessageBox.Show("É necessário informar a porcentagem de comissão.");
                return false;
            }
            return true;
        }

        public ColaboradorModel InstanciarColaboradorParaAlteracao()
        {
            ColaboradorModel colaborador = new ColaboradorModel
            (
                nome: txtNome.Text,
                sobreNome: txtSobreNome.Text,               
                sexo: cbSexo.SelectedItem.ToString() == "Masculino" ? 'm' : 'f',
                dataNascimento: dtpDataNascimento.Value,
                email: txtEmail.Text,
                cpf: mtxtCpf.Text,
                salario: double.Parse(txtSalario.Text),
                porcentagemComissao: int.Parse(txtComissao.Text),
                endereco: InstanciarEnderecoParaAlteracao(),
                telefones: InstanciarTelefonesParaAlteracao(),
                contaBancaria: InstanciarContaBancariaParaAlteracao()
            );
            colaborador.IdColaborador = int.Parse(txtIdColaborador.Text);

            return colaborador;
        }
        public EnderecoModel InstanciarEnderecoParaAlteracao()
        {
            var endereco = new EnderecoModel(
                cep: mtxtCep.Text,
                logradouro: txtLogradouro.Text,
                numero: int.Parse(txtNumero.Text),
                cidade: txtCidade.Text,
                uf: cbUf.Text,
                complemento: txtComplemento.Text,
                bairro: txtBairro.Text
                );

            return endereco;
        }

        public List<TelefoneModel> InstanciarTelefonesParaAlteracao()
        {
            var celular = new TelefoneModel
            {
                IdTelefone = idCelular,
                Numero = txtCelular.Text,
                TipoTelefone = TipoTelefone.Celular
            };

            var fixo = new TelefoneModel
            {
                IdTelefone = idFixo,
                Numero = txtTelefoneFixo.Text,
                TipoTelefone = TipoTelefone.Fixo
            };
            var telefones = new List<TelefoneModel>();

            telefones.Add(celular);
            telefones.Add(fixo);

            return telefones;
        }

        public ContaBancariaModel InstanciarContaBancariaParaAlteracao()
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

        private void btnExcluirColaborador_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Você está prestes a excluir este colaborador. Deseja prosseguir com esta ação?", "Confirmação",
                MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _consultaColaboradorController.ExcluirColaborador(int.Parse(txtIdColaborador.Text));

                    MessageBox.Show("Colaborador excluído com sucesso!");

                    this.Close();
                    new ListaColaboradorController().AbrirFormularioLista();
                } catch(Exception ex)
                {
                    MessageBox.Show("Falha ao excluir colaborador. Erro: " + ex.Message);
                }               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnInativar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Você está prestes a inativar este colaborador. Deseja prosseguir com esta ação?", "Confirmação",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _consultaColaboradorController.InativarColaborador(int.Parse(txtIdColaborador.Text));

                    MessageBox.Show("Colaborador inativado com sucesso!");

                    this.Close();
                    new ListaColaboradorController().AbrirFormularioLista();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha ao inativar colaborador. Erro: " + ex.Message);
                }
            }
        }
    }
}
