using AugustosFashion.Controllers;
using AugustosFashion.Entidades.Cliente;
using AugustosFashion.Entidades.Endereco;
using AugustosFashion.Entidades.Telefone;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using AugustosFashion.Helpers;

namespace AugustosFashion.Views
{
    public partial class FrmCadastroCliente : Form
    {
        private readonly CadastroClienteController _cadastroClienteController;
        public FrmCadastroCliente(CadastroClienteController cadastroClienteController)
        {
            InitializeComponent();
            _cadastroClienteController = cadastroClienteController;
            this.BringToFront();
        }

        private void FrmCadastroCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastrarCliente_Click(object sender, EventArgs e)
        {
            var cpfSemPontos = RemoveMaskCpf.RemoverMaskCpf(mtxtCpf.Text);

            if (ValidadoresCadastro.ValidarSexoEUf(cbSexo.SelectedItem, cbUf.SelectedItem) && VerificarValidacoesDeCliente(cpfSemPontos))
            {
                var cliente = InstanciarClienteParaCadastro(cpfSemPontos);
                var endereco = InstanciarEnderecoParaCadastro();
                var telefones = InstanciarTelefonesParaCadastro();

                if (new CadastroClienteController().CadastrarCliente(cliente, endereco, telefones))
                    this.Close();
            }
        }

        public ClienteModel InstanciarClienteParaCadastro(string cpfSemPontos)
        {          
            ClienteModel cliente = new ClienteModel(
                nome: txtNome.Text,
                sobreNome: txtSobreNome.Text,
                sexo: cbSexo.SelectedItem.ToString() == "Masculino" ? 'm' : 'f',
                dataNascimento: dtpDataNascimento.Value,
                email: txtEmail.Text,
                cpf: cpfSemPontos,
                limiteCompraAPrazo: double.Parse(txtLimiteCompraPrazo.Text),
                observacao: txtObservacoes.Text
                );
            return cliente;
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

        private bool VerificarValidacoesDeCliente(string cpf)
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
            else if (!ValidarCamposDeCliente())
                validacoes = false;
            else if (!ValidadoresCadastro.ValidarTelefones(txtCelular.Text, txtTelefoneFixo.Text))
                validacoes = false;

            return validacoes;
        }
        private bool ValidarCamposDeCliente()
        {
            var retorno = false;

            if (txtLimiteCompraPrazo.Text == string.Empty)
            {
                MessageBox.Show("É necessário informar um limite para compra a prazo.");
            }
            else
                retorno = true;

            return retorno;
        }
    }
}
