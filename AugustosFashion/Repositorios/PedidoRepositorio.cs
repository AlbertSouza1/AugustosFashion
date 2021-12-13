using AugustosFashion.Entidades.Cliente;
using AugustosFashion.Helpers;
using AugustosFashionModels.Entidades.NomesCompletos;
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
                            pedido.Cliente.IdCliente,
                            pedido.IdColaborador,
                            pedido.FormaPagamento,
                            pedido.DataEmissao,
                            TotalBruto = pedido.TotalBruto.RetornaValor,
                            TotalDesconto = pedido.TotalDesconto.RetornaValor,
                            TotalLiquido = pedido.TotalLiquido.RetornaValor,

                        },
                            transaction);

                        pedido.Produtos.ForEach(x => x.IdPedido = pedido.IdPedido);

                        CadastrarProdutosDoPedido(sqlCon, transaction, pedido.Produtos);

                        SubtrairEstoqueDosProdutos(sqlCon, transaction, pedido.Produtos);

                        if (pedido.FormaPagamento == EFormaPagamento.Aprazo)
                            ContaClienteRepositorio.CadastrarContaDeCliente(sqlCon, transaction, pedido);

                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void AlterarPedido(PedidoModel pedido)
        {
            var strSelectQuantidadeAntigaProdutos = @"SELECT IdProduto, Quantidade from Pedido_Produto where IdPedido = @IdPedido";
            var strSelectAntigaFormaDePagamento = @"SELECT FormaPagamento FROM Pedidos where IdPedido = @IdPedido";
            var strDeleteProdutosDoPedido = @"DELETE FROM Pedido_Produto WHERE IdPedido = @IdPedido";
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

                        var antigaFormaPagamento = sqlCon.Query<int>(
                            strSelectAntigaFormaDePagamento, new { pedido.IdPedido }, transaction
                            ).FirstOrDefault();

                        if (pedido.FormaPagamento == EFormaPagamento.Aprazo)
                        {                            
                            if (antigaFormaPagamento != (int)EFormaPagamento.Aprazo)
                                ContaClienteRepositorio.CadastrarContaDeCliente(sqlCon, transaction, pedido);
                        }

                        //if(antigaFormaPagamento == (int)EFormaPagamento.Aprazo && pedido.FormaPagamento != EFormaPagamento.Aprazo)
                        //{
                        //    var conta = ContaClienteRepositorio.RecuperarContaDoCliente(pedido.IdPedido);

                        //    ContaClienteRepositorio.PagarContaDoCliente(conta.IdConta);
                        //}

                        VoltarEstoqueDosProdutos(sqlCon, transaction, produtosPreAlteracao);

                        sqlCon.Execute(strDeleteProdutosDoPedido, new { IdPedido = pedido.IdPedido }, transaction);

                        CadastrarProdutosDoPedido(sqlCon, transaction, pedido.Produtos);

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

        public static List<PedidoProduto> ListarProdutosDoPedido(int idPedido)
        {
            var strSqlPedido = @"select p.IdPedido, p.IdProduto, p.PrecoVenda, pro.Nome, pro.Fabricante,
                p.Quantidade, p.Desconto, p.PrecoLiquido, p.Total, p.PrecoCusto						
				from Pedido_Produto p
                inner join Produtos pro on p.IdProduto = pro.IdProduto
                where p.IdPedido = @idPedido			
                ";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    return sqlCon.Query<PedidoProduto>(
                        strSqlPedido, new { idPedido }
                     ).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static PedidoModel ConsultarPedido(int idPedido)
        {
            var strSqlPedido = @"select IdPedido, IdColaborador,			
				DataEmissao, FormaPagamento, TotalBruto, TotalDesconto, TotalLiquido, Eliminado, IdPedido, IdCliente
				from Pedidos where IdPedido = @idPedido				
                ";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    return sqlCon.Query<PedidoModel, ClienteModel, PedidoModel>(
                        strSqlPedido,
                        (pedido, cliente) => MapearPedidoModel(pedido, cliente),
                        new { idPedido },
                        splitOn: "IdPedido"
                     ).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<PedidoListagem> ListarPedidos(List<DateTime> datas, bool eliminado)
        {
            var strSqlPedido = @"select  p.IdPedido, p.DataEmissao,p.FormaPagamento, p.TotalBruto, p.TotalDesconto, p.TotalLiquido, p.Eliminado,
                (SUM(pp.Total) - SUM(pp.PrecoCusto * pp.Quantidade)) as Lucro,
                u.IdUsuario, u.Nome, u.SobreNome, u.IdUsuario, u2.Nome, u2.SobreNome                
				from Pedidos p
                inner join Pedido_Produto pp on p.IdPedido = pp.IdPedido
				inner join Colaboradores as co on p.IdColaborador = co.IdColaborador
				inner join Clientes as c on p.IdCliente = c.IdCliente				
				inner join Usuarios u on u.IdUsuario = c.IdUsuario
				inner join Usuarios u2 on u2.IdUsuario = co.IdUsuario
                where DataEmissao between @dataInicial and (@dataFinal + ' 23:59')
                and p.Eliminado = @eliminado
                group by p.IdPedido, p.DataEmissao, p.FormaPagamento, p.TotalBruto, p.TotalDesconto, p.TotalLiquido, p.Eliminado,
				u.IdUsuario, u.Nome, u.SobreNome, u.IdUsuario, u2.Nome, u2.SobreNome
                ";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    var pedidos = sqlCon.Query<PedidoListagem, NomeCompleto, NomeCompleto, PedidoListagem>(
                        strSqlPedido,
                        (pedido, nomeCliente, nomeColaborador) => MapearPedidoListagem(pedido, nomeCliente, nomeColaborador),
                        new { dataInicial = datas[0], dataFinal = datas[1], eliminado },
                        splitOn: "IdUsuario"
                     ).ToList();

                    return pedidos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int RecuperarQuantidadePreviamenteVendida(int idProduto, int idPedido)
        {
            var strSqlQuantidade = @"select Quantidade
                from Pedido_Produto where idProduto = @idProduto and idPedido = @idPedido
                ";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    return sqlCon.Query<int>(strSqlQuantidade, new { idProduto, idPedido }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void EliminarPedido(PedidoModel pedido)
        {
            var strEliminaPedido = @"UPDATE Pedidos set Eliminado = 1 where IdPedido = @IdPedido";

            using (SqlConnection sqlCon = SqlHelper.ObterConexao())
            {
                sqlCon.Open();

                using (SqlTransaction transaction = sqlCon.BeginTransaction())
                {
                    VoltarEstoqueDosProdutos(sqlCon, transaction, pedido.Produtos);

                    ContaClienteRepositorio.PagarContaDoPedido(sqlCon, transaction, pedido.IdPedido);

                    sqlCon.Execute(strEliminaPedido, new { pedido.IdPedido }, transaction);

                    transaction.Commit();
                }
            }
        }

        private static void CadastrarProdutosDoPedido(SqlConnection sqlCon, SqlTransaction transaction, List<PedidoProduto> produtos)
        {
            var strInsereNovosProdutos = @"INSERT INTO Pedido_Produto (IdPedido, IdProduto, PrecoVenda, PrecoCusto, Quantidade, 
                Desconto, PrecoLiquido, Total)
                VALUES (@IdPedido, @IdProduto, @PrecoVenda, @PrecoCusto, @Quantidade, @Desconto, @PrecoLiquido, @Total)";

            foreach (var x in produtos)
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
                },
                transaction);
            }
        }

        private static void VoltarEstoqueDosProdutos(SqlConnection sqlCon, SqlTransaction transaction, List<PedidoProduto> produtos)
        {
            try
            {
                var strSqlVoltaEstoque = @"UPDATE Produtos SET Estoque = Estoque + @Quantidade WHERE IdProduto = @IdProduto";

                foreach (var item in produtos)
                {
                    sqlCon.Execute(strSqlVoltaEstoque, new { item.Quantidade, item.IdProduto }, transaction);
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static PedidoListagem MapearPedidoListagem(PedidoListagem pedido, NomeCompleto nomeCliente, NomeCompleto nomeColaborador)
        {
            pedido.NomeCliente = nomeCliente;
            pedido.NomeColaborador = nomeColaborador;

            return pedido;
        }
        private static PedidoModel MapearPedidoModel(PedidoModel pedido, ClienteModel cliente)
        {
            pedido.Cliente = cliente;

            return pedido;
        }
    }
}
