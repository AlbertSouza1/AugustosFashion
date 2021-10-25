using AugustosFashion.Controllers.Cliente;
using AugustosFashion.Entidades.Cliente;
using AugustosFashion.Entidades.Endereco;
using AugustosFashion.Entidades.Telefone;
using AugustosFashion.Entidades.Usuario;
using AugustosFashion.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void ObterDadosParaAlteracao(ClienteConsulta cliente, UsuarioConsulta usuario, EnderecoModel endereco, List<TelefoneModel> telefones)
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

            txtIdCliente.Text = cliente.IdCliente.ToString();
            txtObservacoes.Text = cliente.Observacao;
            txtLimiteCompraPrazo.Text = cliente.ValorLimiteCompraAPrazo;

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
        }

        private void btnAlterarCliente_Click(object sender, EventArgs e)
        {
            var cpfSemPontos = RemoveMaskCpf.RemoverMaskCpf(mtxtCpf.Text);

            if (VerificarValidacoesDeCliente(cpfSemPontos))
            {
                var cliente = InstanciarClienteParaCadastro();
                var endereco = InstanciarEnderecoParaCadastro();
                var telefones = InstanciarTelefonesParaCadastro();

                _alteraClienteController.AlterarCliente(cliente, endereco, telefones);
            }
        }
        public ClienteModel InstanciarClienteParaCadastro()
        {
            var cpfSemPontos = RemoveMaskCpf.RemoverMaskCpf(mtxtCpf.Text);

            ClienteModel cliente = new ClienteModel {
                IdCliente = int.Parse(txtIdCliente.Text),
                Nome = txtNome.Text,
                SobreNome = txtSobreNome.Text,
                Sexo = cbSexo.SelectedItem.ToString() == "Masculino" ? 'm' : 'f',
                DataNascimento = dtpDataNascimento.Value,
                Email = txtEmail.Text,
                CPF = cpfSemPontos,
                LimiteCompraAPrazo = double.Parse(txtLimiteCompraPrazo.Text),
                Observacao = txtObservacoes.Text
                };

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
    }
}
