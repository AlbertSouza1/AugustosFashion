using AugustosFashion.Entidades;
using AugustosFashion.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashion.Controllers
{
    public class CadastroClienteController
    {
        public void AbrirFormularioCadastro()
        {
            var frmCadastroCliente = new FrmCadastroCliente(this);
            frmCadastroCliente.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();

            frmCadastroCliente.Show();
        }
    }
}
