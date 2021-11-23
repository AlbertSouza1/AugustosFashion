using AugustosFashion.Helpers;
using AugustosFashionModels.Entidades.ServicoEmails;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AugustosFashion.Repositorios
{
    public class EmailRepositorio
    {
        public static void CadastrarEmail(EmailLojaModel email)
        {
            var strSqlEmail = "Insert into Emails_Da_Loja " +
                "values (@Email, @Senha, @Chave)";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();
                   
                    sqlCon.Execute(strSqlEmail, email);                                        
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static EmailLojaModel RecuperarEmail()
        {
            var strSqlEmail = "select * from Emails_Da_Loja";

            try
            {
                using (SqlConnection sqlCon = SqlHelper.ObterConexao())
                {
                    sqlCon.Open();

                    return sqlCon.Query<EmailLojaModel>(strSqlEmail).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
