using AugustosFashion.Helpers;
using AugustosFashionModels.Entidades.ContasClientes;
using AugustosFashionModels.Entidades.Pedidos;
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
            string strSqlContaCliente = @"SELECT cc.IdConta, cc.IdCliente, cc.IdPedido, cc.Pago, p.TotalLiquido as Valor
                                        FROM Contas_Clientes cc inner join Pedidos p on cc.IdPedido = p.IdPedido
                                        WHERE cc.IdCliente = @idCliente and Pago = 0";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {

                    sqlCon.Open();

                    return sqlCon.Query<ContaClienteModel>(strSqlContaCliente, new { idCliente }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void CadastrarContaDeCliente(SqlConnection sqlCon, SqlTransaction transaction, PedidoModel pedido)
        {
            var strInsereConta = @"INSERT INTO Contas_Clientes (IdCliente, IdPedido)
                VALUES (@IdCliente, @IdPedido)";

            sqlCon.Execute(strInsereConta, new { pedido.Cliente.IdCliente, pedido.IdPedido }, transaction);
        }
    }
}

