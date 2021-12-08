using AugustosFashionModels.Entidades.Dinheiros;
using System.Collections.Generic;
using System.Linq;

namespace AugustosFashionModels.Entidades.Pedidos.Relatorios
{
    public class RelatorioPedidoClienteViewModel
    {
        public RelatorioPedidoClienteViewModel()
        {
            Relatorio = new List<RelatorioPedidoCliente>();
        }
        public List<RelatorioPedidoCliente> Relatorio { get; set; }
        public int TotalCompras { get => Relatorio.Sum(x=> x.QuantidadeCompras); }
        public Dinheiro TotalBruto { get => Relatorio.Sum(x => x.TotalBruto.RetornaValor); }
        public Dinheiro TotalDesconto { get => Relatorio.Sum(x => x.TotalDesconto.RetornaValor); }
        public Dinheiro TotalLiquido { get => Relatorio.Sum(x => x.TotalLiquido.RetornaValor); }
    }
}
