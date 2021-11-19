using AugustosFashion.Entidades;
using AugustosFashion.Repositorios;
using AugustosFashion.Views.Pedidos;
using AugustosFashionModels.Entidades.Pedidos;
using System;

namespace AugustosFashion.Controllers.Pedidos
{
    public class ConsultaPedidoController
    {
        public void AbrirFormConsultaPedido(int idPedido)
        {
            var frmConsultaPedido = new FrmConsultaPedido(this, ConsultarPedido(idPedido));
            frmConsultaPedido.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            frmConsultaPedido.Show();
        }

        public PedidoModel ConsultarPedido(int id)
        {
            try
            {
                var pedido = PedidoRepositorio.ConsultarPedido(id);
                pedido.Produtos = PedidoRepositorio.ListarProdutosDoPedido(id);

                return pedido;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AlterarPedido()
        {

        }
    }
}
