using AugustosFashion.Helpers;
using AugustosFashionModels.Entidades.ContasClientes;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace AugustosFashion.Repositorios
{
    public static class ContaClienteRepositorio
    {
        public static List<ContaClienteModel> RecuperarContasDoCliente(int idCliente)
        {
            string strSqlContaCliente = @"SELECT IdCliente, IdPedido, Pago FROM Contas_Clientes WHERE IdCliente = @idCliente";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {

                    sqlCon.Open();

                    return  sqlCon.Query<ContaClienteModel>( strSqlContaCliente, new { idCliente }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
