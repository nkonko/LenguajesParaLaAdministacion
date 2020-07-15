using System;
using System.Web.UI;

namespace Tatooine.Views
{
    public partial class UserHome : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UserLabel.Text = "Bienvenido ";

                var user = (BE.User)Session["user"];

                if (user.Name != null)
                {
                    UserLabel.Text += user.Name;
                }
            }
        }
    }
}