namespace BLL.Interfaces
{
    public interface IIntegrityBusiness
    {
        bool CheckIntegrity(string entity);

        void UpdateIntegrity(string entity);
    }
}