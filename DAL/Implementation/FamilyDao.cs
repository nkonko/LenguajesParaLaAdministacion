namespace DAL.Implementation
{
    using BE;
    using DAL.Interfaces;
    using DAL.Utils;
    using System.Collections.Generic;
    using System.Linq;

    public class FamilyDao : BaseDao, IFamilyDao
    {
        public bool Add(Family obj)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Family obj)
        {
            throw new System.NotImplementedException();
        }

        public List<Family> Get()
        {
            var query = "SELECT * FROM Family";

            return CatchException(() =>
            {
                return Exec<Family>(query);
            });
        }

        public List<Family> GetUserFamily(int id)
        {
            var userFamilies = new List<int>();
            var families = Get();
            var query = $"SELECT FamilyId FROM UserFamily WHERE UserId = @Id";

            userFamilies = CatchException(() =>
            {
                return Exec<int>(
                    query,
                    new
                    {
                        @Id = id
                    });
            });

            return families.FindAll(x => userFamilies.Any(y => y == x.Id));
        }

        public bool Update(Family obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
