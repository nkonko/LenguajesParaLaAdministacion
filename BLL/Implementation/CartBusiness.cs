namespace BLL.Implementation
{
    using BE;
    using BLL.Interfaces;
    using System.Collections.Generic;

    public class CartBusiness : ICartBusiness
    {
        private readonly IProductBusiness productBusiness;

        public CartBusiness(IProductBusiness productBusiness)
        {
            this.productBusiness = productBusiness;
        }

        public Cart Cart { get; set; }

        public void AddProductToCart(int productId, int quantity)
        {
            if (Cart == null)
            {
                Cart = new Cart();
            }

            var product = productBusiness.GetProductById(productId);

            Cart.Products.Add(new ProductsInCart() { Product = product, Quantity = quantity, IdProduct = productId });
        }

        public Cart GetCart()
        {
            return Cart;
        }

        public Cart CleanTheCart()
        {
            Cart = new Cart() { Products = new List<ProductsInCart>() };
            return Cart;
        }
    }
}
