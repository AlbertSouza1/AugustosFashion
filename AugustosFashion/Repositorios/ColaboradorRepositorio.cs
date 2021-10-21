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

        public List<ColaboradorListagem> ListarColaboradores()
        {
            SqlConnection sqlCon = new SqlHelper().ObterConexao();

            var strSql = @"select
                c.idColaborador, u.Nome, u.SobreNome, FLOOR(DATEDIFF(DAY, u.DataNascimento, GETDATE()) / 365.25) as Idade,
                e.IdUsuario, e.Cidade, e.UF
                from
                Usuarios u join Colaboradores c on u.IdUsuario = c.IdUsuario 
                inner join Enderecos e on u.IdUsuario = e.IdUsuario; ";
            try
            {
                using (sqlCon)
                {
                    sqlCon.Open();

                    return sqlCon.Query<ColaboradorListagem, EnderecoModel, ColaboradorListagem>(
                        strSql,
                        (colaboradorModel, enderecoModel) => MapearColaborador(colaboradorModel, enderecoModel),
                        splitOn: "IdUsuario"
                     ).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AlterarColaborador()
        {

        }

        public void ExcluirColaborador(int idColaborador)
        {
            SqlConnection sqlCon = new SqlHelper().ObterConexao();
            
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
                int idUsuario = sqlCon.ExecuteScalar<int>(strSqlRecuperaIdUsuario, new { IdColaborador = idColaborador }, tran);

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

        private ColaboradorListagem MapearColaborador(ColaboradorListagem colaboradorModel, EnderecoModel enderecoModel)
        {
            colaboradorModel.Endereco = enderecoModel;

            return colaboradorModel;
        }
    }
}
