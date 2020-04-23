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
            throw new System.NotImplementedException();
        }

        public List<Family> GetUserFamily(int id)
        {
            var userFamilies = new List<int>();
            var families = Get();
            var queryString = $"SELECT FamiliaId FROM FamiliaUsuario WHERE UsuarioId = {id}";

            userFamilies = CatchException(() =>
            {
                return Exec<int>(queryString);
            });

            return families.FindAll(x => userFamilies.Any(y => y == x.Id));
        }

        public bool Update(Family obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
