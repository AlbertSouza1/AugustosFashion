using AugustosFashion.Views.Pedidos.Relatorios;
using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AugustosFashion.Controllers.Controls
{
    public class UcDgvListaController
    {
        private UcDgvLista _control;

        public UcDgvListaController()
        {
            _control = new UcDgvLista();
        }

        public void AbrirControl(Panel panelListaClientes)
        {
            panelListaClientes.Controls.Add(_control);
            panelListaClientes.Tag = _control;

            panelListaClientes.BringToFront();
            panelListaClientes.Visible = true;            
        }

        public void AtualizarGrid(List<ListaGenericaModel> lista) => _control.AtualizarLista(lista);

        public UcDgvLista RetornarUserControl() => _control;
    }
}
