using AugustosFashionModels.Entidades.Pedidos.Relatorios.Filtros;
using Dapper;
using EnumsNET;
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
            var query = $@" SELECT
                        pr.Nome, SUM(pp.Quantidade) as QuantidadeVendida,
                        SUM(pp.Quantidade * pp.PrecoCusto) as TotalCusto,
                        SUM(pp.PrecoVenda * pp.Quantidade) as TotalBruto,
                        SUM(pp.Quantidade * pp.Desconto) as TotalDesconto
                        FROM Pedido_Produto pp 
                        INNER JOIN Pedidos pe on pe.IdPedido = pp.IdPedido
				        INNER JOIN Produtos pr on pp.IdProduto = pr.IdProduto	";

            var where = $" WHERE pe.DataEmissao BETWEEN @DataInicial and @DataFinal and pe.Eliminado = 0";

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

        private string GerarOrderBys() => _filtroRelatorio.Ordenacao.AsString(EnumFormat.Description);    

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
