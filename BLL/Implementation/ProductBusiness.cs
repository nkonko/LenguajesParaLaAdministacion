namespace BLL.Implementation
{
    using BE;
    using BLL.Interfaces;
    using DAL.Interfaces;
    using System.Collections.Generic;

    public class ProductBusiness : IProductBusiness
    {
        private readonly IProductDao productDao;

        public ProductBusiness(IProductDao productDao)
        {
            this.productDao = productDao;
        }

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
            return productDao.Get();
        }

        public decimal GetPrice(int quantity)
        {
            return productDao.GetPrice(quantity);
        }

        public Product GetProductById(int productId)
        {
            return productDao.GetProductById(productId);
        }

        public bool Update(Product obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
