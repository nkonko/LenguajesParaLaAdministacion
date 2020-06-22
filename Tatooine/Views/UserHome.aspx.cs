using System;

namespace Tatooine.Views
{
    public partial class UserHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UserLabel.Text = "Bienvenido ";

                if (Session["name"] != null)
                {
                    UserLabel.Text += Session["name"].ToString();
                }
            }
        }
    }
}