namespace Tatooine.Views
{
    using BE;
    using BLL.Interfaces;
    using BLL.Utils;
    using System;
    using System.Collections.Generic;
    using System.Web.UI.WebControls;

    public partial class Products : System.Web.UI.Page
    {
        private IProductBusiness productBusiness = IOCContainer.Resolve<IProductBusiness>();

        private ICartBusiness cartBusiness = IOCContainer.Resolve<ICartBusiness>();

        public List<Product> ProductList { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ProductList = productBusiness.Get();
                Repeater1.DataSource = ProductList;
                Repeater1.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
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
                    }
                }
            }

        }
    }
}