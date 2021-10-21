using AugustosFashion.Entidades.Usuario;
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
    public static class UsuarioRepositorio
    {
        public static string ObterStringInsertUsuario() => "Insert into Usuarios " +
                "output inserted.IdUsuario " +
                "values (@Nome, @SobreNome, @Sexo, @DataNascimento, @Email, @CPF)";
        public static string ObterStringExclusaoUsuario() => "delete from Usuarios " +
                "where IdUsuario = @IdUsuario";

        public static string ObterStringAlterarUsuario() => @"
        update
            Usuarios
        set
            Nome = @Nome, SobreNome = @SobreNome, Sexo = @Sexo, DataNascimento = @DataNascimento, Email = @Email, CPF = @CPF
        where
            IdUsuario = @IdUsuario;";

        public static UsuarioConsulta RecuperarInfoUsuario(int idUsuario)
        {
            SqlConnection sqlCon = new SqlHelper().ObterConexao();

            var strSqlUsuarioConsulta = "select Nome, Sobrenome, Sexo, DataNascimento, Email, CPF from Usuarios where IdUsuario = @IdUsuario";

            sqlCon.Open();

            try
            {
                UsuarioConsulta usuario = sqlCon.QuerySingle<UsuarioConsulta>(strSqlUsuarioConsulta, new { IdUsuario = idUsuario });

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
