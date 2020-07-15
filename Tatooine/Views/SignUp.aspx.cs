namespace Tatooine.Views
{
    using BLL.Interfaces;
    using BLL.Utils;
    using log4net;
    using System;
    using Tatooine.Helpers;

    public partial class SignUp : System.Web.UI.Page
    {
        private IUserBusiness userBusiness = IOCContainer.Resolve<IUserBusiness>();
        private IIntegrityBusiness integrityBusiness = IOCContainer.Resolve<IIntegrityBusiness>();
        private IBitacoraBusiness bitacoraBusiness = IOCContainer.Resolve<IBitacoraBusiness>();

        ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            if (ConfirmInput.Text == PasswordInput.Text)
            {
                userBusiness.Add(new BE.User() { Name = NameInput.Text, Password = PasswordInput.Text, UserName = UsernameInput.Text });
                integrityBusiness.UpdateIntegrity();
                GlobalContext.Properties["usuario"] = UsernameInput.Text;
                Log4netExtensions.Baja(log, "Se ha creado un nuevo usuario");
                bitacoraBusiness.UpdateBitacoraDvh();

            }
            this.SendAlert("Usuario creado");
        }
    }
}