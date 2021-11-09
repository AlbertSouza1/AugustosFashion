using AugustosFashion.Views.Logins;
using AugustosFashionModels.Entidades.UsuariosSistema;
using System;

namespace AugustosFashion.Controllers.Logins
{
    public class LoginController
    {
        public FrmLogin AbrirFormLogin()
        {
            return new FrmLogin(this);
        }
        public bool LogarUsuario(UsuarioSistemaModel usuarioSistema)
        {
            try
            {
                //var retorno = UsuarioSistemaRepositorio.Logar();
                //if(retorno)
                //return usuarioSistema;
                //else
                //return new UsuarioSistemaModel();

                if (string.IsNullOrWhiteSpace(usuarioSistema.NomeUsuario) || string.IsNullOrWhiteSpace(usuarioSistema.Senha))
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
