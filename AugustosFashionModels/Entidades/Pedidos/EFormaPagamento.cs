using System.ComponentModel;

namespace AugustosFashionModels.Entidades.Pedidos
{
    public enum EFormaPagamento
    {
        [Description("À vista no dinheiro")]
        AVistaDinheiro,
        [Description("A prazo")]
        Aprazo,
        [Description("Crédito")]
        Credito,
        [Description("Débito")]
        Debito,
        [Description("Pix")]
        Pix
    }
}
