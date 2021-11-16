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
        internal void AbrirFormListaPedidos()
        {
            var frmListaPedido = new FrmListaPedidos(this);
            frmListaPedido.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            frmListaPedido.Show();
        }

        internal List<PedidoListagem> ListarPedidos()
        {
            try
            {
                return PedidoRepositorio.ListarPedidos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
