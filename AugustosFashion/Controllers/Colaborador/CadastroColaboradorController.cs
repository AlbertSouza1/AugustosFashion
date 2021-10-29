﻿using AugustosFashion.Entidades;
using AugustosFashion.Entidades.Colaborador;
using AugustosFashion.Entidades.ContaBancaria;
using AugustosFashion.Entidades.Endereco;
using AugustosFashion.Entidades.Telefone;
using AugustosFashion.Repositorios;
using AugustosFashion.Views;
using System;
using System.Collections.Generic;

namespace AugustosFashion.Controllers
{
    public class CadastroColaboradorController
    {
        public void AbrirFormCadastroColaborador()
        {
            var frmCadastroColaborador = new FrmCadastroColaboradores(this);
            frmCadastroColaborador.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();

            frmCadastroColaborador.Show();
        }
        public bool CadastrarColaborador(ColaboradorModel colaborador)
        {
            try
            {
                ColaboradorRepositorio.CadastrarColaborador(colaborador);              
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
    }
}
