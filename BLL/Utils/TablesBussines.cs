namespace BLL.Utils
{
    using BLL.Interfaces;
    using System.Collections.Generic;

    public class TablesBusiness : ITablesBusiness
    {
        private List<string> tables { get; set; }

        public List<string> GetDefaultTables()
        {
            return tables;
        }

        public TablesBusiness()
        {
            tables = new List<string>()
            {
                "Userdb",
                "Family",
                "Patent",
                "Bitacora",
                "DVV",
                "PatentFamily",
                "Solicitud",
                "UserPatent",
                "UserFamily"
            };
        }
    }
}