using AugustosFashion.Controllers.Colaborador;
using AugustosFashion.Entidades.Colaborador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AugustosFashion.Views.Colaborador
{
    public partial class FrmListaColaboradores : Form
    {
        private readonly ListaColaboradorController _listaColaboradorController;
        public FrmListaColaboradores(ListaColaboradorController listaColaboradorController)
        {
            InitializeComponent();
            _listaColaboradorController = listaColaboradorController;
        }

        private void FrmListaColaboradores_Load(object sender, EventArgs e)
        {
            ListarColaboradores();
        }

        private void ListarColaboradores()
        {
            List<ColaboradorListagem> listaColaboradores = _listaColaboradorController.ListarColaboradores();

            dgvColaboradores.DataSource = listaColaboradores;

            dgvColaboradores.Columns[0].HeaderText = "Código";
        }

        private void btnVisualizarColaborador_Click(object sender, EventArgs e)
        {
            if (VerificarSeHaRegistroSelecionado())
            {
                int id = RecuperarIdColaboradorSelecionado();

                _listaColaboradorController.VisualizarColaborador(id);
            }
            else
            {
                MessageBox.Show("Selecione um cliente na tabela para excluir", "Aviso");
            }
        }
        private int RecuperarIdColaboradorSelecionado()
        {
            int id = Convert.ToInt32(dgvColaboradores.SelectedRows[0].Cells[0].Value);
            return id;
        }
        private bool VerificarSeHaRegistroSelecionado() =>
           dgvColaboradores.SelectedRows.Count == 0 ? false : true;
    }
}
