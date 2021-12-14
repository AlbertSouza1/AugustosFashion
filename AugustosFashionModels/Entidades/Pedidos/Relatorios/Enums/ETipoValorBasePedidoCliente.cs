using System.ComponentModel;

namespace AugustosFashionModels.Entidades.Pedidos.Relatorios.Enums
{
    public enum ETipoValorBasePedidoCliente
    {
        [Description(" sum(p.TotalLiquido) > 0 ")]
        NenhumFiltro,
        [Description(" count(p.IdPedido) > @ValorBase ")]
        TotalCompras,
        [Description(" sum(p.TotalBruto) > @ValorBase ")]
        TotalBruto,
        [Description(" sum(p.TotalLiquido) > @ValorBase ")]
        TotalLíquido,
        [Description(" sum(p.TotalDesconto) > @ValorBase ")]
        TotalDesconto
    }
}
