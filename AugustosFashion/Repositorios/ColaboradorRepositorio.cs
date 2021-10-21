using AugustosFashion.Entidades.Colaborador;
using AugustosFashion.Entidades.ContaBancaria;
using AugustosFashion.Entidades.Endereco;
using AugustosFashion.Entidades.Telefone;
using AugustosFashion.Helpers;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AugustosFashion.Repositorios
{
    class ColaboradorRepositorio
    {
        public void CadastrarColaborador(ColaboradorModel colaborador, EnderecoModel endereco, List<TelefoneModel> telefones, ContaBancariaModel contaBancaria)
        {
            SqlConnection sqlCon = new SqlHelper().ObterConexao();

            int insertedId = 0;

            var strSqlColaborador = "Insert into Colaboradores output inserted.IdColaborador " +
                "values (@IdUsuario, @Salario, @PorcentagemComissao)";

            var strSqlUsuario = UsuarioRepositorio.ObterStringInsertUsuario();

            var strSqlEndereco = EnderecoRepositorio.ObterStringInsertEndereco();

            var strSqlTelefones = TelefoneRepositorio.ObterStringInsertTelefone();

            var strSqlContaBancaria = ContaBancariaRepositorio.ObterStringInsertContaBancaria();

            sqlCon.Open();

            SqlTransaction tran = sqlCon.BeginTransaction();

            try
            {
                using (sqlCon)
                {

                    insertedId = sqlCon.ExecuteScalar<int>(strSqlUsuario, colaborador, tran);

                    colaborador.IdUsuario = insertedId;
                    endereco.IdUsuario = insertedId;
                    telefones.ForEach(x => x.IdUsuario = insertedId);

                    var idColaborador = sqlCon.ExecuteScalar<int>(strSqlColaborador, colaborador, tran);

                    contaBancaria.IdColaborador = idColaborador;

                    sqlCon.Execute(strSqlEndereco, endereco, tran);
                    sqlCon.Execute(strSqlTelefones, telefones, tran);
                    sqlCon.Execute(strSqlContaBancaria, contaBancaria, tran);

                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public void ExcluirColaborador(int idColaborador)
        {
            SqlConnection sqlCon = new SqlHelper().ObterConexao();
            int idUsuario = 0;

            string strSqlRecuperaIdUsuario = @"select IdUsuario from Colaboradores where IdColaborador = @IdColaborador";
            string strSqlExcluirColaborador = "delete from Colaboradores where IdColaborador = @IdColaborador";
            string strSqlExcluirContaBancaria = ContaBancariaRepositorio.ObterStringExclusaoConta();
            string strSqlExcluirEndereco = EnderecoRepositorio.ObterStringExcluisaoEndereco();
            string strSqlExcluirTel = TelefoneRepositorio.ObterStringExclusaoTelefone();
            string strSqlExcluirUsuario = UsuarioRepositorio.ObterStringExclusaoUsuario();

            sqlCon.Open();

            SqlTransaction tran = sqlCon.BeginTransaction();

            try
            {
                //using (sqlCon)
                //{
                idUsuario = sqlCon.ExecuteScalar<int>(strSqlRecuperaIdUsuario, new { IdColaborador = idColaborador }, tran);

                sqlCon.Execute(strSqlExcluirContaBancaria, new { IdColaborador = idColaborador }, tran);
                sqlCon.Execute(strSqlExcluirColaborador, new { IdColaborador = idColaborador }, tran);
                sqlCon.Execute(strSqlExcluirEndereco, new { IdUsuario = idUsuario }, tran);
                sqlCon.Execute(strSqlExcluirTel, new { IdUsuario = idUsuario }, tran);
                sqlCon.Execute(strSqlExcluirUsuario, new { IdUsuario = idUsuario }, tran);

                tran.Commit();
                //}
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
