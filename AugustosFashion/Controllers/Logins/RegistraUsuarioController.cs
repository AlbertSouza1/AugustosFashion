﻿using AugustosFashion.Repositorios;
using AugustosFashion.Repositorios.QueryHelpers;
using AugustosFashion.Views.Logins;
using AugustosFashionModels.Entidades.UsuariosSistema;

namespace AugustosFashion.Controllers.Logins
{
    public class RegistraUsuarioController
    {
        private FrmRegistrar _frmRegistrar;

        public void AbrirFormDeRegistro()
        {
            _frmRegistrar = new FrmRegistrar(this);
            _frmRegistrar.ShowDialog();
        }

        public bool VerificarSeLoginJaExiste(string login) =>
            UsuarioSistemaRepositorio.VerificarSeLoginJaExiste(login);

        public void RegistrarUsuario(UsuarioSistemaModel usuarioSistemaModel)
        {           
            usuarioSistemaModel.CriptografarSenha(CriptografiaRepositorio.RetornarChave());

            UsuarioSistemaRepositorio.RegistrarUsuario(usuarioSistemaModel);
        }
    }
}
