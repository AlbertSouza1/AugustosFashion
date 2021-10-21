using AugustosFashion.Entidades.Telefone;
using AugustosFashion.Helpers;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashion.Repositorios
{
    public static class TelefoneRepositorio
    {
        public static string ObterStringInsertTelefone() => "Insert into Telefones " +
                "values(@IdUsuario, @Numero, @TipoTelefone)";
        public static string ObterStringExclusaoTelefone() => "delete from Telefones " +
               "where IdUsuario = @IdUsuario";

        internal static string ObterStringAlterarTelefone() => @"
            update
	            Telefones
            set
	            Numero = @Numero
            where
	            IdUsuario = @IdUsuario and IdTelefone = @IdTelefone;";

        public static List<TelefoneModel> RecuperarInfoTelefones(int idUsuario)
        {
            SqlConnection sqlCon = new SqlHelper().ObterConexao();

            var strSqlUsuarioConsulta = "select IdTelefone, IdUsuario, Numero, TipoTelefone from Telefones where IdUsuario = @IdUsuario";

            sqlCon.Open();

            try
            {
                List<TelefoneModel> telefones = sqlCon.Query<TelefoneModel>(strSqlUsuarioConsulta, new { IdUsuario = idUsuario }).ToList<TelefoneModel>();

                return telefones;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
