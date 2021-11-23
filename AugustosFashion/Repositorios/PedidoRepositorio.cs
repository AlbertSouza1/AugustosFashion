using AugustosFashion.Helpers;
using AugustosFashionModels.Entidades.Pedidos;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace AugustosFashion.Repositorios
{
    public static class PedidoRepositorio
    {
        public static void CadastrarPedido(PedidoModel pedido)
        {
            var strSqlPedido = @"Insert into Pedidos (IdCliente, IdColaborador, FormaPagamento, DataEmissao, TotalBruto, TotalDesconto, TotalLiquido)  
                output inserted.IdPedido 
                values (@IdCliente, @IdColaborador, @FormaPagamento, @DataEmissao, @TotalBruto, @TotalDesconto, @TotalLiquido)";

            var strSqlPedidoProduto = @"insert into Pedido_Produto (IdPedido, IdProduto, PrecoVenda, PrecoCusto, Quantidade, 
                Desconto, PrecoLiquido, Total)
                values (@IdPedido, @IdProduto, @PrecoVenda, @PrecoCusto, @Quantidade, @Desconto, @PrecoLiquido, @Total) ";          

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

                        SubtrairEstoqueDosProdutos(sqlCon, transaction, pedido.Produtos);

                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static void SubtrairEstoqueDosProdutos(SqlConnection sqlCon, SqlTransaction transaction, List<PedidoProduto> produtos)
        {
            try
            {
                var strSqlEstoqueProduto = @"update Produtos set Estoque = Estoque - @Quantidade where IdProduto = @IdProduto";

                foreach (var item in produtos)
                {
                    sqlCon.Execute(strSqlEstoqueProduto, new { Quantidade = item.Quantidade, IdProduto = item.IdProduto }, transaction);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void AlterarPedido(PedidoModel pedido)
        {
            var strSelectQuantidadeAntigaProdutos = @"SELECT IdProduto, Quantidade from Pedido_Produto where IdPedido = @IdPedido";

            var strDeleteProdutosDoPedido = @"DELETE FROM Pedido_Produto WHERE IdPedido = @IdPedido";
            var strVoltaEstoqueProdutos = @"UPDATE Produtos SET Estoque = Estoque + @Quantidade WHERE IdProduto = @IdProduto";
            var strInsereNovosProdutos = @"INSERT INTO Pedido_Produto (IdPedido, IdProduto, PrecoVenda, PrecoCusto, Quantidade, 
                Desconto, PrecoLiquido, Total)
                VALUES (@IdPedido, @IdProduto, @PrecoVenda, @PrecoCusto, @Quantidade, @Desconto, @PrecoLiquido, @Total)";

            var strAtualizaPedido = @"UPDATE Pedidos SET FormaPagamento = @FormaPagamento,
                DataEmissao = @DataEmissao, TotalBruto = @TotalBruto, TotalDesconto = @TotalDesconto, TotalLiquido = @TotalLiquido
                WHERE IdPedido = @IdPedido";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    using (SqlTransaction transaction = sqlCon.BeginTransaction())
                    {
                        pedido.Produtos.ForEach(x => x.IdPedido = pedido.IdPedido);

                        List<PedidoProduto> produtosPreAlteracao = sqlCon.Query<PedidoProduto>(
                        strSelectQuantidadeAntigaProdutos, new { pedido.IdPedido }, transaction
                        ).ToList();

                        foreach (var x in produtosPreAlteracao)
                        {
                            sqlCon.Execute(strVoltaEstoqueProdutos,
                            new
                            {
                                Quantidade = x.Quantidade,
                                IdProduto = x.IdProduto
                            }, transaction);
                        }

                        sqlCon.Execute(strDeleteProdutosDoPedido, new { IdPedido = pedido.IdPedido }, transaction);

                        foreach (var x in pedido.Produtos)
                        {
                            sqlCon.Execute(strInsereNovosProdutos,
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

                        SubtrairEstoqueDosProdutos(sqlCon, transaction, pedido.Produtos);

                        sqlCon.ExecuteScalar<int>(strAtualizaPedido,
                            new
                            {
                                pedido.FormaPagamento,
                                pedido.DataEmissao,
                                TotalBruto = pedido.TotalBruto.RetornaValor,
                                TotalDesconto = pedido.TotalDesconto.RetornaValor,
                                TotalLiquido = pedido.TotalLiquido.RetornaValor,
                                pedido.IdPedido
                            },
                            transaction);

                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<PedidoProduto> ListarProdutosDoPedido(int id)
        {
            var strSqlPedido = @"select p.IdPedido, p.IdProduto, p.PrecoVenda, pro.Nome, pro.Fabricante,
                p.Quantidade, p.Desconto, p.PrecoLiquido, p.Total, p.PrecoCusto							
				from Pedido_Produto p
                inner join Produtos pro on p.IdProduto = pro.IdProduto
                where IdPedido = @id				
                ";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    return sqlCon.Query<PedidoProduto>(
                        strSqlPedido, new { id }
                     ).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static PedidoModel ConsultarPedido(int id)
        {
            var strSqlPedido = @"select IdPedido, IdCliente, IdColaborador,			
				DataEmissao, FormaPagamento, TotalBruto, TotalDesconto, TotalLiquido, Lucro
				from Pedidos where IdPedido = @id				
                ";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    return sqlCon.Query<PedidoModel>(
                        strSqlPedido, new { id }
                     ).FirstOrDefault();
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

            var strSqlRecuperaLucro = @"SELECT (SUM(Total) - SUM(PrecoCusto * Quantidade)) as Lucro
                FROM Pedido_Produto WHERE IdPedido = @IdPedido group by IdPedido";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    var pedidos = sqlCon.Query<PedidoListagem>(
                        strSqlPedido
                     ).ToList();

                    foreach (var pedido in pedidos)
                    {
                        pedido.Lucro = sqlCon.Query<decimal>(strSqlRecuperaLucro, new {IdPedido = pedido.IdPedido}).FirstOrDefault();
                    }

                    return pedidos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
