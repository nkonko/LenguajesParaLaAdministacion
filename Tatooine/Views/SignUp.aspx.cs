namespace Tatooine.Views
{
    using BLL.Interfaces;
    using System;
    using Tatooine.App_Start;

    public partial class SignUp : System.Web.UI.Page
    {
        private IUserBusiness userBusiness = IOCContainer.Resolve<IUserBusiness>();
        private IIntegrityBusiness integrityBusiness = IOCContainer.Resolve<IIntegrityBusiness>();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            if (ConfirmInput.Text == PasswordInput.Text)
            {
                userBusiness.Add(new BE.User() { Name = NameInput.Text, Password = PasswordInput.Text, UserName = UsernameInput.Text });
                integrityBusiness.UpdateIntegrity("Userdb");
            }

        }
    }
}