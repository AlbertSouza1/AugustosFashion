﻿using AugustosFashion.Entidades.Cliente;
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
    public static class ClienteRepositorio
    {
        public static void CadastrarCliente(ClienteModel cliente)
        {          
            var strSqlCliente = "Insert into Clientes " +
                "values (@IdUsuario, @LimiteCompraAPrazo, @Observacao)";

            var strSqlUsuario = UsuarioRepositorio.ObterStringInsertUsuario();

            var strSqlEndereco = EnderecoRepositorio.ObterStringInsertEndereco();

            var strSqlTelefones = TelefoneRepositorio.ObterStringInsertTelefone();

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();
                    using (SqlTransaction transaction = sqlCon.BeginTransaction())
                    {
                        int insertedId = sqlCon.ExecuteScalar<int>(strSqlUsuario,
                        new
                        {
                            Nome = cliente.NomeCompleto.Nome,
                            SobreNome = cliente.NomeCompleto.SobreNome,
                            Sexo = cliente.Sexo,
                            DataNascimento = cliente.DataNascimento,
                            Email = cliente.Email.RetornaValor,
                            CPF = cliente.CPF.RetornaValor
                        },
                        transaction);

                        cliente.IdUsuario = insertedId;
                        cliente.Endereco.IdUsuario = insertedId;
                        cliente.Telefones.ForEach(x => x.IdUsuario = insertedId);

                        sqlCon.Execute(strSqlCliente, cliente, transaction);
                        sqlCon.Execute(strSqlEndereco,
                        new
                        {
                                IdUsuario = cliente.Endereco.IdUsuario,
                                CEP = cliente.Endereco.CEP.RetornaValor,
                                Logradouro = cliente.Endereco.Logradouro,
                                Numero = cliente.Endereco.Numero,
                                Cidade = cliente.Endereco.Cidade,
                                UF = cliente.Endereco.UF,
                                Complemento = cliente.Endereco.Complemento,
                                Bairro = cliente.Endereco.Bairro,
                         },
                         transaction);

                        sqlCon.Execute(strSqlTelefones, cliente.Telefones, transaction);

                        transaction.Commit();
                    }
                }              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<ClienteListagem> BuscarClientesPorId(int idBuscado)
        {            
            var strSqlBusca = @"select
                c.idCliente, u.IdUsuario, u.Sexo, FLOOR(DATEDIFF(DAY, u.DataNascimento, GETDATE()) / 365.25) as Idade,
                u.DataNascimento, e.IdUsuario, u.Nome, u.SobreNome, u.IdUsuario, e.CEP, e.Logradouro, e.Numero, e.Cidade, e.UF, e.Complemento, e.Bairro
                from
                Usuarios u join Clientes c on u.IdUsuario = c.IdUsuario 
                inner join Enderecos e on u.IdUsuario = e.IdUsuario
                where c.IdCliente = @idBuscado
                ";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    return sqlCon.Query<ClienteListagem, NomeCompleto, EnderecoModel, ClienteListagem>(
                        strSqlBusca,
                        (clienteModel, nomeCompleto, enderecoModel) => MapearCliente(clienteModel, nomeCompleto, enderecoModel), new { idBuscado },
                        splitOn: "IdUsuario"
                     ).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<ClienteListagem> ListarClientes()
        {          
            var strSql = @"select
                c.IdCliente, u.IdUsuario,  u.Sexo, FLOOR(DATEDIFF(DAY, u.DataNascimento, GETDATE()) / 365.25) as Idade,
                u.DataNascimento, e.IdUsuario, u.Nome, u.SobreNome, u.IdUsuario, e.CEP, e.Logradouro, e.Numero, e.Cidade, e.UF, e.Complemento, e.Bairro
                from
                Usuarios u join Clientes c on u.IdUsuario = c.IdUsuario 
                inner join Enderecos e on u.IdUsuario = e.IdUsuario; ";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    return sqlCon.Query<ClienteListagem, NomeCompleto, EnderecoModel, ClienteListagem>(
                        strSql,
                        (clienteModel, nomeCompleto, enderecoModel) => MapearCliente(clienteModel, nomeCompleto, enderecoModel),
                        splitOn: "IdUsuario"
                     ).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void AlterarCliente(ClienteModel cliente)
        {


            string strSqlAlterarCliente = @"update Clientes  
                set Observacao = @Observacao, ValorLimiteCompraAPrazo = @LimiteCompraAPrazo where IdCliente = @IdCliente";

            string strSqlAlterarEndereco = EnderecoRepositorio.ObterStringAlterarEndereco();
            string strSqlAlterarTel = TelefoneRepositorio.ObterStringAlterarTelefone();
            string strSqlAlterarUsuario = UsuarioRepositorio.ObterStringAlterarUsuario();

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    using (SqlTransaction transaction = sqlCon.BeginTransaction())
                    {
                        int idUsuario = RecuperarIdUsuario(cliente.IdCliente, sqlCon, transaction);

                        cliente.IdUsuario = idUsuario;
                        cliente.Endereco.IdUsuario = idUsuario;
                        cliente.Telefones.ForEach(x => x.IdUsuario = idUsuario);

                        sqlCon.Execute(strSqlAlterarCliente, cliente, transaction);
                        sqlCon.Execute(strSqlAlterarEndereco,
                            new
                            {
                                IdUsuario = cliente.Endereco.IdUsuario,
                                CEP = cliente.Endereco.CEP.RetornaValor,
                                Logradouro = cliente.Endereco.Logradouro,
                                Numero = cliente.Endereco.Numero,
                                Cidade = cliente.Endereco.Cidade,
                                UF = cliente.Endereco.UF,
                                Complemento = cliente.Endereco.Complemento,
                                Bairro = cliente.Endereco.Bairro,
                            },
                            transaction);
                        sqlCon.Execute(strSqlAlterarTel, cliente.Telefones, transaction);
                        sqlCon.Execute(strSqlAlterarUsuario,
                        new
                        {
                            Nome = cliente.NomeCompleto.Nome,
                            SobreNome = cliente.NomeCompleto.SobreNome,
                            Sexo = cliente.Sexo,
                            DataNascimento = cliente.DataNascimento,
                            Email = cliente.Email.RetornaValor,
                            CPF = cliente.CPF.RetornaValor,
                            IdUsuario = cliente.IdUsuario
                        },
                        transaction);

                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void ExcluirCliente(int idCliente)
        {
            string strSqlExcluirCliente = "delete from Clientes where IdCliente = @IdCliente";
            string strSqlExcluirEndereco = EnderecoRepositorio.ObterStringExcluisaoEndereco();
            string strSqlExcluirTel = TelefoneRepositorio.ObterStringExclusaoTelefone();
            string strSqlExcluirUsuario = UsuarioRepositorio.ObterStringExclusaoUsuario();

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    using (SqlTransaction transaction = sqlCon.BeginTransaction())
                    {
                        int idUsuario = RecuperarIdUsuario(idCliente, sqlCon, transaction);

                        sqlCon.Execute(strSqlExcluirCliente, new { IdCliente = idCliente }, transaction);
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
        public static ClienteModel RecuperarInfoCliente(int idCliente)
        {

            string strSqlRecuperarInfoCliente = @"
                select c.idCliente, c.idUsuario, c.ValorLimiteCompraAPrazo as LimiteCompraAPrazo, c.Observacao,
                u.IdUsuario, u.Email, u.DataNascimento, u.CPF,
				u.Sexo, u.idUsuario, u.Nome, u.SobreNome, u.IdUsuario, e.CEP, e.Logradouro, e.Numero, e.Cidade, e.UF, e.Complemento, e.Bairro
				from Clientes c
				inner join Usuarios u on c.IdUsuario = u.IdUsuario
				inner join Enderecos e on c.IdUsuario = e.IdUsuario					
				where IdCliente = @IdCliente";

            string strSqlRecuperarInfoTelefones = TelefoneRepositorio.ObterStringRecuperarInfoTelefones();

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {

                    sqlCon.Open();

                    int idUsuario = RecuperarIdUsuario(idCliente, sqlCon, null);

                    var cliente = sqlCon.Query<ClienteModel, NomeCompleto, EnderecoModel, ClienteModel>(
                        strSqlRecuperarInfoCliente,
                        (cliente, nomeCompleto, endereco) => MapearClienteParaConsulta(cliente, nomeCompleto, endereco), new { IdCliente = idCliente },
                        splitOn: "IdUsuario").FirstOrDefault();

                    cliente.Telefones = sqlCon.Query<TelefoneModel>(strSqlRecuperarInfoTelefones, new { IdUsuario = idUsuario }).ToList();

                    return cliente;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<ClienteListagem> BuscarClientesPorNome(string nomeBuscado)
        {
            SqlConnection sqlCon = SqlHelper.ObterConexao();

            var stringSqlBusca = @"select
                c.idCliente, u.IdUsuario, u.Sexo, FLOOR(DATEDIFF(DAY, u.DataNascimento, GETDATE()) / 365.25) as Idade,
                u.DataNascimento, e.IdUsuario, u.Nome, u.SobreNome, u.IdUsuario, e.CEP, e.Logradouro, e.Numero, e.Cidade, e.UF, e.Complemento, e.Bairro
                from
                Usuarios u join Clientes c on u.IdUsuario = c.IdUsuario 
                inner join Enderecos e on u.IdUsuario = e.IdUsuario
                where u.Nome like @nomeBuscado + '%'
                ; ";

            try
            {
                using (sqlCon)
                {
                    sqlCon.Open();

                    return sqlCon.Query<ClienteListagem, NomeCompleto, EnderecoModel, ClienteListagem>(
                        stringSqlBusca,
                        (clienteModel, nomeCompleto, enderecoModel) => MapearCliente(clienteModel, nomeCompleto, enderecoModel), new { nomeBuscado },
                        splitOn: "IdUsuario"
                     ).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static int RecuperarIdUsuario(int idCliente, SqlConnection sqlCon, SqlTransaction transaction)
        {
            string strSqlRecuperaIdUsuario = @"select IdUsuario from Clientes where IdCliente = @IdCliente";
            try
            {
                int idUsuario = sqlCon.ExecuteScalar<int>(strSqlRecuperaIdUsuario, new { IdCliente = idCliente }, transaction);

                return idUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private static ClienteListagem MapearCliente(ClienteListagem clienteModel, NomeCompleto nomeCompleto, EnderecoModel enderecoModel)
        {
            clienteModel.Endereco = enderecoModel;
            clienteModel.NomeCompleto = nomeCompleto;

            return clienteModel;
        }
        private static ClienteModel MapearClienteParaConsulta(ClienteModel cliente, NomeCompleto nomeCompleto, EnderecoModel endereco)
        {
            cliente.Endereco = endereco;
            cliente.NomeCompleto = nomeCompleto;

            return cliente;
        }
    }
}
