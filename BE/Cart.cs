namespace BE
{
    using System.Collections.Generic;

    public class Cart
    {
        public List<ProductsInCart> Products { get; set; } = new List<ProductsInCart>();

        public decimal GetTotalOfCart()
        {
            var total = 0.0m;

            foreach (var product in Products)
            {
                total += product.GetTotal();
            }

            return total;
        }
    }
}
