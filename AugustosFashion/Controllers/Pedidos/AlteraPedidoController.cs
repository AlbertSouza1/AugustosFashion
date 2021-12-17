using AugustosFashion.Controllers.ServicosEmail;
using AugustosFashion.Repositorios;
using AugustosFashionModels.Entidades.Pedidos;
using System;

namespace AugustosFashion.Controllers.Pedidos
{
    public class AlteraPedidoController
    {
        public string AlterarPedido(PedidoModel pedido)
        {

            if (pedido.FormaPagamento == EFormaPagamento.Aprazo)
            {
                if (!pedido.VerificarSeClientePossuiLimite())
                    return $"O limite de compra a prazo disponível do cliente é de {pedido.Cliente.RetornarLimiteParaNovaCompra():c}.\n\n" +
                      "Selecione uma nova forma de pagamento.";
            }

            PedidoRepositorio.AlterarPedido(pedido);
            return string.Empty;
        }

        public int RecuperarEstoqueDoProduto(int idProduto)
        {
            return ProdutoRepositorio.RecuperarEstoqueDoProduto(idProduto);
        }

        internal int RecuperarQuantidadePreviamenteVendida(int idProduto, int idPedido)
        {
            return PedidoRepositorio.RecuperarQuantidadePreviamenteVendida(idProduto, idPedido);
        }

        internal void EnviarEmailAlteracaoPedido(PedidoModel pedido)
        {
            new ServicoEmailController().PrepararEmailAlteracaoPedido(pedido.Cliente, pedido);
        }
    }
}