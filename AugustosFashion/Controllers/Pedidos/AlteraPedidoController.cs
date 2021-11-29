using AugustosFashion.Repositorios;
using AugustosFashionModels.Entidades.Pedidos;
using System;

namespace AugustosFashion.Controllers.Pedidos
{
    public class AlteraPedidoController
    {
        public void AlterarPedido(PedidoModel pedido)
        {
            try
            {
                PedidoRepositorio.AlterarPedido(pedido);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int RecuperarEstoqueDoProduto(int idProduto)
        {
            return ProdutoRepositorio.RecuperarEstoqueDoProduto(idProduto);
        }

        internal int RecuperarQuantidadePreviamenteVendida(int idProduto, int idPedido)
        {
            return PedidoRepositorio.RecuperarQuantidadePreviamenteVendida(idProduto, idPedido);
        }
    }
}
