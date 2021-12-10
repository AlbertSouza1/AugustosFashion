using AugustosFashion.Repositorios;
using AugustosFashion.Repositorios.QueryHelpers;
using AugustosFashion.Views.Logins;
using AugustosFashionModels.Entidades.UsuariosSistema;
using System;
using System.Windows.Forms;

namespace AugustosFashion.Controllers.Logins
{
    public class LoginController
    {
        private readonly Form _frmLogin;

        public LoginController()
        {
            _frmLogin = new FrmLogin(this);
        }

        public Form RetornarFormLogin() => _frmLogin;
        public void LogarUsuario(UsuarioSistemaModel usuarioSistema)
        {
            usuarioSistema.CriptografarSenha(CriptografiaRepositorio.RetornarChave());

            if (UsuarioSistemaRepositorio.VerificarLogin(usuarioSistema) > 0)
            {
                _frmLogin.DialogResult = DialogResult.OK;
                return;
            }

            throw new Exception("Login ou senha inválidos.");
        }
    }
}
