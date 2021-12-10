using AugustosFashion.Repositorios;
using AugustosFashionModels.Entidades.Pedidos;
using System;

namespace AugustosFashion.Controllers.Pedidos
{
    public class AlteraPedidoController
    {
        public string AlterarPedido(PedidoModel pedido)
        {
            try
            {
                if (pedido.FormaPagamento == EFormaPagamento.Aprazo)
                {
                    if (pedido.VerificarSeClientePossuiLimite())
                    {
                        PedidoRepositorio.AlterarPedido(pedido);
                        return string.Empty;
                    }
                    return "O limite de compra a prazo do cliente será ultrapassado com esta compra.\n\n" +
                       "Selecione uma nova forma de pagamento.";
                }

                PedidoRepositorio.AlterarPedido(pedido);
                return string.Empty;
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
