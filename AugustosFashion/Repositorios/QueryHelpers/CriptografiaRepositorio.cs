using AugustosFashion.Helpers;
using Dapper;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace AugustosFashion.Repositorios.QueryHelpers
{
    public static class CriptografiaRepositorio
    {
        public static string RetornarChave()
        {
            var stringSql = @"select Chave from Criptografia";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    return sqlCon.Query<string>(stringSql).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }             
        }
    }
}
