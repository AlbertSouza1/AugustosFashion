using AugustosFashion.Controllers.Cliente;
using AugustosFashion.Controllers.Logins;
using AugustosFashion.Entidades.Cliente;
using AugustosFashion.Entidades.Colaborador;
using AugustosFashionModels.Entidades.UsuariosSistema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AugustosFashion.Views.Logins
{
    public partial class FrmRegistrar : Form
    {
        private readonly RegistraUsuarioController _registraUsuarioController;
        private ColaboradorListagem _colaborador;

        public FrmRegistrar(RegistraUsuarioController registraUsuarioController)
        {
            InitializeComponent();
            _registraUsuarioController = registraUsuarioController;
            _colaborador = new ColaboradorListagem();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            if(!_registraUsuarioController.VerificarSeIdColaboradorEhValido(_colaborador.IdColaborador))
            {
                MessageBox.Show("Colaborador não encontrado. Verifique o código inserido e tente novamente.");
                return;
            }
            try
            {                
                _registraUsuarioController.RegistrarUsuario(InstanciarUsuarioSistema());

                MessageBox.Show("Conta criada com sucesso.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível registrar o usuário no sistema. Erro: " + ex.Message);
            }
        }

        public void ObterColaboradorSelecionado(ColaboradorListagem colaborador)
        {
            _colaborador = colaborador;

            txtIdColaborador.Text = $"{colaborador.NomeCompleto.Nome} {colaborador.NomeCompleto.SobreNome}";
        }

        private bool ValidarCampos()
        {
            if(string.IsNullOrWhiteSpace(txtNomeUsuario.Text)){               
                MessageBox.Show("É necessário informar o código de colaborador do usuário.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtNomeUsuario.Text) || string.IsNullOrWhiteSpace(txtNomeUsuario.Text))
            {
                MessageBox.Show("É necessário informar um nome de usuário.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSenha.Text) || string.IsNullOrWhiteSpace(txtNomeUsuario.Text))
            {
                MessageBox.Show("É necessário informar uma senha.");
                return false;
            }
            return true;
        }

        private UsuarioSistemaModel InstanciarUsuarioSistema()
        {
            return new UsuarioSistemaModel(
                idColaborador: int.Parse(txtIdColaborador.Text),
                nomeUsuario: txtNomeUsuario.Text,
                senha: txtSenha.Text
                );       
        }

        private void btnSelecionarColaborador_Click(object sender, EventArgs e)
        {
            _registraUsuarioController.AbrirFormBuscaColaborador();
        }
    }
}
