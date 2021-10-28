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
    public static class ColaboradorRepositorio
    {
        public static void CadastrarColaborador(ColaboradorModel colaborador, EnderecoModel endereco, List<TelefoneModel> telefones, ContaBancariaModel contaBancaria)
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

        public static List<ColaboradorListagem> ListarColaboradores()
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
        public static void AlterarColaborador(ColaboradorModel colaborador, EnderecoModel endereco, List<TelefoneModel> telefones, ContaBancariaModel contaBancaria)
        {
            SqlConnection sqlCon = new SqlHelper().ObterConexao();

            string strSqlAlterarColaborador = @"update Colaboradores  
                set Salario = @Salario, PorcentagemComissao = @PorcentagemComissao where IdColaborador = @IdColaborador";

            string strSqlAlterarEndereco = EnderecoRepositorio.ObterStringAlterarEndereco();
            string strSqlAlterarTel = TelefoneRepositorio.ObterStringAlterarTelefone();
            string strSqlAlterarUsuario = UsuarioRepositorio.ObterStringAlterarUsuario();
            string strSqlAlterarContaBancaria = ContaBancariaRepositorio.ObterStringAlterarContaBancaria();

            sqlCon.Open();

            SqlTransaction tran = sqlCon.BeginTransaction();

            contaBancaria.IdColaborador = colaborador.IdColaborador;

            try
            {   
                int idUsuario = RecuperarIdUsuario(colaborador.IdColaborador);

                colaborador.IdUsuario = idUsuario;
                endereco.IdUsuario = idUsuario;
                telefones.ForEach(x => x.IdUsuario = idUsuario);

                sqlCon.Execute(strSqlAlterarColaborador, colaborador, tran);
                sqlCon.Execute(strSqlAlterarEndereco, endereco, tran);
                sqlCon.Execute(strSqlAlterarTel, telefones, tran);
                sqlCon.Execute(strSqlAlterarUsuario, colaborador, tran);
                sqlCon.Execute(strSqlAlterarContaBancaria, contaBancaria, tran);

                tran.Commit();            
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

        public static void ExcluirColaborador(int idColaborador)
        {
            SqlConnection sqlCon = new SqlHelper().ObterConexao();

            string strSqlExcluirColaborador = "delete from Colaboradores where IdColaborador = @IdColaborador";
            string strSqlExcluirEndereco = EnderecoRepositorio.ObterStringExcluisaoEndereco();
            string strSqlExcluirTel = TelefoneRepositorio.ObterStringExclusaoTelefone();
            string strSqlExcluirUsuario = UsuarioRepositorio.ObterStringExclusaoUsuario();
            string strSqlExcluirContaBancaria = ContaBancariaRepositorio.ObterStringExclusaoConta();

            sqlCon.Open();

            SqlTransaction tran = sqlCon.BeginTransaction();

            try
            {
                int idUsuario = RecuperarIdUsuario(idColaborador);
                
                sqlCon.Execute(strSqlExcluirContaBancaria, new { IdColaborador = idColaborador }, tran);
                sqlCon.Execute(strSqlExcluirColaborador, new { IdColaborador = idColaborador }, tran);             
                sqlCon.Execute(strSqlExcluirEndereco, new { IdUsuario = idUsuario }, tran);
                sqlCon.Execute(strSqlExcluirTel, new { IdUsuario = idUsuario }, tran);
                sqlCon.Execute(strSqlExcluirUsuario, new { IdUsuario = idUsuario }, tran);

                tran.Commit();
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

        public static List<ColaboradorListagem> BuscarColaboradores(string nomeBuscado)
        {
            SqlConnection sqlCon = new SqlHelper().ObterConexao();

            var strSql = @"select
                c.idColaborador, u.Nome, u.SobreNome, FLOOR(DATEDIFF(DAY, u.DataNascimento, GETDATE()) / 365.25) as Idade,
                e.IdUsuario, e.Cidade, e.UF
                from
                Usuarios u join Colaboradores c on u.IdUsuario = c.IdUsuario 
                inner join Enderecos e on u.IdUsuario = e.IdUsuario
                where u.Nome like '%' + @nomeBuscado + '%'; ";
            try
            {
                using (sqlCon)
                {
                    sqlCon.Open();

                    return sqlCon.Query<ColaboradorListagem, EnderecoModel, ColaboradorListagem>(
                        strSql,
                        (colaboradorModel, enderecoModel) => MapearColaborador(colaboradorModel, enderecoModel), new {nomeBuscado}, 
                        splitOn: "IdUsuario"
                     ).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static ColaboradorConsulta RecuperarInfoColaborador(int idColaborador)
        {
            SqlConnection sqlCon = new SqlHelper().ObterConexao();

            string strSqlRecuperarInfoColaborador = @"select idColaborador, idUsuario, Salario, PorcentagemComissao from Colaboradores 
                where IdColaborador = @IdColaborador";

            sqlCon.Open();

            try
            {
                ColaboradorConsulta colaborador = sqlCon.QuerySingle<ColaboradorConsulta>(strSqlRecuperarInfoColaborador, new { IdColaborador = idColaborador });

                return colaborador;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int RecuperarIdUsuario(int idColaborador)
        {
            SqlConnection sqlCon = new SqlHelper().ObterConexao();

            string strSqlRecuperaIdUsuario = @"select IdUsuario from Colaboradores where IdColaborador = @IdColaborador";
            try
            {
                using (sqlCon)
                {
                    sqlCon.Open();

                    int idUsuario = sqlCon.ExecuteScalar<int>(strSqlRecuperaIdUsuario, new { IdColaborador = idColaborador });

                    return idUsuario;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static ColaboradorListagem MapearColaborador(ColaboradorListagem colaboradorModel, EnderecoModel enderecoModel)
        {
            colaboradorModel.Endereco = enderecoModel;

            return colaboradorModel;
        }
    }
}
