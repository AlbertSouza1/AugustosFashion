using AugustosFashion.Controllers.Colaborador;
using AugustosFashion.Entidades.Colaborador;
using AugustosFashion.Entidades.ContaBancaria;
using AugustosFashion.Entidades.Endereco;
using AugustosFashion.Entidades.Telefone;
using AugustosFashion.Entidades.Usuario;
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

        internal void ObterDadosParaAlteracao(ColaboradorConsulta colaborador, UsuarioConsulta usuario, EnderecoModel endereco, List<TelefoneModel> telefones, ContaBancariaModel contaBancaria)
        {
            foreach (var tel in telefones)
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

            txtNome.Text = usuario.Nome;
            txtSobreNome.Text = usuario.SobreNome;
            txtEmail.Text = usuario.Email;
            cbSexo.SelectedIndex = SexoIndexComboBoxHelper.RetornarIndexComboBoxSexoCadastrado(usuario.Sexo);
            dtpDataNascimento.Value = usuario.DataNascimento;
            mtxtCpf.Text = usuario.CPF;

            txtLogradouro.Text = endereco.Logradouro;
            txtCidade.Text = endereco.Cidade;
            txtComplemento.Text = endereco.Complemento;
            txtBairro.Text = endereco.Bairro;
            txtNumero.Text = endereco.Numero.ToString();
            txtCep.Text = endereco.CEP;
            cbUf.SelectedIndex = EstadoIndexHelper.RetornarIndexComboBoxUfCadastrado(endereco.UF);

            txtBanco.Text = contaBancaria.Banco;
            txtConta.Text = contaBancaria.Conta.ToString();
            txtAgencia.Text = contaBancaria.Agencia.ToString();
            cbTipoConta.SelectedIndex = TipoContaBancariaComboBoxHelper.RetornarIndexComboBoxUfCadastrado(contaBancaria.TipoConta);

        }

        private void btnAlterarColaborador_Click(object sender, EventArgs e)
        {
            var cpf = RemoveMaskCpf.RemoverMaskCpf(mtxtCpf.Text);

            if (VerificarValidacoesDeColaborador(cpf))
            {
                var colaborador = InstanciarColaboradorParaAlteracao(cpf);
                var endereco = InstanciarEnderecoParaAlteracao();
                var telefones = InstanciarTelefonesParaAlteracao();
                var contaBancaria = InstanciarContaBancariaParaAlteracao();

                _consultaColaboradorController.AlterarColaborador(colaborador, endereco, telefones, contaBancaria);
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

        public ColaboradorModel InstanciarColaboradorParaAlteracao(string cpf)
        {
            ColaboradorModel colaborador = new ColaboradorModel
            {
                IdColaborador = int.Parse(txtIdColaborador.Text),
                Nome = txtNome.Text,
                SobreNome = txtSobreNome.Text,
                Sexo = cbSexo.SelectedItem.ToString() == "Masculino" ? 'm' : 'f',
                DataNascimento = dtpDataNascimento.Value,
                Email = txtEmail.Text,
                CPF = cpf,
                Salario = double.Parse(txtSalario.Text),
                PorcentagemComissao = int.Parse(txtComissao.Text)
            };

            return colaborador;
        }
        public EnderecoModel InstanciarEnderecoParaAlteracao()
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
                bool retorno = _consultaColaboradorController.ExcluirColaborador(int.Parse(txtIdColaborador.Text));
                if (retorno)
                    this.Close();
            }
        }
    }
}
