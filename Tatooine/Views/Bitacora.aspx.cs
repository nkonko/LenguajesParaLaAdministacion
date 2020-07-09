namespace Tatooine.Views
{
    using BLL.Interfaces;
    using BLL.Utils;
    using System;

    public partial class Bitacora : System.Web.UI.Page
    {
        private readonly IBitacoraBusiness bitacora = IOCContainer.Resolve<IBitacoraBusiness>();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var result = bitacora.GetBitacora();
        }
    }
}