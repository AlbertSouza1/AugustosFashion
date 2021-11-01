using AugustosFashion.Entidades.Cliente;
using AugustosFashion.Entidades.Endereco;
using AugustosFashion.Entidades.Telefone;
using AugustosFashion.Helpers;
using AugustosFashionModels.Entidades.Usuario;
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
            SqlConnection sqlCon = new SqlHelper().ObterConexao();
            int insertedId = 0;

            var strSqlCliente = "Insert into Clientes " +
                "values (@IdUsuario, @LimiteCompraAPrazo, @Observacao)";

            var strSqlUsuario = UsuarioRepositorio.ObterStringInsertUsuario();

            var strSqlEndereco = EnderecoRepositorio.ObterStringInsertEndereco();

            var strSqlTelefones = TelefoneRepositorio.ObterStringInsertTelefone();

            sqlCon.Open();

            SqlTransaction tran = sqlCon.BeginTransaction();

            try
            {
                insertedId = sqlCon.ExecuteScalar<int>(strSqlUsuario,
                    new {Nome = cliente.NomeCompleto.Nome, SobreNome = cliente.NomeCompleto.SobreNome,
                        Sexo = cliente.Sexo, DataNascimento = cliente.DataNascimento, Email = cliente.Email, CPF = cliente.CPF },                
                    tran);

                cliente.IdUsuario = insertedId;
                cliente.Endereco.IdUsuario = insertedId;
                cliente.Telefones.ForEach(x => x.IdUsuario = insertedId);

                sqlCon.Execute(strSqlCliente, cliente, tran);
                sqlCon.Execute(strSqlEndereco, cliente.Endereco, tran);

                sqlCon.Execute(strSqlTelefones, cliente.Telefones, tran);

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

        public static List<ClienteListagem> BuscarClientesPorId(int idBuscado)
        {
            SqlConnection sqlCon = new SqlHelper().ObterConexao();

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
                using (sqlCon)
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
            SqlConnection sqlCon = new SqlHelper().ObterConexao();

            var strSql = @"select
                c.IdCliente, u.IdUsuario,  u.Sexo, FLOOR(DATEDIFF(DAY, u.DataNascimento, GETDATE()) / 365.25) as Idade,
                u.DataNascimento, e.IdUsuario, u.Nome, u.SobreNome, u.IdUsuario, e.CEP, e.Logradouro, e.Numero, e.Cidade, e.UF, e.Complemento, e.Bairro
                from
                Usuarios u join Clientes c on u.IdUsuario = c.IdUsuario 
                inner join Enderecos e on u.IdUsuario = e.IdUsuario; ";

            try
            {
                using (sqlCon)
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
            SqlConnection sqlCon = new SqlHelper().ObterConexao();

            string strSqlAlterarCliente = @"update Clientes  
                set Observacao = @Observacao, ValorLimiteCompraAPrazo = @LimiteCompraAPrazo where IdCliente = @IdCliente";

            string strSqlAlterarEndereco = EnderecoRepositorio.ObterStringAlterarEndereco();
            string strSqlAlterarTel = TelefoneRepositorio.ObterStringAlterarTelefone();
            string strSqlAlterarUsuario = UsuarioRepositorio.ObterStringAlterarUsuario();

            sqlCon.Open();

            SqlTransaction tran = sqlCon.BeginTransaction();

            try
            {
                int idUsuario = RecuperarIdUsuario(cliente.IdCliente);

                cliente.IdUsuario = idUsuario;
                cliente.Endereco.IdUsuario = idUsuario;
                cliente.Telefones.ForEach(x => x.IdUsuario = idUsuario);

                sqlCon.Execute(strSqlAlterarCliente, cliente, tran);
                sqlCon.Execute(strSqlAlterarEndereco, cliente.Endereco, tran);
                sqlCon.Execute(strSqlAlterarTel, cliente.Telefones, tran);
                sqlCon.Execute(strSqlAlterarUsuario, 
                new
                {
                    Nome = cliente.NomeCompleto.Nome,
                    SobreNome = cliente.NomeCompleto.SobreNome,
                    Sexo = cliente.Sexo,
                    DataNascimento = cliente.DataNascimento,
                    Email = cliente.Email,
                    CPF = cliente.CPF,
                    IdUsuario = cliente.IdUsuario
                },         
                tran);

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
        public static void ExcluirCliente(int idCliente)
        {
            SqlConnection sqlCon = new SqlHelper().ObterConexao();

            string strSqlExcluirCliente = "delete from Clientes where IdCliente = @IdCliente";
            string strSqlExcluirEndereco = EnderecoRepositorio.ObterStringExcluisaoEndereco();
            string strSqlExcluirTel = TelefoneRepositorio.ObterStringExclusaoTelefone();
            string strSqlExcluirUsuario = UsuarioRepositorio.ObterStringExclusaoUsuario();

            sqlCon.Open();

            SqlTransaction tran = sqlCon.BeginTransaction();

            try
            {
                //using (sqlCon)
                //{
                int idUsuario = RecuperarIdUsuario(idCliente);

                sqlCon.Execute(strSqlExcluirCliente, new { IdCliente = idCliente }, tran);
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
        public static ClienteModel RecuperarInfoCliente(int idCliente)
        {
            int idUsuario = RecuperarIdUsuario(idCliente);

            SqlConnection sqlCon = new SqlHelper().ObterConexao();

            string strSqlRecuperarInfoCliente = @"
                select c.idCliente, c.idUsuario, c.ValorLimiteCompraAPrazo, c.Observacao,
                u.IdUsuario, u.Email, u.DataNascimento, u.CPF,
				u.Sexo, u.idUsuario, u.Nome, u.SobreNome, u.IdUsuario, e.CEP, e.Logradouro, e.Numero, e.Cidade, e.UF, e.Complemento, e.Bairro
				from Clientes c
				inner join Usuarios u on c.IdUsuario = u.IdUsuario
				inner join Enderecos e on c.IdUsuario = e.IdUsuario					
				where IdCliente = @IdCliente";

            string strSqlRecuperarInfoTelefones = TelefoneRepositorio.ObterStringRecuperarInfoTelefones();

            sqlCon.Open();

            try
            {
                var cliente = sqlCon.Query<ClienteModel, NomeCompleto, EnderecoModel, ClienteModel>(
                    strSqlRecuperarInfoCliente,
                    (cliente, nomeCompleto, endereco) => MapearClienteParaConsulta(cliente, nomeCompleto, endereco), new { IdCliente = idCliente },
                    splitOn: "IdUsuario").FirstOrDefault();

                cliente.Telefones = sqlCon.Query<TelefoneModel>(strSqlRecuperarInfoTelefones, new { IdUsuario = idUsuario }).ToList();

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<ClienteListagem> BuscarClientesPorNome(string nomeBuscado)
        {
            SqlConnection sqlCon = new SqlHelper().ObterConexao();

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
        public static int RecuperarIdUsuario(int idCliente)
        {
            SqlConnection sqlCon = new SqlHelper().ObterConexao();

            string strSqlRecuperaIdUsuario = @"select IdUsuario from Clientes where IdCliente = @IdCliente";
            try
            {
                using (sqlCon)
                {
                    sqlCon.Open();

                    int idUsuario = sqlCon.ExecuteScalar<int>(strSqlRecuperaIdUsuario, new { IdCliente = idCliente });

                    return idUsuario;
                }

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
