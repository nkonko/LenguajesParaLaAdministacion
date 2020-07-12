namespace DAL.Interfaces
{
    using BE;
    using System.Collections.Generic;

    public interface IDigitVerifier
    {
        int CalculateDVH(string totalString);

        int CalculateDVV(string entity);

        bool CheckIntegrity(string entity, List<User> users);

        Dictionary<string, int> GetDVV(string entity);

        void InsertDVV(string entity);

        void UpdateDVV(string entity);
    }
}