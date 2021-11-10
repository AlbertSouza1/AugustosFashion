using AugustosFashion.Helpers;
using AugustosFashionModels.Entidades.Produtos;
using Dapper;
using System;
using System.Data.SqlClient;

namespace AugustosFashion.Repositorios
{
    public class ProdutoRepositorio
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
    }
}
