using AugustosFashion.Controllers.Cliente;
using AugustosFashion.Entidades.Cliente;
using AugustosFashion.Entidades.Endereco;
using AugustosFashion.Entidades.Telefone;
using AugustosFashion.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AugustosFashion.Views
{
    public partial class FrmAlterarCliente : Form
    {
        int idCelular;
        int idFixo;

        private readonly AlteraClienteController _alteraClienteController;
        public FrmAlterarCliente(AlteraClienteController alteraClienteController)
        {
            InitializeComponent();
            _alteraClienteController = alteraClienteController;
        }

        private void FrmAlterarCliente_Load(object sender, EventArgs e)
        {

        }

        public void ObterDadosParaAlteracao(ClienteModel cliente)
        {
            foreach (var tel in cliente.Telefones)
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

            txtIdCliente.Text = cliente.IdCliente.ToString();
            txtObservacoes.Text = cliente.Observacao;
            txtLimiteCompraPrazo.Text = cliente.LimiteCompraAPrazo.ToString();

            txtNome.Text = cliente.NomeCompleto.Nome;
            txtSobreNome.Text = cliente.NomeCompleto.SobreNome;
            txtEmail.Text = cliente.Email;
            cbSexo.SelectedIndex = SexoIndexComboBoxHelper.RetornarIndexComboBoxSexoCadastrado(cliente.Sexo);
            dtpDataNascimento.Value = cliente.DataNascimento;
            mtxtCpf.Text = cliente.CPF;

            txtLogradouro.Text = cliente.Endereco.Logradouro;
            txtCidade.Text = cliente.Endereco.Cidade;
            txtComplemento.Text = cliente.Endereco.Complemento;
            txtBairro.Text = cliente.Endereco.Bairro;
            txtNumero.Text = cliente.Endereco.Numero.ToString();
            txtCep.Text = cliente.Endereco.CEP;
            cbUf.SelectedIndex = EstadoIndexHelper.RetornarIndexComboBoxUfCadastrado(cliente.Endereco.UF);
        }

        private void btnAlterarCliente_Click(object sender, EventArgs e)
        {
            var cpfSemPontos = RemoveMaskCpf.RemoverMaskCpf(mtxtCpf.Text);

            if (VerificarValidacoesDeCliente(cpfSemPontos))
            {
                var cliente = InstanciarClienteParaCadastro();

                try
                {
                    _alteraClienteController.AlterarCliente(cliente);
                    MessageBox.Show("Cliente alterado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha ao altear cliente. Erro: " + ex.Message);
                }
            }
        }
        public ClienteModel InstanciarClienteParaCadastro()
        {
            var cpfSemPontos = RemoveMaskCpf.RemoverMaskCpf(mtxtCpf.Text);

            ClienteModel cliente = new ClienteModel
            (
                nome: txtNome.Text,
                sobreNome: txtSobreNome.Text,
                sexo: cbSexo.SelectedItem.ToString() == "Masculino" ? 'm' : 'f',
                dataNascimento : dtpDataNascimento.Value,
                email: txtEmail.Text,
                cpf: cpfSemPontos,
                limiteCompraAPrazo: double.Parse(txtLimiteCompraPrazo.Text),
                observacao: txtObservacoes.Text,
                endereco: InstanciarEnderecoParaCadastro(),
                telefones: InstanciarTelefonesParaCadastro()
            );
            cliente.IdCliente = int.Parse(txtIdCliente.Text);

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
                IdTelefone = idCelular,
                Numero = txtCelular.Text
            };
            var fixo = new TelefoneModel
            {
                IdTelefone = idFixo,
                Numero = txtTelefoneFixo.Text
            };

            var telefones = new List<TelefoneModel>();

            telefones.Add(celular);
            telefones.Add(fixo);

            return telefones;
        }

        private bool VerificarValidacoesDeCliente(string cpf)
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
            else if (!ValidarCamposDeCliente())
                validacoes = false;
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

        private void btnExcluirCliente_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Você está prestes a excluir este cliente. Deseja prosseguir com esta ação?", "Confirmação",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int id = int.Parse(txtIdCliente.Text);

                    _alteraClienteController.ExcluirCliente(id);

                    MessageBox.Show("Cliente excluído com sucesso!");

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha ao excluir cliente. Erro: " + ex.Message);
                }
            }

        }
    }
}

