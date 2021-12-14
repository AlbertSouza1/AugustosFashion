using AugustosFashion.Controllers;
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
        private readonly ClienteModel _cliente;

        private readonly AlteraClienteController _alteraClienteController;
        public FrmAlterarCliente(AlteraClienteController alteraClienteController, ClienteModel cliente)
        {
            InitializeComponent();
            _alteraClienteController = alteraClienteController;
            _cliente = cliente;
        }

        public void ObterDadosParaAlteracao()
        {
            foreach (var tel in _cliente.Telefones)
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

            txtObservacoes.Text = _cliente.Observacao;
            txtLimiteCompraPrazo.Text = _cliente.LimiteCompraAPrazo.RetornaValor.ToString();
            txtLimiteDisponivel.Text = _cliente.RetornarLimiteParaNovaCompra().ToString();

            txtNome.Text = _cliente.NomeCompleto.Nome;
            txtSobreNome.Text = _cliente.NomeCompleto.SobreNome;
            txtEmail.Text = _cliente.Email.RetornaValor;
            cbSexo.SelectedIndex = SexoIndexComboBoxHelper.RetornarIndexComboBoxSexoCadastrado(_cliente.Sexo);
            dtpDataNascimento.Value = _cliente.DataNascimento;
            mtxtCpf.Text = _cliente.CPF.ValorFormatado;

            txtLogradouro.Text = _cliente.Endereco.Logradouro;
            txtCidade.Text = _cliente.Endereco.Cidade;
            txtComplemento.Text = _cliente.Endereco.Complemento;
            txtBairro.Text = _cliente.Endereco.Bairro;
            txtNumero.Text = _cliente.Endereco.Numero.ToString();
            mtxtCep.Text = _cliente.Endereco.CEP.RetornaValor;
            cbUf.SelectedIndex = EstadoIndexHelper.RetornarIndexComboBoxUfCadastrado(_cliente.Endereco.UF);
            
            

            var avisoDeAniversario = _cliente.VerificarSeEhAniversarioDoCliente();
            if (avisoDeAniversario != string.Empty)
                MessageBox.Show(avisoDeAniversario, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAlterarCliente_Click(object sender, EventArgs e)
        {
            if (VerificarValidacoesDeCliente())
            {
                InstanciarClienteParaCadastro();

                try
                {
                    var retorno = _alteraClienteController.AlterarCliente(_cliente);

                    if (string.IsNullOrEmpty(retorno))
                        MessageBox.Show("Cliente alterado com sucesso!");
                    else
                        MessageBox.Show(retorno);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha ao altear cliente. Erro: " + ex.Message);
                }
            }
        }
        public void InstanciarClienteParaCadastro()
        {
            _cliente.NomeCompleto.Nome = txtNome.Text;
            _cliente.NomeCompleto.SobreNome = txtSobreNome.Text;
            _cliente.Sexo = cbSexo.SelectedItem.ToString() == "Masculino" ? 'm' : 'f';
            _cliente.DataNascimento = dtpDataNascimento.Value;
            _cliente.Email = txtEmail.Text;
            _cliente.CPF = mtxtCpf.Text;
            _cliente.LimiteCompraAPrazo = decimal.Parse(txtLimiteCompraPrazo.Text);
            _cliente.Observacao = txtObservacoes.Text;
            _cliente.Endereco = InstanciarEnderecoParaCadastro();
            _cliente.Telefones = InstanciarTelefonesParaCadastro();

            _cliente.Endereco.CEP.RemoverMascara();
            _cliente.CPF.RemoverMascara();
        }

        public EnderecoModel InstanciarEnderecoParaCadastro()
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

        private bool VerificarValidacoesDeCliente()
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
                    _alteraClienteController.ExcluirCliente(_cliente.IdCliente);

                    MessageBox.Show("Cliente excluído com sucesso!");

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha ao excluir cliente. Erro: " + ex.Message);
                }
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmAlterarCliente_Load(object sender, EventArgs e)
        {
            ObterDadosParaAlteracao();
        }

        private void btnInativar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Você está prestes a inativar este cliente. Deseja prosseguir com esta ação?", "Confirmação",
                MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _alteraClienteController.InativarCliente(_cliente.IdCliente);

                    MessageBox.Show("Cliente inativado com sucesso!");

                    this.Close();
                    new ListaClienteController().AbrirFormularioLista();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha ao inativar cliente. Erro: " + ex.Message);
                }
            }
        }
    }
}

