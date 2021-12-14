using System.ComponentModel;

namespace AugustosFashionModels.Entidades.Pedidos.Relatorios.Enums
{
    public enum EOrdenacaoPedidoCliente
    {
        [Description(" order by u.Nome")]
        Nenhuma,
        [Description(" order by count(p.IdPedido) desc ")]
        MaisComprou,
        [Description(" order by count(p.IdPedido) ")]
        MenosComprou,
        [Description(" order by sum(p.TotalDesconto) desc ")]
        MaiorDesconto,
        [Description(" order by sum(p.TotalDesconto) ")]
        MenorDesconto,
        [Description(" order by sum(p.TotalLiquido) desc ")]
        MaiorValor,
        [Description(" order by sum(p.TotalLiquido) ")]
        MenorValor,
    }
}
