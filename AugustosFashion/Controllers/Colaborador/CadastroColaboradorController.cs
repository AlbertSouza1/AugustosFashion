using AugustosFashion.Entidades;
using AugustosFashion.Entidades.Colaborador;
using AugustosFashion.Repositorios;
using AugustosFashion.Views;
using System;

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
        public string CadastrarColaborador(ColaboradorModel colaborador)
        {
            try
            {
                var retorno = colaborador.ValidarColaborador();

                if (string.IsNullOrEmpty(retorno))
                {
                    ColaboradorRepositorio.CadastrarColaborador(colaborador);
                }

                return retorno;             
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
    }
}
