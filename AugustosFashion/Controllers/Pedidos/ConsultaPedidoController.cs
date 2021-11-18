using AugustosFashion.Entidades;
using AugustosFashion.Views.Pedidos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashion.Controllers.Pedidos
{
    public class ConsultaPedidoController
    {
        public void AbrirFormConsultaPedido()
        {
            var frmConsultaPedido = new FrmConsultaPedido(this);
            frmConsultaPedido.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            frmConsultaPedido.Show();
        }
    }
}
