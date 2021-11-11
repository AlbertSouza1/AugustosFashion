using AugustosFashion.Entidades;
using AugustosFashion.Views.Pedidos;

namespace AugustosFashion.Controllers.Pedidos
{
    public class ListaPedidoController
    {
        internal void AbrirFormListaPedidos()
        {
            var frmListaPedido = new FrmListaPedidos(this);
            frmListaPedido.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            frmListaPedido.Show();
        }
    }
}
