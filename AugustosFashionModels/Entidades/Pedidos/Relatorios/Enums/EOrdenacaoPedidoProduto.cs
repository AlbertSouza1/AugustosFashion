using System.ComponentModel;

namespace AugustosFashionModels.Entidades.Pedidos.Relatorios.Enums
{
    public enum EOrdenacaoPedidoProduto
    {
        [Description(" order by pr.Nome ")]
        Nenhuma,
        [Description(" order by QuantidadeVendida desc ")]
        MaisComprado,
        [Description(" order by QuantidadeVendida ")]
        MenosComprado,
        [Description(" order by TotalDesconto desc ")]
        MaisDesconto,
        [Description(" order by TotalDesconto ")]
        MenosDesconto,
        [Description(" order by SUM(pp.Total) desc ")]
        MaisReaisVendido,
        [Description(" order by SUM(pp.Total) ")]
        MenosReaisVendido,
    }
}
