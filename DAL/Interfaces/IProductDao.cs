namespace DAL.Interfaces
{
    using BE;

    public interface IProductDao : ICRUD<Product>
    {
        Product GetProductById(int id);
    }
}