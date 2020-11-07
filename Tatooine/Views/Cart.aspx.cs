namespace Tatooine.Views
{
    using BE;
    using BLL.Interfaces;
    using BLL.Utils;
    using System;
    using System.Collections.Generic;
    using Tatooine.Helpers;

    public partial class Cart : System.Web.UI.Page
    {
        private ICartBusiness cartBusiness = IOCContainer.Resolve<ICartBusiness>();

        public BE.Cart cart { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var user = (User)Session["user"];

            if (user == null)
            {
                Response.Redirect("Login.aspx");
            }

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cart = cartBusiness.GetCart();

                if (cart == null)
                {
                    cart = new BE.Cart() { products = new List<ProductsInCart>() };
                }
            }
        }

        protected void finish(object sender, EventArgs e)
        {
            cart = cartBusiness.GetCart();

            if (cart != null && cart.products.Count > 0)
            {
                cart = cartBusiness.CleanTheCart();
                PageExtensions.ShowInformativeAlert(this, "success", "Exito", "Tu pedido fue registrado con exito", 1, 1000);
            }
            else
            {
                cart = cartBusiness.CleanTheCart();
                PageExtensions.ShowInformativeAlert(this, "error", "No hay productos", "Agrega algo al carrito", 1, 1000);
            }
        }
    }
}