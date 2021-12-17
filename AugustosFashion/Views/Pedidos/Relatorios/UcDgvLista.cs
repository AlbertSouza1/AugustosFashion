using AugustosFashion.Controllers.Controls;
using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace AugustosFashion.Views.Pedidos.Relatorios
{
    public partial class UcDgvLista : UserControl
    {
        private BindingList<ListaGenericaModel> _lista { get; set; } = new BindingList<ListaGenericaModel>();

        public delegate void SelectedGridHandler(int id);

        public event SelectedGridHandler SelectedGrid;

        public UcDgvLista()
        {
            InitializeComponent();
        }

        public void AtualizarLista(BindingList<ListaGenericaModel> lista)
        {           
             _lista = lista;

            dgvLista.DataSource = null;
            dgvLista.DataSource = _lista;
        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {         
            if(e.ColumnIndex == -1)
            {
                return;
            }
            try
            {
                if (e.RowIndex == -1)
                {                  
                    return;
                }

                int id = Convert.ToInt32(dgvLista.SelectedRows[0].Cells[0].Value);

                SelectedGrid?.Invoke(id);
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvLista_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
        }
    }
}
