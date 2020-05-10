namespace BLL.Interfaces
{
    using BE;

    public interface IAccountBusiness
    {
        User LogIn(string userName, string psw);
    }
}