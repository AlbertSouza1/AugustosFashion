using AugustosFashion.Repositorios;
using AugustosFashion.Repositorios.QueryHelpers;
using AugustosFashion.Views.Logins;
using AugustosFashionModels.Entidades.UsuariosSistema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashion.Controllers.Logins
{
    public class RegistraUsuarioController
    {
        public void AbrirFormDeRegistro()
        {
            var frmRegistrar = new FrmRegistrar(this);
            frmRegistrar.ShowDialog();
        }

        public bool VerificarSeIdColaboradorEhValido(int idColaborador) =>
            UsuarioSistemaRepositorio.VerificarIdColaborador(idColaborador);

        public void RegistrarUsuario(UsuarioSistemaModel usuarioSistemaModel)
        {           
            usuarioSistemaModel.CriptografarSenha(CriptografiaRepositorio.RetornarChave());

            UsuarioSistemaRepositorio.RegistrarUsuario(usuarioSistemaModel);
        }
    }
}
