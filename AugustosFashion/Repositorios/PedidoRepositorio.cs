using AugustosFashion.Helpers;
using AugustosFashionModels.Entidades.Pedidos;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace AugustosFashion.Repositorios
{
    internal static class PedidoRepositorio
    {
        public static void CadastrarPedido(PedidoModel pedido)
        {
            var strSqlPedido = @"Insert into Pedidos (IdCliente, IdColaborador, FormaPagamento, DataEmissao, TotalBruto, TotalDesconto, TotalLiquido)  
                output inserted.IdPedido 
                values (@IdCliente, @IdColaborador, @FormaPagamento, @DataEmissao, @TotalBruto, @TotalDesconto, @TotalLiquido)";

            var strSqlPedidoProduto = @"insert into Pedido_Produto (IdPedido, IdProduto, PrecoVenda, Quantidade, Desconto, PrecoLiquido, Total)
                values (@IdPedido, @IdProduto, @PrecoVenda, @Quantidade, @Desconto, @PrecoLiquido, @Total) ";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    using(SqlTransaction transaction = sqlCon.BeginTransaction())
                    {
                        pedido.IdPedido = sqlCon.ExecuteScalar<int>(strSqlPedido, pedido, transaction);

                        pedido.Produtos.ForEach(x => x.IdPedido = pedido.IdPedido);

                        sqlCon.Execute(strSqlPedidoProduto, pedido.Produtos, transaction);

                        transaction.Commit();
                    }                   
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<PedidoListagem> ListarPedidos()
        {
            var strSqlPedidos = @"select 
	            p.IdPedido, p.DataEmissao, (select Nome from nome_cliente where IdCliente = p.IdCliente) as NomeCliente,
	            (select Nome from nome_colaborador where IdColaborador = p.IdColaborador) as NomeColaborador,
	            p.FormaPagamento, p.TotalBruto, p.TotalDesconto, p.TotalLiquido
                from Pedidos p
                ";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    return sqlCon.Query<PedidoListagem>(
                        strSqlPedidos                                             
                     ).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
