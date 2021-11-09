using AugustosFashion.Views.Logins;
using AugustosFashionModels.Entidades.UsuariosSistema;
using System;
using System.Windows.Forms;

namespace AugustosFashion.Controllers.Logins
{
    public class LoginController
    {
        private readonly Form _frmLogin;
        //private readonly UsuarioSistemaRepositorio _loginRepositorio;

        public LoginController()
        {
            _frmLogin = new FrmLogin(this);
        }
        //public DialogResult AbrirFormLogin()
        //{
        //    var frm = new FrmLogin(this);

        //    frm.ShowDialog();

        //    return DialogResult.None;
        //}

        public Form RetornarFormLogin() => _frmLogin;
        public void LogarUsuario(UsuarioSistemaModel usuarioSistema)
        {
            try
            {
                //var retorno = UsuarioSistemaRepositorio.Logar();
                //if(retorno)
                //return usuarioSistema;
                //else
                //return new UsuarioSistemaModel();

                if (string.IsNullOrWhiteSpace(usuarioSistema.NomeUsuario) || string.IsNullOrWhiteSpace(usuarioSistema.Senha))
                    MessageBox.Show("Login invalido");
                else
                {
                    _frmLogin.DialogResult = DialogResult.OK;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
