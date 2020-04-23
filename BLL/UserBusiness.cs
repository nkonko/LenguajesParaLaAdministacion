namespace BLL
{
    using BE;
    using DAL.Interfaces;
    using System.Collections.Generic;

    public class UserBusiness : ICRUD<User>
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
    }
}
