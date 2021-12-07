using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using Dapper;
using System.Linq;

namespace AugustosFashion.Repositorios.QueryHelpers
{
    public class RelatorioPedidoProdutoHelper
   {
        private readonly FiltroRelatorioPedidoProduto _filtroRelatorio;

        public RelatorioPedidoProdutoHelper(FiltroRelatorioPedidoProduto filtroRelatorio)
        {
            _filtroRelatorio = filtroRelatorio;
        }
        public string GerarQueryRelatorio()
        {
            var totalCusto = $" SUM(pp.Quantidade * pp.PrecoCusto) ";
            var totalLiquido = $" SUM(pp.Total) ";

            var query = $@" SELECT
                        pr.Nome, SUM(pp.Quantidade) as QuantidadeVendida,
                        {totalCusto} as TotalCusto, SUM(pp.PrecoVenda * pp.Quantidade) as TotalBruto,
                        SUM(pp.Quantidade * pp.Desconto) as TotalDesconto,
                        {totalLiquido} as TotalLiquido, {totalLiquido} - {totalCusto} as LucroReais
                        FROM Pedido_Produto pp 
                        INNER JOIN Pedidos pe on pe.IdPedido = pp.IdPedido
				        INNER JOIN Produtos pr on pp.IdProduto = pr.IdProduto	";

            var where = $" WHERE pe.DataEmissao BETWEEN @DataInicial and @DataFinal ";

            if(_filtroRelatorio.Clientes.Count > 0)
            {
                where +=$" and pe.IdCliente in @IdClientes ";
            }
            if(_filtroRelatorio.Produtos.Count > 0)
            {
                where += $" and pp.IdProduto in @IdProdutos ";
            }

            query += where;

            query += $" GROUP BY pp.IdProduto, pr.Nome ";

            query += GerarOrderBys();

            return query;
        }

        private string GerarOrderBys()
        {
            var orderBy = " order by ";

            switch (_filtroRelatorio.Ordenacao)
            {
                case EOrdenacaoPedidoProduto.MenosComprado:
                    orderBy += " QuantidadeVendida ";
                    break;
                case EOrdenacaoPedidoProduto.MaisDesconto:
                    orderBy += " TotalDesconto desc";
                    break;
                case EOrdenacaoPedidoProduto.MenosDesconto:
                    orderBy += " TotalDesconto ";
                    break;
                case EOrdenacaoPedidoProduto.MaisReaisVendido:
                    orderBy += " TotalLiquido desc ";
                    break;
                case EOrdenacaoPedidoProduto.MenosReaisVendido:
                    orderBy += " TotalLiquido ";
                    break;
                default:
                    orderBy += " QuantidadeVendida desc ";
                    break;
            }
            return orderBy;
        }

        public DynamicParameters RecuperarParametros()
        {
            var parameters = new DynamicParameters();

            parameters.AddDynamicParams(
                new
                {
                    _filtroRelatorio.DataInicial,
                    DataFinal = _filtroRelatorio.DataFinalFormatada,
                    IdProdutos = _filtroRelatorio.Produtos.Select(x => x.Id),
                    IdClientes = _filtroRelatorio.Clientes.Select(x=>x.Id)
                }
                );

            return parameters;
        }
    }
}
