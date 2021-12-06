using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var where = new StringBuilder($" WHERE p.DataEmissao BETWEEN @DataInicial and @DataFinal + ' 23:59' ");

            if (_filtroRelatorio.IdCliente != 0)
            {
                where.Append($"and p.IdCliente = @IdCliente");
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
            var having = "";

            if(_filtroRelatorio.ValorComprado > 0)
                having = $" having sum(p.TotalLiquido) > @ValorComprado ";

            return having;
        }

        public DynamicParameters RecuperarParametros()
        {
            var parameters = new DynamicParameters();

            parameters.AddDynamicParams(
                new
                {
                    _filtroRelatorio.DataInicial,
                    _filtroRelatorio.DataFinal,
                    _filtroRelatorio.IdCliente,
                    _filtroRelatorio.ValorComprado,
                    _filtroRelatorio.QuantidadeResultados
                }
                );

            return parameters;
        }

        public string GerarOrderBys()
        {
            var orderBy = "";

            switch(_filtroRelatorio.Ordenacao)
            {
                case EOrdenacaoPedidoCliente.MaisComprou:
                    orderBy = " order by count(p.IdPedido) desc ";
                    break;
                case EOrdenacaoPedidoCliente.MenosComprou:
                    orderBy = " order by count(p.IdPedido) ";
                    break;
                case EOrdenacaoPedidoCliente.MaiorDesconto:
                    orderBy = " order by sum(p.TotalDesconto) desc";
                    break;
                case EOrdenacaoPedidoCliente.MenorDesconto:
                    orderBy = " order by sum(p.TotalDesconto) ";
                    break;
                case EOrdenacaoPedidoCliente.MaiorValor:
                    orderBy = " order by sum(p.TotalLiquido) desc ";
                    break;
                case EOrdenacaoPedidoCliente.MenorValor:
                    orderBy = " order by sum(p.TotalLiquido) ";
                    break;
            }
            return orderBy;
        }
    }
}
