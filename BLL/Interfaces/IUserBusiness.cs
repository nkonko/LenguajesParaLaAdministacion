namespace BLL
{
    using BE;

    public interface IUserBusiness : ICRUD<User>
    {
        User LogIn(string userName, string psw);
    }
}