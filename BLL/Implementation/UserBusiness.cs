namespace BLL
{
    using BE;
    using DAL.Interfaces;
    using EasyEncryption;
    using System.Collections.Generic;

    public class UserBusiness : IUserBusiness
    {
        private readonly IUserDao userDao;

        public UserBusiness(IUserDao userDao)
        {
            this.userDao = userDao;
        }

        public bool Update(User obj)
        {
            return userDao.Update(obj);
        }

        public bool Delete(User obj)
        {
            return userDao.Delete(obj);
        }

        public List<User> Get()
        {
            return userDao.Get();
        }

        public bool Add(User obj)
        {
            return userDao.Add(obj);
        }

        public User LogIn(string userName, string psw)
        {
            var dbUser = userDao.GetUser(userName);

            if (dbUser.Password == MD5.ComputeMD5Hash(psw))
            {
                return dbUser;
            }

            return null;
        }
    }
}
