using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using Dapper;
using System.Linq;
using System.Text;

namespace AugustosFashion.Repositorios.QueryHelpers
{
    public class RelatorioPedidoClienteHelper
    {
        private readonly FiltroRelatorioPedidoCliente _filtroRelatorio;

        public RelatorioPedidoClienteHelper(FiltroRelatorioPedidoCliente filtroRelatorioVendaCliente)
        {
            _filtroRelatorio = filtroRelatorioVendaCliente;
        }
        public string GerarFiltrosWhere()
        {
            var where = new StringBuilder($" WHERE p.DataEmissao BETWEEN @DataInicial and @DataFinal ");

            if (_filtroRelatorio.Clientes.Count > 0)
            {
                where.Append($" AND p.IdCliente IN @IdsClientes");
            }

            return where.ToString();
        }

        public string GerarFiltroTop()
        {
            var top = "";

            if (_filtroRelatorio.QuantidadeResultados > 0)
                top = " top(@QuantidadeResultados)";

            return top;
        }

        public string GerarFiltrosHaving()
        {
            var having = "having ";

            switch (_filtroRelatorio.TipoValorBase)
            {
                case ETipoValorBasePedidoCliente.TotalDesconto:
                    having += "sum(p.TotalDesconto) > @ValorBase ";
                    break;
                case ETipoValorBasePedidoCliente.TotalBruto:
                    having += "sum(p.TotalBruto) > @ValorBase ";
                    break;
                case ETipoValorBasePedidoCliente.TotalLíquido:
                    having += "sum(p.TotalLiquido) > @ValorBase ";
                    break;
                case ETipoValorBasePedidoCliente.TotalCompras:
                    having += "count(p.IdPedido) > @ValorBase ";
                    break;
                default:
                    having = "";
                    break;
            }

            return having;
        }

        public DynamicParameters RecuperarParametros()
        {
            var parameters = new DynamicParameters();

            parameters.AddDynamicParams(
                new
                {
                    IdsClientes = _filtroRelatorio.Clientes.Select(x => x.Id).ToList(),
                    _filtroRelatorio.DataInicial,
                    DataFinal = _filtroRelatorio.DataFinalFormatada,
                    _filtroRelatorio.Clientes,
                    _filtroRelatorio.ValorBase,
                    _filtroRelatorio.QuantidadeResultados
                }
                );

            return parameters;
        }

        public string GerarOrderBys()
        {
            var orderBy = " order by ";

            switch (_filtroRelatorio.Ordenacao)
            {
                case EOrdenacaoPedidoCliente.MenosComprou:
                    orderBy += " count(p.IdPedido) ";
                    break;
                case EOrdenacaoPedidoCliente.MaiorDesconto:
                    orderBy += " sum(p.TotalDesconto) desc";
                    break;
                case EOrdenacaoPedidoCliente.MenorDesconto:
                    orderBy += " sum(p.TotalDesconto) ";
                    break;
                case EOrdenacaoPedidoCliente.MaiorValor:
                    orderBy += " sum(p.TotalLiquido) desc ";
                    break;
                case EOrdenacaoPedidoCliente.MenorValor:
                    orderBy += " sum(p.TotalLiquido) ";
                    break;
                default:
                    orderBy += " count(p.IdPedido) desc ";
                    break;
            }
            return orderBy;
        }
    }
}
