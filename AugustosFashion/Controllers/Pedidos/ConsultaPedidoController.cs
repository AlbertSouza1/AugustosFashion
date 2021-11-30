using AugustosFashion.Controllers.Cliente;
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
            var pedido = ConsultarPedido(idPedido);

            var frmConsultaPedido = new FrmConsultaPedido(this, pedido);
            frmConsultaPedido.MdiParent = MDIParentSingleton.InstanciarFrmMdiParent();
            frmConsultaPedido.Show();
        }

        public PedidoModel ConsultarPedido(int id)
        {
            try
            {
                var pedido = PedidoRepositorio.ConsultarPedido(id);
                pedido.Produtos = PedidoRepositorio.ListarProdutosDoPedido(id);
                pedido.Cliente = new AlteraClienteController().RecuperarInformacoesCliente(pedido.Cliente.IdCliente);
                return pedido;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AlterarPedido(PedidoModel pedido)
        {
            var cadastroPedidoController = new CadastroPedidoController();

            cadastroPedidoController.AbrirFormCadastroPedidoParaEdicao(pedido);
        }

        public void EliminarPedido(PedidoModel pedido)
        {
            try
            {
                PedidoRepositorio.EliminarPedido(pedido);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
