using System.Data.SqlClient;


namespace AugustosFashion.Helpers
{
    public  class SqlHelper
    {
        private  string connectionString = @"Data Source=USER-PC\SQLEXPRESS;Initial Catalog=AugustoFashion;User ID=sa;Password=123";

        public  SqlConnection ObterConexao()
        {
            SqlConnection sqlCon = new SqlConnection(connectionString);

            return sqlCon;
        }
    }
}
