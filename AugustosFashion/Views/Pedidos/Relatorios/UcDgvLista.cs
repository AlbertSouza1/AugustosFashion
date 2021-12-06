using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AugustosFashion.Views.Pedidos.Relatorios
{
    public partial class UcDgvLista : UserControl
    {
        private List<ListaGenericaModel> _lista;
        public UcDgvLista()
        {
            InitializeComponent();
        }

        public void AtualizarLista(List<ListaGenericaModel> lista)
        {
            _lista = lista;

            dgvLista.DataSource = _lista;
        }

        private void UcDgvLista_Load(object sender, EventArgs e)
        {
            
        }
    }
}
