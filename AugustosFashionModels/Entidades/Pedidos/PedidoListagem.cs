using AugustosFashionModels.Entidades.Dinheiros;
using AugustosFashionModels.Entidades.NomesCompletos;
using System;
using System.ComponentModel;
using EnumsNET;

namespace AugustosFashionModels.Entidades.Pedidos
{
    public class PedidoListagem
    {
        [DisplayName("Código")]
        public int IdPedido { get; set; }

        [DisplayName("Data de Emissão")]
        public DateTime DataEmissao { get; set; }

        [DisplayName("Cliente")]
        public NomeCompleto NomeCliente { get; set; }

        [DisplayName("Colaborador")]
        public NomeCompleto NomeColaborador { get; set; }
        [Browsable(false)]
        public EFormaPagamento FormaPagamento { get; set; }
        [DisplayName("Forma de Pagamento")]
        public string FormaPagamentoDescription { get => FormaPagamento.AsString(EnumFormat.Description); }

        [DisplayName("Total Bruto")]
        public Dinheiro TotalBruto { get; set; }

        [DisplayName("Total de Desconto")]
        public Dinheiro TotalDesconto { get; set; }

        [DisplayName("Total Líquido")]
        public Dinheiro TotalLiquido { get; set; }
        public Dinheiro Lucro { get; set; }
    }
}
