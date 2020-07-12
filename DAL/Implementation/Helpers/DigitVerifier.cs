namespace DAL.Implementation.Helpers
{
    using BE;
    using DAL.Interfaces;
    using DAL.Utils;
    using System.Collections.Generic;
    using System.Linq;

    public class DigitVerifier : BaseDao, IDigitVerifier
    {
        public DigitVerifier()
        {
        }

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

        public bool CheckIntegrity(string entity, List<User> users)
        {
            var corruptedDvh = CheckDvh(users);

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

        private bool CheckDvh(List<User> users)
        {
            foreach (var user in users)
            {
                var finalString = user.Name + user.Password + user.UserName + user.LoginAttempt;

                var dvh = CalculateDVH(finalString);

                if (dvh != user.DVH)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
