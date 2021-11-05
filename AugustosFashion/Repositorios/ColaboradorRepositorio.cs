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
            SqlConnection sqlCon = new SqlHelper().ObterConexao();

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

                    int insertedId = sqlCon.ExecuteScalar<int>(
                        strSqlUsuario,
                        new
                        {
                            Nome = colaborador.NomeCompleto.Nome,
                            SobreNome = colaborador.NomeCompleto.SobreNome,
                            Sexo = colaborador.Sexo,
                            DataNascimento = colaborador.DataNascimento,
                            Email = colaborador.Email.RetornaValor,
                            CPF = colaborador.CPF.RetornaValor
                        },
                        tran);

                    colaborador.IdUsuario = insertedId;
                    colaborador.Endereco.IdUsuario = insertedId;
                    colaborador.Telefones.ForEach(x => x.IdUsuario = insertedId);

                    var idColaborador = sqlCon.ExecuteScalar<int>(strSqlColaborador, colaborador, tran);

                    colaborador.ContaBancaria.IdColaborador = idColaborador;

                    sqlCon.Execute(strSqlEndereco, colaborador.Endereco, tran);
                    sqlCon.Execute(strSqlTelefones, colaborador.Telefones, tran);
                    sqlCon.Execute(strSqlContaBancaria, colaborador.ContaBancaria, tran);

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
            SqlConnection sqlCon = new SqlHelper().ObterConexao();

            string strSqlAlterarColaborador = @"update Colaboradores  
                set Salario = @Salario, PorcentagemComissao = @PorcentagemComissao where IdColaborador = @IdColaborador";

            string strSqlAlterarEndereco = EnderecoRepositorio.ObterStringAlterarEndereco();
            string strSqlAlterarTel = TelefoneRepositorio.ObterStringAlterarTelefone();
            string strSqlAlterarUsuario = UsuarioRepositorio.ObterStringAlterarUsuario();
            string strSqlAlterarContaBancaria = ContaBancariaRepositorio.ObterStringAlterarContaBancaria();

            try
            {

                using (sqlCon)
                {
                    sqlCon.Open();

                    using (SqlTransaction tran = sqlCon.BeginTransaction())
                    {
                        colaborador.ContaBancaria.IdColaborador = colaborador.IdColaborador;

                        int idUsuario = RecuperarIdUsuario(colaborador.IdColaborador);

                        colaborador.IdUsuario = idUsuario;
                        colaborador.Endereco.IdUsuario = idUsuario;
                        colaborador.Telefones.ForEach(x => x.IdUsuario = idUsuario);

                        sqlCon.Execute(strSqlAlterarColaborador, colaborador, tran);
                        sqlCon.Execute(strSqlAlterarEndereco,
                            new
                            {
                                IdUsuario = colaborador.Endereco.IdUsuario,
                                CEP = colaborador.Endereco.CEP.RetornaValor,
                                Logradouro = colaborador.Endereco.Logradouro,
                                Numero = colaborador.Endereco.Numero,
                                Cidade = colaborador.Endereco.Cidade,
                                UF = colaborador.Endereco.UF,
                                Complemento = colaborador.Endereco.Complemento,
                                Bairro = colaborador.Endereco.Bairro,
                            },
                        tran);
                        sqlCon.Execute(strSqlAlterarTel, colaborador.Telefones, tran);
                        sqlCon.Execute(
                            strSqlAlterarUsuario,
                            new
                            {
                                Nome = colaborador.NomeCompleto.Nome,
                                SobreNome = colaborador.NomeCompleto.SobreNome,
                                Sexo = colaborador.Sexo,
                                DataNascimento = colaborador.DataNascimento,
                                Email = colaborador.Email.RetornaValor,
                                CPF = colaborador.CPF.RetornaValor,
                                IdUsuario = colaborador.IdUsuario
                            },
                            tran);
                        sqlCon.Execute(strSqlAlterarContaBancaria, colaborador.ContaBancaria, tran);

                        tran.Commit();
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

        public static List<ColaboradorListagem> BuscarColaboradoresPorNome(string nomeBuscado)
        {
            SqlConnection sqlCon = new SqlHelper().ObterConexao();

            var strSql = @"select
                c.idColaborador, FLOOR(DATEDIFF(DAY, u.DataNascimento, GETDATE()) / 365.25) as Idade,
                e.IdUsuario, u.Nome, u.SobreNome, u.IdUsuario, e.CEP, e.Logradouro, e.Numero, e.Cidade, e.UF, e.Complemento, e.Bairro
                from
                Usuarios u join Colaboradores c on u.IdUsuario = c.IdUsuario 
                inner join Enderecos e on u.IdUsuario = e.IdUsuario
                where u.Nome like @nomeBuscado + '%'; ";
            try
            {
                using (sqlCon)
                {
                    sqlCon.Open();

                    return sqlCon.Query<ColaboradorListagem, NomeCompleto, EnderecoModel, ColaboradorListagem>(
                        strSql,
                        (colaboradorModel, nomeCompleto, enderecoModel) => MapearColaborador(colaboradorModel, nomeCompleto, enderecoModel), new { nomeBuscado },
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
            SqlConnection sqlCon = new SqlHelper().ObterConexao();

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
            int idUsuario = RecuperarIdUsuario(idColaborador);

            SqlConnection sqlCon = new SqlHelper().ObterConexao();

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
            string strSqlRecuperarInfoTelefones = TelefoneRepositorio.ObterStringRecuperarInfoTelefones();

            sqlCon.Open();

            try
            {
                var colaborador = sqlCon.Query<ColaboradorModel, NomeCompleto, EnderecoModel, ContaBancariaModel, ColaboradorModel>(
                    strSqlRecuperarInfoColaborador,
                    (colaborador, nomeCompleto, endereco, contaBancaria) => MapearColaboradorParaConsulta(colaborador, nomeCompleto, endereco, contaBancaria),
                    new { IdColaborador = idColaborador },
                    splitOn: "IdUsuario").FirstOrDefault();

                colaborador.Telefones = sqlCon.Query<TelefoneModel>(strSqlRecuperarInfoTelefones, new { IdUsuario = idUsuario }).ToList();

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
    }
}
