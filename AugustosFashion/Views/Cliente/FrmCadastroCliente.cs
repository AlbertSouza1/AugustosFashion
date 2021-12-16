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
    
        private void btnCadastrarCliente_Click(object sender, EventArgs e)
        {          
            try
            {
                if (VerificarValidacoesDeCliente())
                {
                    var cliente = InstanciarClienteParaCadastro();

                    CadastrarCliente(cliente);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Falha ao instanciar cliente para cadastro. "+ex.Message);
            }
        }

        private void CadastrarCliente(ClienteModel cliente)
        {
            try
            {
                cliente.Endereco.CEP.RemoverMascara();
                cliente.CPF.RemoverMascara();

                var retorno = _cadastroClienteController.CadastrarCliente(cliente);

                if (string.IsNullOrEmpty(retorno))
                {
                    MessageBox.Show("Cliente cadastrado com sucesso!");
                    this.Close();
                }
                else
                    MessageBox.Show(retorno);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível cadastrar o cliente. " + ex.Message);
            }
        }

        private ClienteModel InstanciarClienteParaCadastro()
        {
            try
            {
                ClienteModel cliente = new ClienteModel(
                    nome: txtNome.Text,
                    sobreNome: txtSobreNome.Text,
                    sexo: cbSexo.SelectedItem.ToString() == "Masculino" ? 'm' : 'f',
                    dataNascimento: dtpDataNascimento.Value,
                    email: txtEmail.Text,
                    cpf: mtxtCpf.Text,
                    limiteCompraAPrazo: decimal.Parse(txtLimiteCompraPrazo.Text),
                    observacao: txtObservacoes.Text,
                    endereco: InstanciarEnderecoParaCadastro(),
                    telefones: InstanciarTelefonesParaCadastro()
                    );
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);               
            }
        }

        private EnderecoModel InstanciarEnderecoParaCadastro()
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

        private List<TelefoneModel> InstanciarTelefonesParaCadastro()
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

        private bool VerificarValidacoesDeCliente()
        {
            bool validacoes = true;

            if (!decimal.TryParse(txtLimiteCompraPrazo.Text, out _))
            {
                validacoes = false;
                MessageBox.Show("Limite de compra a prazo inválido.");
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
