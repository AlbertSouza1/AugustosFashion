using AugustosFashion.Views.Pedidos.Relatorios;
using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public void AtualizarGrid(List<ListaGenericaModel> lista)
        {
            var bindingList = new BindingList<ListaGenericaModel>(lista);
            _control.AtualizarLista(bindingList);
        }

        public UcDgvLista RetornarUserControl() => _control;
    }
}
