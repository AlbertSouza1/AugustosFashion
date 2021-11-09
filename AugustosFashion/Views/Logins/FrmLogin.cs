using AugustosFashion.Controllers.Logins;
using AugustosFashion.Entidades;
using AugustosFashionModels.Entidades.UsuariosSistema;
using System;
using System.Windows.Forms;

namespace AugustosFashion.Views.Logins
{
    public partial class FrmLogin : Form
    {
        private readonly LoginController _loginController;
        public FrmLogin(LoginController loginController)
        {
            InitializeComponent();
            _loginController = loginController;
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            Logar();          
        }

        private void Logar()
        {
            var usuarioSistemaModel = InstanciarUsuarioParaLogar();

            if (_loginController.LogarUsuario(usuarioSistemaModel))
                AbrirSistema();
            else
                MessageBox.Show("Nome de usuário ou senha inválidos.");
        }

        private void AbrirSistema()
        {
            var MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            MdiParent.ShowDialog();

            this.Close();
        }

        private UsuarioSistemaModel InstanciarUsuarioParaLogar()
        {
            return new UsuarioSistemaModel(
                nomeUsuario: txtNomeUsuario.Text,
                senha: txtSenha.Text
            );           
        }
    }
}
