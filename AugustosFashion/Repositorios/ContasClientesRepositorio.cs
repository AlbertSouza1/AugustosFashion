using AugustosFashion.Helpers;
using AugustosFashionModels.Entidades.ContasClientes;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashion.Repositorios
{
    public static class ContasClientesRepositorio
    {
        public static List<ContaClienteModel> RecuperarContasDoCliente(int idCliente)
        {
            var strSqlBusca = @"
                ";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    return sqlCon.Query<ContaClienteModel>(
                        strSqlBusca,
                        new { idCliente }
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
