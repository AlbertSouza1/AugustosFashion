using AugustosFashionModels.Entidades.Pedidos.Relatorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using AugustosFashion.Helpers;

namespace AugustosFashion.Repositorios
{
    public static class RelatorioVendaProdutoRepositorio
    {
        static string a = "a";

        public static List<RelatorioVendaProduto> ConsultarRelatorio(FiltroRelatorioVendaProduto filtroRelatorio)
        {           
            var strConsultaRelatorio = ;

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    return sqlCon.Query<RelatorioVendaProduto>(
                        strConsultaRelatorio,
                        new 
                        {
                            filtroRelatorio.DataInicial,
                            filtroRelatorio.DataFinal
                        }
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
