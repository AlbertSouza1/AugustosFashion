using AugustosFashion.Entidades;
using AugustosFashion.Entidades.Colaborador;
using AugustosFashion.Repositorios;
using AugustosFashion.Views.Colaborador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AugustosFashion.Controllers.Colaborador
{
    public class ListaColaboradorController
    {
        public void AbrirFormularioLista()
        {
            var frmListaColaboradores = new FrmListaColaboradores(this);
            frmListaColaboradores.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            frmListaColaboradores.Show();
        }

        public List<ColaboradorListagem> ListarColaboradores()
        {
            var listaColaboradores = new List<ColaboradorListagem>();

            try
            {
                listaColaboradores = ColaboradorRepositorio.ListarColaboradores();
                return listaColaboradores;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        internal void VisualizarColaborador(int id)
        {
            AbrirFormularioVisualizacaoColaborador(id);
        }

        public void AbrirFormularioVisualizacaoColaborador(int id)
        {
            new ConsultaColaboradorController().AbrirFormConsultaColaborador(id);
        }

        public List<ColaboradorListagem> BuscarColaboradoresPorNome(string nomeBuscado)
        {
            try
            {
                var colaboradoresBuscados = ColaboradorRepositorio.BuscarColaboradores(nomeBuscado);
                return colaboradoresBuscados;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
