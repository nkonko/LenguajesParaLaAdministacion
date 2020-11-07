namespace BLL.Utils
{
    using BLL.Interfaces;
    using System.Collections.Generic;

    public class TablesBusiness : ITablesBusiness
    {
        private List<string> Tables { get; set; }

        public List<string> GetDefaultTables()
        {
            return Tables;
        }

        public TablesBusiness()
        {
            Tables = new List<string>()
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