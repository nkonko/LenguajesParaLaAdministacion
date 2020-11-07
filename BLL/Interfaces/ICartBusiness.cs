namespace BLL.Interfaces
{
    using BE;

    public interface ICartBusiness
    {
        void AddProductToCart(int productId, int quantity);

        Cart GetCart();

        Cart CleanTheCart();
    }
}