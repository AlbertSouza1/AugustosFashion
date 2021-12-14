using AugustosFashion.Helpers;
using AugustosFashion.Repositorios.QueryHelpers;
using AugustosFashionModels.Entidades.NomesCompletos;
using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using AugustosFashionModels.Entidades.Pedidos.Relatorios.Filtros;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace AugustosFashion.Repositorios
{
    public class RelatorioPedidoClienteRepositorio
    {
        public static List<RelatorioPedidoCliente> ConsultarRelatorio(FiltroRelatorioPedidoCliente filtroRelatorio)
        {
            var relatorioVendaHelper = new RelatorioPedidoClienteHelper(filtroRelatorio);

            var querySelect = @"SELECT ";

            querySelect += relatorioVendaHelper.GerarFiltroTop();

            querySelect += @" c.IdCliente, count(p.IdPedido) as QuantidadeCompras, sum(p.TotalBruto) as TotalBruto,
	        sum(p.TotalDesconto) as TotalDesconto, sum(p.TotalLiquido) as TotalLiquido, c.IdCliente, u.Nome, u.SobreNome
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

                    return sqlCon.Query<RelatorioPedidoCliente, NomeCompleto, RelatorioPedidoCliente>(
                        querySelect,
                        (relatorioVendaCliente, nomeCompleto) => MapearRelatorioVendaCliente(relatorioVendaCliente, nomeCompleto),
                        relatorioVendaHelper.RecuperarParametros(),
                        splitOn:"IdCliente"
                     ).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static RelatorioPedidoCliente MapearRelatorioVendaCliente(RelatorioPedidoCliente relatorioVendaCliente, NomeCompleto nomeCompleto)
        {
            relatorioVendaCliente.NomeCompleto = nomeCompleto;

            return relatorioVendaCliente;
        }
    }
}
