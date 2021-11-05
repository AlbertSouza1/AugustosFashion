using System.Data.SqlClient;


namespace AugustosFashion.Helpers
{
    public static class SqlHelper
    {
        private static string connectionString = @"Data Source=USER-PC\SQLEXPRESS;Initial Catalog=AugustoFashion;User ID=sa;Password=123";

        public static SqlConnection ObterConexao()
        {
            SqlConnection sqlCon = new SqlConnection(connectionString);

            return sqlCon;
        }
    }
}
