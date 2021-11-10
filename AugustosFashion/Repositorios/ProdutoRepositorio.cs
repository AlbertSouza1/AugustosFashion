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

        public static List<ProdutoListagem> ListarTodosOsProdutos()
        {
            var strSqlProduto = @"select IdProduto, Nome, CodigoBarras, Fabricante, PrecoCusto, PrecoVenda, Estoque, Status 
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
    }
}
