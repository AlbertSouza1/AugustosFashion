using AugustosFashionModels.Entidades.Dinheiros;
using System.ComponentModel;

namespace AugustosFashionModels.Entidades.Pedidos.Relatorios
{
    public class RelatorioVendaProduto
    {
        [DisplayName("Produto")]
        public string Nome { get; set; }

        [DisplayName("Vezes Vendido")]
        public int QuantidadeVendida { get; set; }

        [DisplayName("Total Custo")]
        public Dinheiro TotalCusto { get; set; }

        [DisplayName("Total Bruto")]
        public Dinheiro TotalBruto { get; set; }

        [DisplayName("Total Desconto")]
        public Dinheiro TotalDesconto { get; set; }

        [DisplayName("Total Líquido")]
        public Dinheiro TotalLiquido { get; set; }

        [DisplayName("Lucro (R$)")]
        public Dinheiro LucroReais { get; set; }

        [DisplayName("Lucro (%)")]
        public string LucroPorcentagem 
        { 
            get  
            {
                var result = LucroReais.RetornaValor / TotalCusto.RetornaValor * 100;
                return  $"{result.ToString("F")} %";                
            }  
        }
    }
}
