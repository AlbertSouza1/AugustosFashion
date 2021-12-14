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
            string strSqlContaCliente = @"select 
	        cc.IdCliente, cc.IdConta, cc.IdPedido, cc.Pago, p.TotalLiquido as Valor, p.DataEmissao
            from Contas_Clientes cc
            inner join Pedidos p
            on p.IdCliente = cc.IdCliente and p.IdPedido = cc.IdPedido
            where cc.IdCliente = @idCliente and cc.Pago = 0";

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

        public static void PagarConta(int idConta)
        {
            string strSqlContaCliente = @"UPDATE Contas_Clientes
            SET Pago = 1, DataPagamento = @dataPagamento WHERE IdConta = @idConta";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    sqlCon.Execute(strSqlContaCliente, new { idConta, dataPagamento = DateTime.Now });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void PagarContaDoPedido(SqlConnection sqlCon, SqlTransaction transaction, int idPedido)
        {
            string strSqlContaCliente = @"UPDATE Contas_Clientes
            SET Pago = 1 WHERE IdPedido = @idPedido";

            sqlCon.Execute(strSqlContaCliente, new { idPedido }, transaction);
        }
       
        public static void ExcluirConta(SqlConnection sqlCon, SqlTransaction transaction, int idPedido)
        {
            var strDelete = @"delete from Contas_Clientes where IdPedido = @idPedido";

            sqlCon.Execute(strDelete, new { idPedido }, transaction);
        }
    }
}

