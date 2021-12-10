using AugustosFashion.Entidades;
using AugustosFashion.Views.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashion.Controllers.Cliente
{  
    public class BuscaClienteController
    {
        private FrmBuscaClientes _frmBuscaCliente;

        public BuscaClienteController()
        {
            _frmBuscaCliente = new FrmBuscaClientes();
        }
        public void AbrirFormBuscaCliente()
        {
            _frmBuscaCliente = new FrmBuscaClientes();
            _frmBuscaCliente.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            _frmBuscaCliente.Show();
            _frmBuscaCliente.BringToFront();
        }

        public FrmBuscaClientes RetornarFrmBuscaCliente() => _frmBuscaCliente;
    }
}
