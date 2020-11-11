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
            return productDao.Add(obj);
        }

        public bool Delete(Product obj)
        {
            return productDao.Delete(obj);
        }

        public List<Product> Get()
        {
            return productDao.Get();
        }

        public Product GetProductById(int productId)
        {
            return productDao.GetProductById(productId);
        }

        public bool Update(Product obj)
        {
            return productDao.Update(obj);
        }
    }
}
