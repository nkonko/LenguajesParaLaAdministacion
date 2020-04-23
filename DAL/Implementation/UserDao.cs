namespace DAL
{
    using BE;
    using DAL.Interfaces;
    using DAL.Utils;
    using System.Collections.Generic;

    public class UserDao : BaseDao, IUserDao
    {
        private readonly IFamilyDao familyDao;
        private readonly IPatentDao patentDao;

        public bool Add(User obj)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(User obj)
        {
            throw new System.NotImplementedException();
        }

        public List<User> Get()
        {
            throw new System.NotImplementedException();
        }

        public User GetUser(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Patent> GetUserPatent(int id)
        {
            var queryString = $"SELECT UsuarioPatente.IdPatente, Patente.Descripcion, UsuarioPatente.Negada FROM UsuarioPatente INNER JOIN Patente ON UsuarioPatente.IdPatente = Patente.IdPatente WHERE UsuarioId = {id}";

            return CatchException(() =>
            {
                return Exec<Patent>(queryString);
            });
        }

        public List<User> GetUserWithPatentAndFamily()
        {
            var users = Get();

            foreach (var user in users)
            {
                user.Family = new List<Family>();
                user.Patent = new List<Patent>();

                user.Family = familyDao.GetUserFamily(user.Id);
                user.Patent = patentDao.GetUserPatents(user.Id);
            }

            return users;
        }

        public bool Update(User obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
