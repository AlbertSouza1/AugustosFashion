using AugustosFashion.Entidades;
using AugustosFashion.Repositorios;
using AugustosFashion.Views.Pedidos;
using AugustosFashionModels.Entidades.Pedidos;

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

        internal void CadastrarPedido(PedidoModel pedido)
        {
            PedidoRepositorio.CadastrarPedido(pedido);
        }
    }
}
