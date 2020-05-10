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

        public bool Add(User obj)
        {
            var encryptedPsw = MD5.ComputeMD5Hash(obj.Password);
            var encryptedUsr = DES.Encrypt(obj.UserName, Key, Iv);

            var query = "INSERT INTO Userdb ([Name],[Password],[UserName],[LoginAttempt]) VALUES (@Name, @Password, @UserName, @LoginAttempt)";

            return CatchException(() =>
            {
                return Exec(
                    query,
                    new
                    {
                        @Name = obj.Name,
                        @Password = encryptedPsw,
                        @UserName = encryptedUsr,
                        @LoginAttempt = 0
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
                return Exec<User>(
                    query,
                    new
                    {
                        @UserName = encryptedUsr
                    });
            }).FirstOrDefault();
        }

        public bool Update(User obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
