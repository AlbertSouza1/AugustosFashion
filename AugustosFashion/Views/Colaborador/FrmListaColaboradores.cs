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
    }
}
