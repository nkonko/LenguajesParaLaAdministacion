namespace BLL.Interfaces
{
    using BE;

    public interface IProductBusiness : ICRUD<Product>
    {
        Product GetProductById(int productId);
    }
}