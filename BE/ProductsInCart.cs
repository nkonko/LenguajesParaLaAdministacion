namespace BE
{
    public class ProductsInCart
    {
        public int Quantity { get; set; }

        public int IdProduct { get; set; }

        public Product Product { get; set; }

        public decimal GetTotal()
        {
            return Product.Price * Quantity;
        }
    }
}
