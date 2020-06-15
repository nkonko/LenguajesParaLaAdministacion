﻿namespace DAL
{
    using BE;
    using DAL.Interfaces;
    using DAL.Utils;
    using EasyEncryption;
    using System.Collections.Generic;
    using System.Linq;

    public class UserDao : BaseDao, IUserDao
    {
        private const string Key = "bZr2URKx";
        private const string Iv = "HNtgQw0w";

        private readonly IDigitVerifier verifier;

        public UserDao(IDigitVerifier verifier)
        {
            this.verifier = verifier;
        }

        public bool Add(User obj)
        {
            var encryptedPsw = MD5.ComputeMD5Hash(obj.Password);
            var encryptedUsr = DES.Encrypt(obj.UserName, Key, Iv);
            var finalString = obj.Name + encryptedPsw + encryptedUsr + 0;

            var query = "INSERT INTO Userdb ([Name],[Password],[UserName],[LoginAttempt],[DVH]) VALUES (@Name, @Password, @UserName, @LoginAttempt, @Dvh)";

            return CatchException(() =>
            {
                return Exec(
                    query,
                    new
                    {
                        @Name = obj.Name,
                        @Password = encryptedPsw,
                        @UserName = encryptedUsr,
                        @LoginAttempt = 0,
                        @Dvh = verifier.CalculateDVH(finalString)
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
