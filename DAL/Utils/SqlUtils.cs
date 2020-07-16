namespace DAL.Utils
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    public class SqlUtils : BaseDao
    {
        public static SqlConnection Connection()
        {
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString);
            return conn;
        }

        public static List<string> GetTables()
        {
            using (SqlConnection connection = Connection())
            {
                connection.Open();
                var schema = connection.GetSchema("Tables");
                var tableNames = new List<string>();

                foreach (DataRow row in schema.Rows)
                {
                    tableNames.Add(row[2].ToString());
                }

                return tableNames;
            }
        }
    }
}
