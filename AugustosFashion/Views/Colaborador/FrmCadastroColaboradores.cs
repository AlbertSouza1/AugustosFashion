using AugustosFashion.Controllers;
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

            if (ValidadoresCadastro.ValidarSexoEUf(cbSexo.SelectedItem, cbUf.SelectedItem) && VerificarValidacoesDeColaborador(cpfSemPontos))
            {
                var colaborador = InstanciarColaboradorParaCadastro(cpfSemPontos);
                var endereco = InstanciarEnderecoParaCadastro();
                var telefones = InstanciarTelefonesParaCadastro();
                var contaBancaria = InstanciarContaBancariaParaCadastro();

                if (_cadastroColaboradorController.CadastrarColaborador(colaborador, endereco, telefones, contaBancaria))
                    this.Close();
            }
        }

        private bool VerificarValidacoesDeColaborador(string cpf)
        {
            bool validacoes = true;

            if (!ValidadoresCadastro.ValidarNumeroResidencial(txtNumero.Text))
                validacoes = false;
            else if (!ValidadoresCadastro.ValidarCEP(txtCep.Text))
                validacoes = false;
            else if (!ValidadoresCadastro.ValidarCPF(cpf))
                validacoes = false;
            else if (!ValidadoresCadastro.ValidarUsuario(txtNome.Text, txtSobreNome.Text, txtEmail.Text, mtxtCpf.Text, cbSexo.Text, dtpDataNascimento.Value))
                validacoes = false;
            else if (!ValidadoresCadastro.ValidarEndereco(InstanciarEnderecoParaCadastro()))
                validacoes = false;
            else if (!ValidadoresCadastro.ValidarContaBancaria(txtBanco, txtAgencia, txtConta, cbTipoConta))           
                validacoes = false;
            else if (!ValidarCamposDeColaborador())
                validacoes = false;
            else if (!ValidadoresCadastro.ValidarTelefones(txtCelular.Text, txtTelefoneFixo.Text))
                validacoes = false;

            return validacoes;
        }

        private bool ValidarCamposDeColaborador()
        {
            var retorno = false;

            if (txtSalario.Text == string.Empty)
            {
                MessageBox.Show("É necessário informar o salário do colaborador.");
            }
            else if(txtComissao.Text == string.Empty)
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
                porcentagemComissao: int.Parse(txtComissao.Text)
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
