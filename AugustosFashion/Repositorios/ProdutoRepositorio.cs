using AugustosFashion.Helpers;
using AugustosFashionModels.Entidades.Produtos;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace AugustosFashion.Repositorios
{
    public static class ProdutoRepositorio
    {
        public static void CadastrarProduto(ProdutoModel produto)
        {
            var strSqlProduto = "Insert into Produtos (Nome, CodigoBarras, Fabricante, PrecoCusto, PrecoVenda, Estoque) " +
                "values (@Nome, @CodigoBarras, @Fabricante, @PrecoCusto, @PrecoVenda, @Estoque)";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();
                   
                    sqlCon.Execute(strSqlProduto, produto);                      
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static void AlterarProduto(ProdutoModel produto)
        {
            var strSqlProduto = @"Update Produtos SET Nome = @Nome, CodigoBarras = @CodigoBarras,
                Fabricante = @Fabricante, PrecoCusto = @PrecoCusto, PrecoVenda = @PrecoVenda, Estoque = @Estoque 
                where IdProduto = @IdProduto";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    sqlCon.Execute(strSqlProduto, produto);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<ProdutoListagem> ListarTodosOsProdutos()
        {
            var strSqlProduto = @"select IdProduto, Nome, Fabricante, PrecoVenda
                from Produtos where status = 1
                ";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    return sqlCon.Query<ProdutoListagem>(strSqlProduto).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static ProdutoModel ConsultarProduto(int idProduto)
        {
            var strSqlProduto = @"select IdProduto, Nome, CodigoBarras, Fabricante, PrecoCusto, PrecoVenda, Estoque, Status 
                from Produtos where IdProduto = @idProduto
                ";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    return sqlCon.Query<ProdutoModel>(strSqlProduto, new {idProduto}).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void InativarProduto(int idProduto)
        {
            var strSql = @"update Produtos set Status = 0 where IdProduto = @idProduto";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    sqlCon.Execute(strSql, new { idProduto });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static List<ProdutoListagem> BuscarProdutosPorNome(string busca)
        {
            var strSqlProduto = @"select IdProduto, Nome, CodigoBarras, Fabricante, PrecoCusto, PrecoVenda, Estoque, Status 
                from Produtos where status = 1 and Nome like @busca + '%'
                ";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    return sqlCon.Query<ProdutoListagem>(strSqlProduto, new {busca}).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
