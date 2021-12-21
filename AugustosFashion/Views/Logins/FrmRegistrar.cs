using AugustosFashion.Controllers.Colaborador;
using AugustosFashion.Controllers.Logins;
using AugustosFashion.Entidades.Colaborador;
using AugustosFashionModels.Entidades.UsuariosSistema;
using System;
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

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            if(_registraUsuarioController.VerificarSeLoginJaExiste(txtNomeUsuario.Text))
            {
                MessageBox.Show("Este nome de usuário já existe.");
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

        private bool ValidarCampos()
        {
            if(string.IsNullOrWhiteSpace(txtIdColaborador.Text)){               
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
            var usuario = new UsuarioSistemaModel(
                idColaborador: _colaborador.IdColaborador,
                nomeUsuario: txtNomeUsuario.Text,
                senha: txtSenha.Text
                );
            return usuario;
        }

        private void BtnSelecionarColaborador_Click(object sender, EventArgs e)
        {
            var buscaColaboradorController = new BuscaColaboradorController();
            buscaColaboradorController.AbrirFormBuscaColaboradorSemMdi();
            buscaColaboradorController.RetornarFrmBuscaColaborador().SelectedColaborador += FrmRegistrar_SelectedColaborador;
        }

        private void FrmRegistrar_SelectedColaborador(ColaboradorListagem colaborador)
        {
            _colaborador = colaborador;

            txtIdColaborador.Text = $"{_colaborador.NomeCompleto.Nome} {_colaborador.NomeCompleto.SobreNome}";
        }
    }
}
