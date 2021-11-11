using AugustosFashion.Helpers;
using AugustosFashionModels.Entidades.Pedidos;
using Dapper;
using System;
using System.Data.SqlClient;

namespace AugustosFashion.Repositorios
{
    internal class PedidoRepositorio
    {
        public static void CadastrarPedido(PedidoModel pedido)
        {
            var strSqlPedido = "Insert into Pedidos (IdCliente, IdColaborador, FormaPagamento, DataEmissao, TotalBruto, TotalDesconto, TotalLiquido) " +
                "values (@IdCliente, @IdColaborador, @FormaPagamento, @DataEmissao, @TotalBruto, @TotalDesconto, @TotalLiquido)";

            var strSqlPedidoProduto = @"insert into Pedido_Produto (IdPedido, IdProduto, Quantidade, Desconto, PrecoLiquido, Total)
                values (@IdPedido, @IdProduto, @Quantidade, @Desconto, @PrecoLiquido, @Total) ";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    using(SqlTransaction transaction = sqlCon.BeginTransaction())
                    {
                        pedido.IdPedido = sqlCon.ExecuteScalar<int>(strSqlPedido, pedido, transaction);

                        sqlCon.Execute(strSqlPedidoProduto, pedido.Produtos, transaction);
                    }                   
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
