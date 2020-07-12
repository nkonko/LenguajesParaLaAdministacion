namespace Tatooine.Views
{
    using BLL.Interfaces;
    using BLL.Utils;
    using Microsoft.AspNet.Identity.Owin;
    using System;
    using System.Web.UI;
    using Tatooine.Helpers;

    public partial class Login : Page
    {
        private IAccountBusiness accountBusiness = IOCContainer.Resolve<IAccountBusiness>();
        private IIntegrityBusiness integrityBusiness = IOCContainer.Resolve<IIntegrityBusiness>();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            if (integrityBusiness.CheckIntegrity("Userdb"))
            {
                var loggedUser = accountBusiness.LogIn(UsernameInput.Text, PasswordInput.Text);
                Session["name"] = loggedUser.Name;

                switch (loggedUser.SignInStatus)
                {
                    case SignInStatus.Success:
                        Session["UserName"] = loggedUser.Name;
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
            else
            {
                this.SendAlert("Error en la integridad");
            }
        }
    }
}