namespace BLL.Interfaces
{
    using BE;

    public interface IUserBusiness : ICRUD<User>
    {
        User GetEncriptedUser(string userName);
    }
}