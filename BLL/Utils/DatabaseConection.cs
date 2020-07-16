namespace BLL.Utils
{
    using DAL.Utils;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public static class DatabaseConection
    {
        public static SqlConnection GetConnection()
        {
            return SqlUtils.Connection();
        }

        public static List<string> GetTables()
        {
            return SqlUtils.GetTables();
        }
    }
}
