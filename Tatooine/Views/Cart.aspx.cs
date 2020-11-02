namespace Tatooine.Views
{
    using BLL.Interfaces;
    using BLL.Utils;
    using System;

    public partial class Cart : System.Web.UI.Page
    {
        private ICartBusiness cartBusiness = IOCContainer.Resolve<ICartBusiness>();

        public BE.Cart cart { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cart = cartBusiness.GetCart();
            }
        }
    }
}