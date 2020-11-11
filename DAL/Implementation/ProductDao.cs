namespace DAL.Implementation
{
    using BE;
    using DAL.Interfaces;
    using DAL.Utils;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductDao : BaseDao, IProductDao
    {
        public bool Add(Product obj)
        {
            var query = $"INSERT INTO Product VALUES(@Description, @Price)";

            return CatchException(() =>
            {
                return Exec(
                    query,
                    new
                    {
                        @Description = obj.Description,
                        @Price = obj.Price
                    });
            });
        }

        public bool Delete(Product obj)
        {
            var query = "DELETE FROM Product WHERE Id = @Id";

            return CatchException(() =>
            {
                return Exec(
                    query,
                    new
                    {
                        @Id = obj.Id
                    });
            });

        }

        public List<Product> Get()
        {
            var query = "SELECT * FROM Product";

            return CatchException(() =>
            {
                return Exec<Product>(query);
            });
        }

        public Product GetProductById(int id)
        {
            var products = Get();

            return products.FirstOrDefault(p => p.Id == id);
        }

        public bool Update(Product obj)
        {
            var query = "UPDATE Product SET Description = @Description, Price = @Price WHERE Id = @Id ";

            return CatchException(() =>
            {
                return Exec(
                    query,
                    new
                    {
                        @Description = obj.Description,
                        @Price = obj.Price,
                        @Id = obj.Id
                    });
            });
        }
    }
}
