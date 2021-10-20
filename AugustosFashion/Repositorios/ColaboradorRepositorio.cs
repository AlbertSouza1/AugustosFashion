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
        SqlConnection sqlCon = new SqlHelper().ObterConexao();

        public void CadastrarColaborador(ColaboradorModel colaborador, EnderecoModel endereco, List<TelefoneModel> telefones, ContaBancariaModel contaBancaria)
        {
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
    }
}
