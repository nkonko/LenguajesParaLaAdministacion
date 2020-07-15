namespace Tatooine.Views
{
    using BE;
    using BLL.Interfaces;
    using BLL.Utils;
    using Microsoft.AspNet.Identity.Owin;
    using System;
    using System.Linq;
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
            var loggedUser = accountBusiness.LogIn(UsernameInput.Text, PasswordInput.Text);
            Session["user"] = loggedUser;


            if (integrityBusiness.CheckIntegrity())
            {

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
                if (loggedUser != null && isAdmin(loggedUser))
                {
                    PageExtensions.ShowInteractiveAlert(this, "error", "Error", "Error en la integridad de la base de datos. Por favor, recalcule los dígitos.", "Calcular Dígitos");
                }
                else
                {
                    PageExtensions.ShowInformativeAlert(this, "error", "Error", "Error en la integridad de la base de datos. Por favor, comuniquese con el administrador.", 1, 1000);
                }

            }
        }

        private bool isAdmin(User loggedUser)
        {
            return loggedUser.Families.Contains(loggedUser.Families.Where(f => f.Description == "Administrator").FirstOrDefault());
        }

        public void AlertPageAction(object sender, EventArgs e)
        {
            integrityBusiness.UpdateIntegrity();
        }
    }
}