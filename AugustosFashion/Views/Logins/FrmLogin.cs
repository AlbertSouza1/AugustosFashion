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

            try
            {
                _loginController.LogarUsuario(usuarioSistemaModel);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private UsuarioSistemaModel InstanciarUsuarioParaLogar()
        {
            return new UsuarioSistemaModel(
                nomeUsuario: txtNomeUsuario.Text,
                senha: txtSenha.Text
            );           
        }

        private void lblRegistrar_Click(object sender, EventArgs e)
        {
            new RegistraUsuarioController().AbrirFormDeRegistro();
        }
    }
}
