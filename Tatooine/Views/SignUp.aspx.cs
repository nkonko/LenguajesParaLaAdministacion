namespace Tatooine.Views
{
    using BLL.Interfaces;
    using BLL.Utils;
    using log4net;
    using System;

    public partial class SignUp : System.Web.UI.Page
    {
        private IUserBusiness userBusiness = IOCContainer.Resolve<IUserBusiness>();
        private IIntegrityBusiness integrityBusiness = IOCContainer.Resolve<IIntegrityBusiness>();

        ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            if (ConfirmInput.Text == PasswordInput.Text)
            {
                userBusiness.Add(new BE.User() { Name = NameInput.Text, Password = PasswordInput.Text, UserName = UsernameInput.Text });
                integrityBusiness.UpdateIntegrity("Userdb");
                GlobalContext.Properties["usuario"] = UsernameInput.Text;
                Log4netExtensions.Baja(log, "Se ha creado un nuevo usuario");
            }

        }
    }
}