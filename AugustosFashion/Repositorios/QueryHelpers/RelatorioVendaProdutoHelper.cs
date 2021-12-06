using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using Dapper;

namespace AugustosFashion.Repositorios.QueryHelpers
{
    public class RelatorioVendaProdutoHelper
   {
        private readonly FiltroRelatorioVendaProduto _filtroRelatorio;

        public RelatorioVendaProdutoHelper(FiltroRelatorioVendaProduto filtroRelatorio)
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

            var where = $" WHERE pe.DataEmissao BETWEEN @DataInicial and @DataFinal + ' 23:59' ";

            if(_filtroRelatorio.IdCliente != 0)
            {
                where +=$" and pe.IdCliente = @IdCliente ";
            }
            if(_filtroRelatorio.IdProduto != 0)
            {
                where += $" and pp.IdProduto = @IdProduto and ";
            }

            query += where;

            query += $" GROUP BY pp.IdProduto, pr.Nome ";

            return query;
        }

        public DynamicParameters RecuperarParametros()
        {
            var parameters = new DynamicParameters();

            parameters.AddDynamicParams(
                new
                {
                    _filtroRelatorio.DataInicial,
                    _filtroRelatorio.DataFinal,
                    _filtroRelatorio.IdProduto,
                    _filtroRelatorio.IdCliente
                }
                );

            return parameters;
        }
    }
}
