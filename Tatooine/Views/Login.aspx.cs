namespace Tatooine.Views
{
    using BLL.Interfaces;
    using Microsoft.AspNet.Identity.Owin;
    using System;
    using System.Web.UI;
    using Tatooine.App_Start;

    public partial class Login : Page
    {
        private IAccountBusiness accountBusiness = IOCContainer.Resolve<IAccountBusiness>();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            var loggedUser = accountBusiness.LogIn(UsernameInput.Text, PasswordInput.Text);
            Session["name"] = loggedUser.Name;

            switch (loggedUser.SignInStatus)
            {
                case SignInStatus.Success:
                    Response.Redirect("/Views/UserHome");
                    break;
                case SignInStatus.LockedOut:
                    Response.Redirect("/Views/Lockout");
                    break;
                case SignInStatus.Failure:
                default:
                    Response.Write("Intento de inicio de sesión no válido");
                    break;
            }
        }
    }
}