namespace DAL.Interfaces
{
    using System.Collections.Generic;

    public interface IDigitVerifier
    {
        int CalculateDVH(string totalString);

        void UpdateDvh(string entity, int id, int dvh);

        int CalculateDVV(string entity);

        bool CheckIntegrity(string entity, string finalString, int entityDVH);

        Dictionary<string, int> GetDVV(string entity);

        void InsertDVV(string entity);

        void UpdateDVV(string entity);
    }
}