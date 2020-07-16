namespace Tatooine.Views
{
    using BE;
    using BLL.Interfaces;
    using BLL.Utils;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Bitacora : System.Web.UI.Page
    {
        private readonly IBitacoraBusiness bitacora = IOCContainer.Resolve<IBitacoraBusiness>();
        public List<BE.Bitacora> filas;
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = (User)Session["user"];

            if (user != null)
            {
                var isAdmin = user.Families.Any(f => f.Description == "Administrador");

                if (!isAdmin)
                {
                    Response.Redirect("Login.aspx");
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            filas = bitacora.GetBitacora();
        }
    }
}