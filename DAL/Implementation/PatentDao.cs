namespace DAL.Implementation
{
    using BE;
    using DAL.Interfaces;
    using DAL.Utils;
    using System.Collections.Generic;
    using System.Linq;

    public class PatentDao : BaseDao, IPatentDao
    {
        public bool Add(Patent obj)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Patent obj)
        {
            throw new System.NotImplementedException();
        }

        public List<Patent> Get()
        {
            var query = "SELECT * FROM Patent";

            return CatchException(() =>
            {
                return Exec<Patent>(query);
            });
        }

        public List<Patent> GetFamilyPatents(int familyId)
        {
            var familyPatents = new List<int>();
            var patents = Get();
            var queryString = "SELECT PatentId FROM PatentFamily WHERE FamilyId = @familyId";

            familyPatents = CatchException(() =>
            {
                return Exec<int>(queryString, new { @familyId = familyId });
            });

            return patents.FindAll(x => familyPatents.Any(y => y == x.Id));
        }

        public List<Patent> GetUserPatents(int id)
        {
            var userPatents = new List<int>();
            var patents = Get();
            var queryString = "SELECT PatentId FROM UserPatent WHERE UserId = @userId";

            userPatents = CatchException(() =>
            {
                return Exec<int>(queryString, new { @userId = id });
            });

            return patents.FindAll(x => userPatents.Any(y => y == x.Id));
        }

        public bool Update(Patent obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
