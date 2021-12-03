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
    public static class RelatorioVendaProdutoRepositorio
    {
        public static List<RelatorioVendaProduto> ConsultarRelatorio(FiltroRelatorioVendaProduto filtroRelatorio)
        {
            var relatorioVendaHelper = new RelatorioVendaProdutoHelper(filtroRelatorio);

            var strConsultaRelatorio = relatorioVendaHelper.GerarQueryRelatorio();

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    return sqlCon.Query<RelatorioVendaProduto>(
                        strConsultaRelatorio,
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
