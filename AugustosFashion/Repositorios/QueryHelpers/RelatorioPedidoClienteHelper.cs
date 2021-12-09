using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using Dapper;
using EnumsNET;
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

            having += _filtroRelatorio.TipoValorBase.AsString(EnumFormat.Description);

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

        public string GerarOrderBys() => _filtroRelatorio.Ordenacao.AsString(EnumFormat.Description);
    }
}
