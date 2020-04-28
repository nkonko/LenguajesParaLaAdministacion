namespace DAL
{
    using BE;
    using DAL.Interfaces;
    using DAL.Utils;
    using EasyEncryption;
    using System.Collections.Generic;
    using System.Linq;

    public class UserDao : BaseDao, IUserDao
    {
        public const string Key = "bZr2URKx";
        public const string Iv = "HNtgQw0w";

        private readonly IFamilyDao familyDao;
        private readonly IPatentDao patentDao;

        public bool Add(User obj)
        {
            var encryptedPsw = MD5.ComputeMD5Hash(obj.Password);
            var encryptedUsr = DES.Encrypt(obj.UserName, Key, Iv);

            var query = "INSERT INTO Userdb ([Name],[Password],[UserName]) VALUES (@Name, @Password, @UserName)";

            return CatchException(() =>
            {
                return Exec(
                    query,
                    new
                    {
                        @Name = obj.Name,
                        @Password = encryptedPsw,
                        @UserName = encryptedUsr
                    });
            });
        }

        public bool Delete(User obj)
        {
            throw new System.NotImplementedException();
        }

        public List<User> Get()
        {
            var query = "SELECT * FROM Userdb";

            return CatchException(() =>
            {
                return Exec<User>(query);
            });
        }

        public User GetUser(string userName)
        {
            var encryptedUsr = DES.Encrypt(userName, Key, Iv);

            var query = "SELECT * FROM Userdb WHERE UserName = @UserName";

            return CatchException(() =>
            {
                return Exec<User>(query,
                    new
                    {
                        @UserName = encryptedUsr
                    });
            }).FirstOrDefault();
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
