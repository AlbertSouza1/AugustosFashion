﻿using AugustosFashion.Entidades.Colaborador;
using AugustosFashion.Repositorios;
using AugustosFashion.Repositorios.QueryHelpers;
using AugustosFashion.Views.Logins;
using AugustosFashion.Views.Pedidos;
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

        public bool VerificarSeIdColaboradorEhValido(int idColaborador) =>
            UsuarioSistemaRepositorio.VerificarIdColaborador(idColaborador);

        public void RegistrarUsuario(UsuarioSistemaModel usuarioSistemaModel)
        {           
            usuarioSistemaModel.CriptografarSenha(CriptografiaRepositorio.RetornarChave());

            UsuarioSistemaRepositorio.RegistrarUsuario(usuarioSistemaModel);
        }

        public void RecuperarColaboradorSelecionado(ColaboradorListagem colaborador)
        {
            _frmRegistrar.ObterColaboradorSelecionado(colaborador);
        }

        public void AbrirFormBuscaColaborador()
        {
            var frmBuscaColaborador = new FrmBuscaColaborador(this, string.Empty);
            frmBuscaColaborador.ShowDialog();
        }
    }
}
