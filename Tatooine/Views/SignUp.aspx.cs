using BLL;
using System;
using Tatooine.App_Start;

namespace Tatooine.Views
{
    public partial class SignUp : System.Web.UI.Page
    {
        private IUserBusiness userBusiness = IOCContainer.Resolve<IUserBusiness>();

        protected void Page_Load(object sender, EventArgs e)
        {
            userBusiness.Add(new BE.User() { Name = "Juan", Password = "123", UserName = "Juan123" });
        }
    }
}