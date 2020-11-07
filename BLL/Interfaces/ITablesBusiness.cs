namespace BLL.Interfaces
{
    using System.Collections.Generic;

    public interface ITablesBusiness
    {
        List<string> GetDefaultTables();
    }
}