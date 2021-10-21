using AugustosFashion.Controllers.Colaborador;
using AugustosFashion.Entidades.Colaborador;
using AugustosFashion.Entidades.ContaBancaria;
using AugustosFashion.Entidades.Endereco;
using AugustosFashion.Entidades.Telefone;
using AugustosFashion.Entidades.Usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            cbSexo.SelectedIndex = usuario.Sexo == 'm' ? 0 : 1;
            dtpDataNascimento.Value = usuario.DataNascimento;
            mtxtCpf.Text = usuario.CPF;

            txtLogradouro.Text = endereco.Logradouro;
            txtCidade.Text = endereco.Cidade;
            txtComplemento.Text = endereco.Complemento;
            txtBairro.Text = endereco.Bairro;
            txtNumero.Text = endereco.Numero.ToString();
            txtCep.Text = endereco.CEP;
            cbUf.SelectedIndex = 0;

            txtBanco.Text = contaBancaria.Banco;
            txtConta.Text = contaBancaria.Conta.ToString();
            txtAgencia.Text = contaBancaria.Agencia.ToString();
            cbTipoConta.SelectedIndex = 1/*contaBancaria.Conta*/;

        }
    }
}
