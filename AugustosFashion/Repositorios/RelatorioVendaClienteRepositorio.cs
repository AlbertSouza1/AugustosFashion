using AugustosFashion.Helpers;
using AugustosFashion.Repositorios.QueryHelpers;
using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace AugustosFashion.Repositorios
{
    public class RelatorioVendaClienteRepositorio
    {
        public static List<RelatorioVendaCliente> ConsultarRelatorio(FiltroRelatorioVendaCliente filtroRelatorio)
        {
            var relatorioVendaHelper = new RelatorioVendaClienteHelper(filtroRelatorio);

            var querySelect = @" 
            SELECT
            c.IdCliente, u.Nome, u.SobreNome, count(p.IdPedido) as QuantidadeCompras, sum(p.TotalBruto) as TotalBruto,
	        sum(p.TotalDesconto) as TotalDesconto, sum(p.TotalLiquido) as TotalLiquido
            FROM
            Clientes c inner join Usuarios u on c.IdUsuario = u.IdUsuario
	        inner join Pedidos p on c.IdCliente = p.IdCliente ";

            querySelect += relatorioVendaHelper.GerarFiltrosWhere();

            querySelect += " group by u.Nome, c.IdCliente, u.SobreNome ";

            querySelect += relatorioVendaHelper.GerarFiltrosHaving();

            querySelect += relatorioVendaHelper.GerarOrderBys();

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    return sqlCon.Query<RelatorioVendaCliente>(
                        querySelect,
                        relatorioVendaHelper.RecuperarParametros()
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
