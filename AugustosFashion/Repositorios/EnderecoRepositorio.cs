using AugustosFashion.Entidades.Endereco;
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
    public static class EnderecoRepositorio
    {
        public static string ObterStringInsertEndereco() => "Insert into Enderecos " +
                "values (@IdUsuario, @CEP, @Logradouro, @Numero, @Cidade, @UF, @Complemento, @Bairro)";

        public static string ObterStringExcluisaoEndereco() => "delete from Enderecos where IdUsuario = @IdUsuario";

        public static string ObterStringAlterarEndereco() => @"
            update 
                Enderecos
            set
                CEP = @CEP, Logradouro = @Logradouro, Numero = @Numero, Cidade = @Cidade, UF = @Uf, Complemento = @Complemento, Bairro = @Bairro
            where
                IdUsuario = @IdUsuario";

        public static EnderecoModel RecuperarInfoEndereco(int idUsuario)
        {
            SqlConnection sqlCon = new SqlHelper().ObterConexao();

            var strSqlEnderecoConsulta = "select CEP, Logradouro, Numero, Cidade, UF, Complemento, Bairro from Enderecos where IdUsuario = @IdUsuario";

            sqlCon.Open();

            try
            {
                EnderecoModel endereco = sqlCon.QuerySingle<EnderecoModel>(strSqlEnderecoConsulta, new { IdUsuario = idUsuario });

                return endereco;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
