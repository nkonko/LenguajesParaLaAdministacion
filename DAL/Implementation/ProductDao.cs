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
            throw new System.NotImplementedException();
        }

        public bool Delete(Product obj)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public decimal GetPrice(int quantity)
        {
            return 0;
        }
    }
}
