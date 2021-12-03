using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using System.Text;

namespace AugustosFashion.Repositorios.QueryHelpers
{
    public static class RelatorioVendaProdutoHelper
   {
        public static string GerarQueryRelatorio(FiltroRelatorioVendaProduto filtroRelatorio)
        {
            var query = new StringBuilder();

            var pedidoProdutoAlias = "pp";
            var pedidoAlias = "pe";
            var clienteAlias = "c";
            var produtoAlias = "pr";

            var totalCusto = $" SUM({pedidoProdutoAlias}.Quantidade * {pedidoProdutoAlias}.PrecoCusto) ";
            var totalLiquido = $" SUM({pedidoProdutoAlias}.Total) ";

            var select = $@" SELECT
                        {produtoAlias}.Nome, SUM({pedidoProdutoAlias}.Quantidade) as QuantidadeVendida,
                        {totalCusto} as TotalCusto, SUM({pedidoProdutoAlias}.PrecoVenda * {pedidoProdutoAlias}.Quantidade) as TotalBruto,
                        SUM({pedidoProdutoAlias}.Quantidade * {pedidoProdutoAlias}.Desconto) as TotalDesconto,
                        {totalLiquido} as TotalLiquido, {totalLiquido} - {totalCusto} as LucroReais ";

            var from = $" FROM Pedido_Produto {pedidoProdutoAlias} ";

            var joins = $@" INNER JOIN Pedidos {pedidoAlias} on {pedidoAlias}.IdPedido = {pedidoProdutoAlias}.IdPedido
				INNER JOIN Produtos {produtoAlias} on {pedidoProdutoAlias}.IdProduto = {produtoAlias}.IdProduto
				INNER JOIN Clientes {clienteAlias} on {clienteAlias}.IdCliente = {pedidoAlias}.IdCliente ";

            var where = new StringBuilder($"WHERE {pedidoAlias}.DataEmissao BETWEEN @DataInicial and @DataFinal + ' 23:59' and ");

            var groupBy = $"GROUP BY {pedidoProdutoAlias}.IdProduto, {produtoAlias}.Nome ";


            if(filtroRelatorio.IdCliente != 0)
            {
                where.AppendLine($"{pedidoAlias}.IdCliente = @IdCliente and ");
            }
            if(filtroRelatorio.IdProduto != 0)
            {
                where.AppendLine($"{pedidoProdutoAlias}.IdProduto = @IdProduto and ");
            }

            where.Remove(where.Length - 4, 4);

            query.AppendLine(select);
            query.AppendLine(from);
            query.AppendLine(joins);
            query.AppendLine(where.ToString());
            query.AppendLine(groupBy);

            return query.ToString();
        }
    }
}
