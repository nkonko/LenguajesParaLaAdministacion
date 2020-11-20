namespace Tatooine.Views
{
    using BE;
    using BLL.Interfaces;
    using BLL.Utils;
    using System;
    using System.Collections.Generic;
    using System.Web.UI.WebControls;
    using Tatooine.Helpers;

    public partial class Products : System.Web.UI.Page
    {
        private IProductBusiness productBusiness = IOCContainer.Resolve<IProductBusiness>();

        private ICartBusiness cartBusiness = IOCContainer.Resolve<ICartBusiness>();

        public List<Product> ProductList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckLogin();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CheckLogin();
                ProductList = productBusiness.Get();
                Repeater1.DataSource = ProductList;
                Repeater1.DataBind();
            }
        }


        protected void AddToCart(object sender, EventArgs e)
        {
            var btn = (Button)sender;

            foreach (RepeaterItem item in Repeater1.Items)
            {
                var textBox = (TextBox)item.FindControl("txtQuantity");

                if (textBox != null)
                {
                    if (textBox.Text != string.Empty)
                    {
                        var quantity = textBox.Text;
                        cartBusiness.AddProductToCart(int.Parse(btn.CommandArgument), int.Parse(quantity));
                        PageExtensions.ShowInformativeAlert(this, "success", "Exito", "Se han agregado los productos a su carrito", 1, 1000);
                    }

                    textBox.Text = string.Empty;
                }
            }
        }

        private void CheckLogin()
        {
            var user = (User)Session["user"];

            if (user == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}