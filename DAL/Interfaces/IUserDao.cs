namespace DAL.Interfaces
{
    using BE;
    using System.Collections.Generic;

    public interface IUserDao : ICRUD<User>
    {
        List<User> GetUserWithPatentAndFamily();

        User GetUser(int id);

        List<Patent> GetUserPatent(int id);
    }
}
