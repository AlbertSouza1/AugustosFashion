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
        public static bool VerificarSeLoginJaExiste(string login)
        {
            var strSqlBusca = @"select count(*) from Usuarios_Sistema where NomeUsuario = @login";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    return sqlCon.Query<bool>(strSqlBusca, new { login }).FirstOrDefault();
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

        public static int VerificarLogin(UsuarioSistemaModel usuarioSistema)
        {
            var strSqlBusca = @"SELECT count(*) FROM Usuarios_Sistema
                                WHERE NomeUsuario = @NomeUsuario and Senha = @Senha";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    return sqlCon.Query<int>(strSqlBusca, new { usuarioSistema.NomeUsuario, usuarioSistema.Senha }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
