using AugustosFashionModels.Entidades.Pedidos;
using System.Collections.Generic;

namespace AugustosFashionModelsTest.PedidosTestes
{
    public static class PedidoModelMock
    {
        public static List<PedidoProduto> RetornarPedidoProdutos()
        {
            return new List<PedidoProduto>()
        {
            new PedidoProduto(){
                IdProduto = 1,
                PrecoVenda = 3,
                PrecoCusto = 1,
                Quantidade = 3,
                Desconto = 1
            },
            new PedidoProduto(){
                IdProduto = 2,
                PrecoVenda = 4,
                PrecoCusto = 1,
                Quantidade = 5,
                Desconto = 2
            },
        };
        }

        public static List<PedidoProduto> RetornarProdutosDeValoresAltos()
        {
            return new List<PedidoProduto>()
        {
            new PedidoProduto(){
                IdProduto = 1,
                PrecoVenda = 1000,
                PrecoCusto = 200,
                Quantidade = 3,
                Desconto = 100
            },
            new PedidoProduto(){
                IdProduto = 2,
                PrecoVenda = 2000,
                PrecoCusto = 500,
                Quantidade = 5,
                Desconto = 50
            },
        };
        }
    }
}
