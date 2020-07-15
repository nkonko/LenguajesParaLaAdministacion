namespace BLL.Interfaces
{
    using System.Collections.Generic;

    public interface IIntegrityBusiness
    {
        bool CheckIntegrity(Dictionary<string, int> ids = null);

        void UpdateIntegrity();
    }
}
