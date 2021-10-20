using AugustosFashion.Entidades.Cliente;
using AugustosFashion.Entidades.Endereco;
using AugustosFashion.Entidades.Telefone;
using System.Collections.Generic;
using AugustosFashion.Helpers;
using Dapper;
using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AugustosFashion.Repositorios
{
    public class ClienteRepositorio
    {
        SqlConnection sqlCon = SqlHelper.ObterConexao();
        public void CadastrarCliente(ClienteModel cliente, EnderecoModel endereco, List<TelefoneModel> telefones)
        {
            endereco.Bairro = "a";
            endereco.CEP = "a";
            endereco.Cidade = "a";
            endereco.Complemento = "a";
            endereco.Logradouro = "a";
            endereco.Numero = 1;
            endereco.UF = "AB";

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
                using (sqlCon)
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
            }catch(Exception ex)
            {
                tran.Rollback();
                throw new Exception(ex.Message);
            }
        }
    }
}
