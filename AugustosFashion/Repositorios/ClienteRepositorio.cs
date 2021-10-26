using AugustosFashion.Entidades.Cliente;
using AugustosFashion.Entidades.Endereco;
using AugustosFashion.Entidades.Telefone;
using System.Collections.Generic;
using AugustosFashion.Helpers;
using Dapper;
using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;

namespace AugustosFashion.Repositorios
{
    public class ClienteRepositorio
    {

        public void CadastrarCliente(ClienteModel cliente, EnderecoModel endereco, List<TelefoneModel> telefones)
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
                    insertedId = sqlCon.ExecuteScalar<int>(strSqlUsuario, cliente, tran);

                    cliente.IdUsuario = insertedId;
                    endereco.IdUsuario = insertedId;
                    telefones.ForEach(x => x.IdUsuario = insertedId);

                    sqlCon.Execute(strSqlCliente, cliente, tran);
                    sqlCon.Execute(strSqlEndereco, endereco, tran);

                    sqlCon.Execute(strSqlTelefones, telefones, tran);

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

        public List<ClienteListagem> ListarClientes()
        {
            SqlConnection sqlCon = new SqlHelper().ObterConexao();

            var strSql = @"select
                c.idCliente, u.Nome, u.SobreNome, u.Sexo, FLOOR(DATEDIFF(DAY, u.DataNascimento, GETDATE()) / 365.25) as Idade,
                u.DataNascimento, e.IdUsuario, e.CEP, e.Logradouro, e.Numero, e.Cidade, e.UF, e.Complemento, e.Bairro
                from
                Usuarios u join Clientes c on u.IdUsuario = c.IdUsuario 
                inner join Enderecos e on u.IdUsuario = e.IdUsuario; ";

            try
            {
                using (sqlCon)
                {
                    sqlCon.Open();

                    return sqlCon.Query<ClienteListagem, EnderecoModel, ClienteListagem>(
                        strSql,
                        (clienteModel, enderecoModel) => MapearCliente(clienteModel, enderecoModel),
                        splitOn: "IdUsuario"
                     ).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AlterarCliente(ClienteModel cliente, EnderecoModel endereco, List<TelefoneModel> telefones)
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
                endereco.IdUsuario = idUsuario;
                telefones.ForEach(x => x.IdUsuario = idUsuario);

                sqlCon.Execute(strSqlAlterarCliente, cliente , tran);
                sqlCon.Execute(strSqlAlterarEndereco, endereco, tran);
                sqlCon.Execute(strSqlAlterarTel, telefones, tran);
                sqlCon.Execute(strSqlAlterarUsuario, cliente, tran);

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
        public void ExcluirCliente(int idCliente)
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

        public ClienteConsulta RecuperarInfoCliente(int idCliente)
        {
            SqlConnection sqlCon = new SqlHelper().ObterConexao();

            string strSqlRecuperarInfoCliente = "select idCliente, idUsuario, ValorLimiteCompraAPrazo, Observacao from Clientes where IdCliente = @IdCliente";

            sqlCon.Open();

            try
            {
                ClienteConsulta cliente = sqlCon.QuerySingle<ClienteConsulta>(strSqlRecuperarInfoCliente, new { IdCliente = idCliente });

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int RecuperarIdUsuario(int idCliente)
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

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private ClienteListagem MapearCliente(ClienteListagem clienteModel, EnderecoModel enderecoModel)
        {
            clienteModel.Endereco = enderecoModel;

            return clienteModel;
        }
    }
}
