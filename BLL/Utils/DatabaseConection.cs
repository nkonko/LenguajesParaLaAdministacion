namespace BLL.Utils
{
    using DAL.Utils;
    using System.Data.SqlClient;

    public static class DatabaseConection
    {
        public static SqlConnection GetConnection()
        {
            return SqlUtils.Connection();
        }
    }
}
