namespace DAL.Utils
{
    using System.Configuration;
    using System.Data.SqlClient;

    public class SqlUtils : BaseDao
    {
        public static SqlConnection Connection()
        {
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString);
            return conn;
        }
    }
}
