using AugustosFashion.Entidades.Colaborador;
using AugustosFashion.Entidades.ContaBancaria;
using AugustosFashion.Entidades.Endereco;
using AugustosFashion.Entidades.Telefone;
using AugustosFashion.Helpers;
using AugustosFashionModels.Entidades.NomesCompletos;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace AugustosFashion.Repositorios
{
    public static class ColaboradorRepositorio
    {
        public static void CadastrarColaborador(ColaboradorModel colaborador)
        {
            var strSqlColaborador = "Insert into Colaboradores (IdUsuario, Salario, PorcentagemComissao) output inserted.IdColaborador " +
                "values (@IdUsuario, @Salario, @PorcentagemComissao)";

            var strSqlUsuario = UsuarioSql.ObterStringInsertUsuario();

            var strSqlEndereco = EnderecoSql.ObterStringInsertEndereco();

            var strSqlTelefones = TelefoneSql.ObterStringInsertTelefone();

            var strSqlContaBancaria = ContaBancariaSql.ObterStringInsertContaBancaria();
         
            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    using(SqlTransaction transaction = sqlCon.BeginTransaction())
                    {
                        int insertedId = sqlCon.ExecuteScalar<int>(
                           strSqlUsuario, UsuarioSql.MapearPropriedadesDeUsuario(colaborador), transaction);

                        colaborador.IdUsuario = insertedId;
                        colaborador.Endereco.IdUsuario = insertedId;
                        colaborador.Telefones.ForEach(x => x.IdUsuario = insertedId);

                        var idColaborador = sqlCon.ExecuteScalar<int>(strSqlColaborador, colaborador, transaction);

                        colaborador.ContaBancaria.IdColaborador = idColaborador;

                        sqlCon.Execute(strSqlEndereco, EnderecoSql.MapearPropriedadesDeEndereco(colaborador.Endereco), transaction);

                        sqlCon.Execute(strSqlTelefones, colaborador.Telefones, transaction);
                        sqlCon.Execute(strSqlContaBancaria, colaborador.ContaBancaria, transaction);

                        transaction.Commit();
                    }                   
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void InativarColaborador(int idColaborador)
        {
            var strInativaColaborador = @"UPDATE Colaboradores SET Ativo = 0 WHERE IdColaborador = @idColaborador";
            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();                  
                    sqlCon.Execute(strInativaColaborador, new {idColaborador });                   
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static ColaboradorModel BuscarNomeDoColaborador(int idColaborador)
        {
            var strSqlBusca = @"
                SELECT c.IdColaborador, u.IdUsuario, u.Nome, u.Sobrenome FROM Colaboradores c
                INNER JOIN Usuarios u ON c.IdUsuario = u.IdUsuario          
                where IdColaborador = @idColaborador";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    return sqlCon.Query<ColaboradorModel, NomeCompleto, ColaboradorModel>(
                        strSqlBusca,
                        (colaboradorModel, nomeCompleto) => MapearColaboradorParaRecuperarNome(colaboradorModel, nomeCompleto), new { idColaborador },
                        splitOn: "IdUsuario"
                     ).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<ColaboradorListagem> ListarColaboradores()
        {
            SqlConnection sqlCon = SqlHelper.ObterConexao();

            var strSql = @"select
                c.idColaborador, FLOOR(DATEDIFF(DAY, u.DataNascimento, GETDATE()) / 365.25) as Idade,
                e.IdUsuario, u.Nome, u.SobreNome, u.IdUsuario, e.CEP, e.Logradouro, e.Numero, e.Cidade, e.UF, e.Complemento, e.Bairro
                from
                Usuarios u join Colaboradores c on u.IdUsuario = c.IdUsuario 
                inner join Enderecos e on u.IdUsuario = e.IdUsuario; ";
            try
            {
                using (sqlCon)
                {
                    sqlCon.Open();

                    return sqlCon.Query<ColaboradorListagem, NomeCompleto, EnderecoModel, ColaboradorListagem>(
                        strSql,
                        (colaboradorModel, nomeCompleto, enderecoModel) => MapearColaborador(colaboradorModel, nomeCompleto, enderecoModel),
                        splitOn: "IdUsuario"
                     ).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void AlterarColaborador(ColaboradorModel colaborador)
        {           
            string strSqlAlterarColaborador = @"update Colaboradores  
                set Salario = @Salario, PorcentagemComissao = @PorcentagemComissao where IdColaborador = @IdColaborador";

            string strSqlAlterarEndereco = EnderecoSql.ObterStringAlterarEndereco();
            string strSqlAlterarTel = TelefoneSql.ObterStringAlterarTelefone();
            string strSqlAlterarUsuario = UsuarioSql.ObterStringAlterarUsuario();
            string strSqlAlterarContaBancaria = ContaBancariaSql.ObterStringAlterarContaBancaria();

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();
                    using (var transaction = sqlCon.BeginTransaction())
                    {
                        int idUsuario = RecuperarIdUsuario(colaborador.IdColaborador, sqlCon, transaction);

                        colaborador.ContaBancaria.IdColaborador = colaborador.IdColaborador;
                        
                        colaborador.IdUsuario = idUsuario;
                        colaborador.Endereco.IdUsuario = idUsuario;
                        colaborador.Telefones.ForEach(x => x.IdUsuario = idUsuario);

                        sqlCon.Execute(strSqlAlterarColaborador, colaborador, transaction);
                        sqlCon.Execute(strSqlAlterarEndereco, EnderecoSql.MapearPropriedadesDeEndereco(colaborador.Endereco), transaction);
                        sqlCon.Execute(strSqlAlterarTel, colaborador.Telefones, transaction);
                        sqlCon.Execute(
                            strSqlAlterarUsuario, UsuarioSql.MapearPropriedadesDeUsuario(colaborador), transaction);
                        sqlCon.Execute(strSqlAlterarContaBancaria, colaborador.ContaBancaria, transaction);

                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void ExcluirColaborador(int idColaborador)
        {         
            string strSqlExcluirColaborador = "delete from Colaboradores where IdColaborador = @IdColaborador";
            string strSqlExcluirEndereco = EnderecoSql.ObterStringExcluisaoEndereco();
            string strSqlExcluirTel = TelefoneSql.ObterStringExclusaoTelefone();
            string strSqlExcluirUsuario = UsuarioSql.ObterStringExclusaoUsuario();
            string strSqlExcluirContaBancaria = ContaBancariaSql.ObterStringExclusaoConta();          

            try
            {
                using(SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    using(SqlTransaction transaction = sqlCon.BeginTransaction())
                    {
                        int idUsuario = RecuperarIdUsuario(idColaborador, sqlCon, transaction);

                        sqlCon.Execute(strSqlExcluirContaBancaria, new { IdColaborador = idColaborador }, transaction);
                        sqlCon.Execute(strSqlExcluirColaborador, new { IdColaborador = idColaborador }, transaction);
                        sqlCon.Execute(strSqlExcluirEndereco, new { IdUsuario = idUsuario }, transaction);
                        sqlCon.Execute(strSqlExcluirTel, new { IdUsuario = idUsuario }, transaction);
                        sqlCon.Execute(strSqlExcluirUsuario, new { IdUsuario = idUsuario }, transaction);

                        transaction.Commit();
                    }
                }              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<ColaboradorListagem> BuscarColaboradoresPorNome(string nomeBuscado, bool ativo)
        {
            SqlConnection sqlCon = SqlHelper.ObterConexao();

            var strSql = @"select
                c.idColaborador, FLOOR(DATEDIFF(DAY, u.DataNascimento, GETDATE()) / 365.25) as Idade,
                e.IdUsuario, u.Nome, u.SobreNome, u.IdUsuario, e.CEP, e.Logradouro, e.Numero, e.Cidade, e.UF, e.Complemento, e.Bairro
                from
                Usuarios u join Colaboradores c on u.IdUsuario = c.IdUsuario 
                inner join Enderecos e on u.IdUsuario = e.IdUsuario
                where u.Nome like @nomeBuscado + '%' and c.Ativo = @ativo";
            try
            {
                using (sqlCon)
                {
                    sqlCon.Open();

                    return sqlCon.Query<ColaboradorListagem, NomeCompleto, EnderecoModel, ColaboradorListagem>(
                        strSql,
                        (colaboradorModel, nomeCompleto, enderecoModel) => MapearColaborador(colaboradorModel, nomeCompleto, enderecoModel),
                        new { nomeBuscado, ativo },
                        splitOn: "IdUsuario"
                     ).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<ColaboradorListagem> BuscarColaboradoresPorId(int idBuscado)
        {
            SqlConnection sqlCon = SqlHelper.ObterConexao();

            var strSql = @"select
                c.idColaborador, FLOOR(DATEDIFF(DAY, u.DataNascimento, GETDATE()) / 365.25) as Idade,
                e.IdUsuario, u.Nome, u.SobreNome, u.IdUsuario, e.CEP, e.Logradouro, e.Numero, e.Cidade, e.UF, e.Complemento, e.Bairro
                from
                Usuarios u join Colaboradores c on u.IdUsuario = c.IdUsuario 
                inner join Enderecos e on u.IdUsuario = e.IdUsuario
                where c.IdColaborador =  @idBuscado";
            try
            {
                using (sqlCon)
                {
                    sqlCon.Open();

                    return sqlCon.Query<ColaboradorListagem, NomeCompleto, EnderecoModel, ColaboradorListagem>(
                        strSql,
                        (colaboradorModel, nomeCompleto, enderecoModel) => MapearColaborador(colaboradorModel, nomeCompleto, enderecoModel), new { idBuscado },
                        splitOn: "IdUsuario"
                     ).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static ColaboradorModel RecuperarInfoColaborador(int idColaborador)
        {
            
            
            string strSqlRecuperarInfoColaborador = @"
                select c.IdColaborador, c.IdUsuario, c.Salario, c.PorcentagemComissao,
                u.Email, u.DataNascimento, u.CPF, u.Sexo,
                u.IdUsuario, u.Nome, u.SobreNome, u.IdUsuario, e.CEP, e.Logradouro, e.Numero, e.Cidade, e.UF, e.Complemento, e.Bairro, u.IdUsuario,
				cb.Banco, cb.Agencia, cb.Conta, cb.TipoConta
				from Colaboradores c
				inner join Usuarios u on c.IdUsuario = u.IdUsuario
				inner join Enderecos e on c.IdUsuario = e.IdUsuario		
				inner join ContaBancaria cb on c.IdColaborador = cb.IdColaborador
				where c.idColaborador = @IdColaborador";
            string strSqlRecuperarInfoTelefones = TelefoneSql.ObterStringRecuperarInfoTelefones();

            try
            {

                using(SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    int idUsuario = RecuperarIdUsuario(idColaborador, sqlCon, null);

                    var colaborador = sqlCon.Query<ColaboradorModel, NomeCompleto, EnderecoModel, ContaBancariaModel, ColaboradorModel>(
                    strSqlRecuperarInfoColaborador,
                    (colaborador, nomeCompleto, endereco, contaBancaria) => MapearColaboradorParaConsulta(colaborador, nomeCompleto, endereco, contaBancaria),
                    new { IdColaborador = idColaborador },
                    splitOn: "IdUsuario").FirstOrDefault();

                    colaborador.Telefones = sqlCon.Query<TelefoneModel>(strSqlRecuperarInfoTelefones, new { IdUsuario = idUsuario }).ToList();

                    return colaborador;
                }              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int RecuperarIdUsuario(int idColaborador, SqlConnection sqlCon, SqlTransaction transaction)
        {
            string strSqlRecuperaIdUsuario = @"select IdUsuario from Colaboradores where IdColaborador = @IdColaborador";

            try
            {
                int idUsuario = sqlCon.ExecuteScalar<int>(strSqlRecuperaIdUsuario, new { IdColaborador = idColaborador }, transaction);

                return idUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static ColaboradorListagem MapearColaborador(ColaboradorListagem colaboradorModel, NomeCompleto nomeCompleto, EnderecoModel enderecoModel)
        {
            colaboradorModel.Endereco = enderecoModel;
            colaboradorModel.NomeCompleto = nomeCompleto;

            return colaboradorModel;
        }
        private static ColaboradorModel MapearColaboradorParaConsulta(ColaboradorModel colaboradorModel, NomeCompleto nomeCompleto, EnderecoModel enderecoModel, ContaBancariaModel contaBancaria)
        {
            colaboradorModel.Endereco = enderecoModel;
            colaboradorModel.ContaBancaria = contaBancaria;
            colaboradorModel.NomeCompleto = nomeCompleto;

            return colaboradorModel;
        }
        private static ColaboradorModel MapearColaboradorParaRecuperarNome(ColaboradorModel colaboradorModel, NomeCompleto nomeCompleto)
        {
            colaboradorModel.NomeCompleto = nomeCompleto;

            return colaboradorModel;
        }
    }
}
