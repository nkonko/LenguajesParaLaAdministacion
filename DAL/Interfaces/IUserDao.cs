namespace DAL.Interfaces
{
    using BE;
    using System.Collections.Generic;

    public interface IUserDao : ICRUD<User>
    {
        List<User> GetUserWithPatentAndFamily();

        User GetUser(string UserName);

        List<Patent> GetUserPatent(int id);
    }
}
