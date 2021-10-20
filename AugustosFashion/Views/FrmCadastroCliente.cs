using AugustosFashion.Controllers;
using AugustosFashion.Entidades.Cliente;
using AugustosFashion.Entidades.Endereco;
using AugustosFashion.Entidades.Telefone;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace AugustosFashion.Views
{
    public partial class FrmCadastroCliente : Form
    {
        private readonly CadastroClienteController _cadastroClienteController;
        public FrmCadastroCliente(CadastroClienteController cadastroClienteController)
        {
            InitializeComponent();
            _cadastroClienteController = cadastroClienteController;
        }

        private void FrmCadastroCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastrarCliente_Click(object sender, EventArgs e)
        {
            var cliente = InstanciarClienteParaCadastro();
            var endereco = InstanciarEnderecoParaCadastro();
            var telefones = InstanciarTelefonesParaCadastro();

            new CadastroClienteController().CadastrarCliente(cliente, endereco, telefones);
        }

        public ClienteModel InstanciarClienteParaCadastro()
        {
            var cpfSemPontos = RemoverMaskCpf();

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

        public  List<TelefoneModel> InstanciarTelefonesParaCadastro()
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

        private string RemoverMaskCpf()
        {
            string cpfSemPontos = mtxtCpf.Text;

            cpfSemPontos = new string((from c in cpfSemPontos
                                       where char.IsDigit(c)
                                       select c
            ).ToArray());

            return cpfSemPontos;
        }
    }
}
