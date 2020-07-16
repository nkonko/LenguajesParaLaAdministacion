
namespace Tatooine.Views
{
    using BLL.Interfaces;
    using BLL.Utils;
    using System;
    using System.Collections.Generic;

    public partial class RequestHistory : System.Web.UI.Page
    {
        private IAltaSolicitudBusiness accountBusiness = IOCContainer.Resolve<IAltaSolicitudBusiness>();

        public List<BE.AltaSolicitud> Solicitudes { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Solicitudes = accountBusiness.Get();
        }
    }
}