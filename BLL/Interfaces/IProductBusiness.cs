namespace BLL.Interfaces
{
    using BE;

    public interface IProductBusiness : ICRUD<Product>
    {
        decimal GetPrice(int quantity);

        Product GetProductById(int productId);
    }
}