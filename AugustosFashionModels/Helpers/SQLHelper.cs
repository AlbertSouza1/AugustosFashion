using System.Data.SqlClient;


namespace AugustosFashion.Helpers
{
    public static class SqlHelper
    {
        private static string connectionString = @"Data Source=DESKTOP-91Q14BK;Initial Catalog=AugustoFashion;Integrated Security=True";

        public static SqlConnection ObterConexao()
        {
            SqlConnection sqlCon = new SqlConnection(connectionString);

            return sqlCon;
        }
    }
}
