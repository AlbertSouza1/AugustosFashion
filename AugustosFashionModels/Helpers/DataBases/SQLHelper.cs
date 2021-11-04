using AugustosFashionModels.Helpers.DataBases;
using System.Data;
using System.Data.SqlClient;


namespace AugustosFashion.Helpers
{
    public class SqlHelper : IDataBase
    {
        private string connectionString = @"Data Source=USER-PC\SQLEXPRESS;Initial Catalog=AugustoFashion;User ID=sa;Password=123";

        public string RetornarConnectionString() => @"Data Source=USER-PC\SQLEXPRESS;Initial Catalog=AugustoFashion;User ID=sa;Password=123";

        public IDbConnection ObterConexao()
        {
            SqlConnection sqlCon = new SqlConnection(connectionString);

            return sqlCon;
        }
    }
}
