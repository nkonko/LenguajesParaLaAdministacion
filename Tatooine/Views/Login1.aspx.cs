using BLL;
using System;
using Tatooine.App_Start;

namespace Tatooine.Views
{
    public partial class Login1 : System.Web.UI.Page
    {
        private IUserBusiness userBusiness = IOCContainer.Resolve<IUserBusiness>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            var userSession = userBusiness.LogIn(UsernameInput.Text, PasswordInput.Text);

            Session["UserName"] = userSession.UserName;
            Session["Pwd"] = userSession.Password;

            Response.Redirect("Contact.aspx");
        }
    }
}