﻿namespace DAL.Implementation.Helpers
{
    using DAL.Interfaces;
    using DAL.Utils;
    using System.Collections.Generic;
    using System.Linq;

    public class DigitVerifier : BaseDao, IDigitVerifier
    {
        public int CalculateDVH(string totalString)
        {
            var convertedValue = 0;
            var list = new List<int>();
            var result = 0;

            for (var i = 0; i < totalString.Length; i++)
            {
                convertedValue = totalString[i] * (i + 1);
                list.Add(convertedValue);
            }

            result = list.Sum();
            return result;
        }

        public void UpdateDvh(string entity, int id, int dvh)
        {
            var queryString = string.Empty;

            if (entity == "Bitacora")
            {
                queryString = $"UPDATE Bitacora SET DVH = {dvh} WHERE IdLog = {id}";
            }

            if (entity == "UserDb")
            {
                queryString = $"UPDATE Userdb SET DVH = {dvh} WHERE Id = {id}";
            }

            CatchException(() =>
            {
                Exec(queryString);
            });

        }

        public int CalculateDVV(string entity)
        {
            var queryString = string.Format("SELECT SUM(DVH) FROM {0}", entity);

            return CatchException(() =>
            {
                return Exec<int>(queryString)[0];
            });
        }

        public void InsertDVV(string entity)
        {
            var digit = CalculateDVV(entity);

            var queryString = "INSERT INTO DVV(Entity, Digit) VALUES(@entity, @digit)";

            CatchException(() =>
            {
                Exec(queryString, new { @entity = entity, @digit = digit });
            });
        }

        public void UpdateDVV(string entity)
        {
            var digit = CalculateDVV(entity);

            var queryString = "UPDATE DVV SET Digit = @digit WHERE entity = @entity";

            CatchException(() =>
            {
                Exec(queryString, new { @entity = entity, @digit = digit });
            });
        }

        public Dictionary<string, int> GetDVV(string entity)
        {
            var response = new Dictionary<string, int>();

            var queryString = string.Format("SELECT Digit FROM DVV WHERE Entity = '{0}'", entity);

            CatchException(() =>
            {
                response.Add(entity, Exec<int>(queryString).FirstOrDefault());
            });

            return response;
        }

        public bool CheckIntegrity(string entity, string finalString, int entityDVH)
        {
            var corruptedDvh = CheckDvh(finalString, entityDVH);

            if (!corruptedDvh)
            {
                var resultSum = CalculateDVV(entity);

                var dvv = GetDVV(entity);

                return resultSum == dvv[entity] ?
                       true :
                       false;
            }

            return false;
        }

        private bool CheckDvh(string finalString, int entityDVH)
        {
            var dvh = CalculateDVH(finalString);

            if (dvh != entityDVH)
            {
                return true;
            }

            return false;
        }
    }
}
