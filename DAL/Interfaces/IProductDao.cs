namespace DAL.Interfaces
{
    using BE;

    public interface IProductDao : ICRUD<Product>
    {
        decimal GetPrice(int quantity);

        Product GetProductById(int id);
    }
}