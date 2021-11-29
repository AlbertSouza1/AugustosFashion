using AugustosFashion.Entidades;
using AugustosFashion.Repositorios;
using AugustosFashion.Views.Pedidos;
using AugustosFashionModels.Entidades.Pedidos;
using System;
using System.Collections.Generic;

namespace AugustosFashion.Controllers.Pedidos
{
    public class ListaPedidoController
    {
        public void AbrirFormListaPedidos()
        {
            var frmListaPedido = new FrmListaPedidos(this);
            frmListaPedido.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            frmListaPedido.Show();
        }

        public List<PedidoListagem> ListarPedidos(List<DateTime> data, bool eliminado) => PedidoRepositorio.ListarPedidos(data, eliminado);
    }
}
