using AugustosFashion.Controllers.Controls;
using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AugustosFashion.Views.Pedidos.Relatorios
{
    public partial class UcDgvLista : UserControl
    {
        private List<ListaGenericaModel> _lista;
        private readonly UcDgvListaController _controller;

        public delegate void SelectedGridHandler(int id);

        public event SelectedGridHandler SelectedGrid;

        public UcDgvLista(UcDgvListaController controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        public void AtualizarLista(List<ListaGenericaModel> lista)
        {
            _lista = lista;

            dgvLista.DataSource = null;
            dgvLista.DataSource = _lista;
        }

        private void UcDgvLista_Load(object sender, EventArgs e)
        {
            
        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            int id = Convert.ToInt32(dgvLista.SelectedRows[0].Cells[0].Value);

            SelectedGrid?.Invoke(id);
        }
    }
}
