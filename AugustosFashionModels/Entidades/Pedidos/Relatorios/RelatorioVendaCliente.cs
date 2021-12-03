using AugustosFashionModels.Entidades.Dinheiros;
using AugustosFashionModels.Entidades.NomesCompletos;
using System.ComponentModel;

namespace AugustosFashionModels.Entidades.Pedidos.Relatorios
{
    public class RelatorioVendaCliente
    {
        [DisplayName("Nome")]
        public NomeCompleto NomeCompleto { get; set; }

        [DisplayName("Quantidade Compras")]
        public int QuantidadeCompras { get; set; }

        [DisplayName("Total Bruto")]
        public Dinheiro TotalBruto { get; set; }

        [DisplayName("Total Desconto")]
        public Dinheiro TotalDesconto { get; set; }

        [DisplayName("Total Líquido")]
        public Dinheiro TotalLiquido { get; set; }
    }
}
