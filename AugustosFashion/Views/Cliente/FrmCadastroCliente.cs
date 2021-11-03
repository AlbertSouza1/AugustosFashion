using AugustosFashion.Controllers;
using AugustosFashion.Entidades.Cliente;
using AugustosFashion.Entidades.Endereco;
using AugustosFashion.Entidades.Telefone;
using AugustosFashion.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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

            if (VerificarValidacoesDeCliente(cpfSemPontos))
            {
                try
                {
                    var cliente = InstanciarClienteParaCadastro(cpfSemPontos);

                    var retornoValidacao = cliente.ValidarCliente();
                    if (retornoValidacao == string.Empty)
                    {
                        if (_cadastroClienteController.CadastrarCliente(cliente))
                        {
                            MessageBox.Show("Cliente cadastrado com sucesso!");
                            this.Close();
                        }
                           
                    }
                    else
                        MessageBox.Show(retornoValidacao);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Não foi possível cadastrar o cliente. " + ex.Message);
                }
            }
        }

        public ClienteModel InstanciarClienteParaCadastro(string cpfSemPontos)
        {
            try
            {
                ClienteModel cliente = new ClienteModel(
                    nome: txtNome.Text,
                    sobreNome: txtSobreNome.Text,
                    sexo: cbSexo.SelectedItem.ToString() == "Masculino" ? 'm' : 'f',
                    dataNascimento: dtpDataNascimento.Value,
                    email: txtEmail.Text,
                    cpf: cpfSemPontos,
                    limiteCompraAPrazo: double.Parse(txtLimiteCompraPrazo.Text),
                    observacao: txtObservacoes.Text,
                    endereco: InstanciarEnderecoParaCadastro(),
                    telefones: InstanciarTelefonesParaCadastro()
                    );
                return cliente;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
            if(!ValidadoresCadastro.ValidarSexo(cbSexo.SelectedItem))
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
            else if (!ValidarCamposDeCliente())
            {
                validacoes = false;
            }
            else if (!ValidadoresCadastro.ValidarTelefones(txtCelular.Text, txtTelefoneFixo.Text))
            {
                validacoes = false;
                MessageBox.Show("É necessário informar um número para contato.");
            }

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
