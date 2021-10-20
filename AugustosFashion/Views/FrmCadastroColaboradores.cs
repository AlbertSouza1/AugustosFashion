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
            var colaborador = InstanciarColaboradorParaCadastro();
            var endereco = InstanciarEnderecoParaCadastro();
            var telefones = InstanciarTelefonesParaCadastro();
            var contaBancaria = InstanciarContaBancariaParaCadastro();

            _cadastroColaboradorController.CadastrarColaborador(colaborador, endereco,  telefones, contaBancaria);
        }
        public ColaboradorModel InstanciarColaboradorParaCadastro()
        {
            var cpfSemPontos = RemoveMaskCpf.RemoverMaskCpf(mtxtCpf.Text);

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
            var celular = new TelefoneModel(
                numero: txtCelular.Text
                );
            var fixo = new TelefoneModel(
                numero: txtTelefoneFixo.Text
                );
            var telefones = new List<TelefoneModel>();

            telefones.Add(celular);
            telefones.Add(fixo);

            return telefones;
        } 
        
        public ContaBancariaModel InstanciarContaBancariaParaCadastro()
        {
            TipoConta tipoConta = 0;

            if(cbTipoConta.SelectedItem.ToString() == "Corrente")
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
