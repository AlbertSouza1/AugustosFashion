using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashion.Repositorios.QueryHelpers
{
    public  class RelatorioVendaProdutoHelper
    {
        private readonly FiltroRelatorioVendaProduto _filtroRelatorio;

        private readonly string queryFiltroProduto = " pp.IdProduto = @IdProduto";
        private readonly string queryFiltroCliente = " pp.IdProduto = @IdProduto";

        private string query = @"
				SELECT
				pr.Nome, SUM(pp.Quantidade) as QuantidadeVendida, SUM(pp.Quantidade * pp.PrecoCusto) as TotalCusto,
				SUM(pp.PrecoVenda * pp.Quantidade) as TotalBruto,
				SUM(pp.Quantidade * pp.Desconto) as TotalDesconto, SUM(pp.Total) as TotalLiquido,
				SUM(pp.Total) - sum(pp.Quantidade * pp.PrecoCusto) as LucroReais				
				FROM 
				Pedido_Produto pp INNER JOIN Pedidos pe on pe.IdPedido = pp.IdPedido
				INNER JOIN Produtos pr on pp.IdProduto = pr.IdProduto
				INNER JOIN Clientes c on c.IdCliente = pe.IdCliente

                WHERE pe.DataEmissao BETWEEN @DataInicial and @DataFinal + ' 23:59'

				GROUP BY pr.Nome--, pe.IdCliente, pp.PrecoCusto, pp.PrecoVenda
                ORDER BY SUM(pp.Quantidade) DESC";

        public RelatorioVendaProdutoHelper(FiltroRelatorioVendaProduto filtroRelatorio)
        {
            _filtroRelatorio = filtroRelatorio;
        }

        public string RetornarFiltroProduto()
        {
            if (_filtroRelatorio.IdProduto == 0)
                return "";
            else
                return queryFiltroProduto;
        }

        public string RetornarFiltroCliente()
        {
            if (_filtroRelatorio.IdCliente == 0)
                return "";
            else
                return queryFiltroCliente;
        }
    }
}
