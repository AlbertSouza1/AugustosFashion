using AugustosFashion.Entidades;
using AugustosFashion.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashion.Controllers
{
    public class ListaClienteController
    {
        public void AbrirFormularioLista()
        {
            var frmListaCliente = new FrmListaClientes(this);
            frmListaCliente.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            frmListaCliente.Show();
        }
    }
}
