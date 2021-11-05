using AugustosFashion.Entidades.ContaBancaria;
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
    public static class ContaBancariaRepositorio
    {
        public static string ObterStringInsertContaBancaria() => "insert into ContaBancaria values(@IdColaborador, @Agencia, @Conta, @TipoConta, @Banco)";

        public static string ObterStringExclusaoConta() => "delete from ContaBancaria where IdColaborador = @IdColaborador";

        public static ContaBancariaModel RecuperarInfoContaBancaria(int idColaborador)
        {
            SqlConnection sqlCon = SqlHelper.ObterConexao();

            var strSqlUsuarioConsulta = @"select IdConta, Agencia, Conta, TipoConta, Banco 
                from ContaBancaria where IdColaborador = @IdColaborador";

            sqlCon.Open();

            try
            {
                ContaBancariaModel usuario = sqlCon.QuerySingle<ContaBancariaModel>(strSqlUsuarioConsulta, new { IdColaborador = idColaborador });

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string ObterStringAlterarContaBancaria() =>
             @"update ContaBancaria set Agencia = @Agencia, Conta = @Conta, TipoConta = @TipoConta, Banco = @Banco  
                where IdColaborador = @IdColaborador";

    }
}
