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

            var strSqlPedidoProduto = @"insert into Pedido_Produto (IdPedido, IdProduto, PrecoVenda, PrecoCusto, Quantidade, Desconto, PrecoLiquido, Total)
                values (@IdPedido, @IdProduto, @PrecoVenda, @PrecoCusto, @Quantidade, @Desconto, @PrecoLiquido, @Total) ";

            var strSqlEstoqueProduto = @"update Produtos set Estoque = Estoque - @Quantidade where IdProduto = @IdProduto";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    using (SqlTransaction transaction = sqlCon.BeginTransaction())
                    {
                        pedido.IdPedido = sqlCon.ExecuteScalar<int>(strSqlPedido,
                        new
                        {
                            pedido.IdCliente,
                            pedido.IdColaborador,
                            pedido.FormaPagamento,
                            pedido.DataEmissao,
                            TotalBruto = pedido.TotalBruto.RetornaValor,
                            TotalDesconto = pedido.TotalDesconto.RetornaValor,
                            TotalLiquido = pedido.TotalLiquido.RetornaValor,

                        },
                            transaction);

                        pedido.Produtos.ForEach(x => x.IdPedido = pedido.IdPedido);

                        foreach (var x in pedido.Produtos)
                        {
                            sqlCon.Execute(strSqlPedidoProduto,
                            new
                            {
                                x.IdPedido,
                                x.IdProduto,
                                PrecoVenda = x.PrecoVenda.RetornaValor,
                                PrecoCusto = x.PrecoCusto.RetornaValor,
                                x.Quantidade,
                                Desconto = x.Desconto.RetornaValor,
                                PrecoLiquido = x.PrecoLiquido.RetornaValor,
                                Total = x.Total.RetornaValor

                            }, transaction);
                        }

                        foreach (var item in pedido.Produtos)
                        {
                            sqlCon.Execute(strSqlEstoqueProduto, new { Quantidade = item.Quantidade, IdProduto = item.IdProduto }, transaction);
                        }

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
            var strSqlPedido = @"select  p.IdPedido, concat(u.Nome,' ',u.SobreNome) as NomeCliente,
				concat(u2.Nome, ' ', u2.SobreNome) as NomeColaborador,
				p.DataEmissao,p.FormaPagamento, p.TotalBruto, p.TotalDesconto, p.TotalLiquido, p.Lucro
				from Pedidos p
				inner join Colaboradores as co on p.IdColaborador = co.IdColaborador
				inner join Clientes as c on p.IdCliente = c.IdCliente				
				inner join Usuarios u on u.IdUsuario = c.IdUsuario
				inner join Usuarios u2 on u2.IdUsuario = co.IdUsuario
                ";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    return sqlCon.Query<PedidoListagem>(
                        strSqlPedido
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
