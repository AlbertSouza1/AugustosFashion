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
                listaColaboradores = new ColaboradorRepositorio().ListarColaboradores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao listar colaboradores. Erro: " + ex.Message);
            }
            return listaColaboradores;
        }

        public void ExcluirCliente(int idColaborador)
        {
            try
            {
                new ColaboradorRepositorio().ExcluirColaborador(idColaborador);
                MessageBox.Show("Colaborador excluído com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao excluir colaborador. Erro: " + ex.Message);
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
    }
}
