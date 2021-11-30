using AugustosFashion.Helpers;
using AugustosFashionModels.Entidades.UsuariosSistema;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashion.Repositorios
{
    public static class UsuarioSistemaRepositorio
    {
        public static bool VerificarIdColaborador(int idColaborador)
        {
            var strSqlBusca = @"select count(*) from Colaboradores where IdColaborador = @idColaborador";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    return sqlCon.Query<bool>(strSqlBusca, new { idColaborador }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static void RegistrarUsuario(UsuarioSistemaModel usuarioSistemaModel)
        {
            var strSqlBusca = @"INSERT INTO Usuarios_Sistema (IdColaborador, NomeUsuario, Senha)
                                VALUES (@IdColaborador, @NomeUsuario, @Senha)";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    sqlCon.Execute(strSqlBusca, usuarioSistemaModel);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
