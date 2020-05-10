namespace DAL.Interfaces
{
    using BE;

    public interface IUserDao : ICRUD<User>
    {
        User GetUser(string userName);
    }
}
