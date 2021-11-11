using AugustosFashion.Entidades;
using AugustosFashion.Views.Pedidos;

namespace AugustosFashion.Controllers.Pedidos
{
    public class CadastroPedidoController
    {
        internal void AbrirFormCadastroPedidos()
        {
            var frmCadastroPedido = new FrmCadastraPedido(this);
            frmCadastroPedido.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            frmCadastroPedido.Show();
        }
    }
}
