using BE;
using BLL.Interfaces;
using BLL.Utils;
using System.Collections.Generic;
using System.Web.Http;

namespace Tatooine.Controllers
{
    public class ProductsController : ApiController
    {
        private IProductBusiness productBusiness = IOCContainer.Resolve<IProductBusiness>();

        //GET api/<controller>/
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var products = productBusiness.Get();

            return products;
        }

        //POST api/<controller>/
        [HttpPost]
        public IHttpActionResult Post(Product product)
        {
            var response = false;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (product != null)
            {
                response = productBusiness.Add(product);
            }

            if (!response)
            {
                return InternalServerError();
            }

            return Ok();
        }

        //GET api/<controller>/
        [HttpGet]
        public Product GetById(int Id)
        {
            var product = productBusiness.GetProductById(Id);

            return product;
        }

        //UPDATE api/<controller>/
        [HttpPut]
        public IHttpActionResult Update(Product product)
        {
            var response = false;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (product != null)
            {
                response = productBusiness.Update(product);
            }

            if (!response)
            {
                return InternalServerError();
            }

            return Ok();
        }

        //DELETE api/<controller>/
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var response = false;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != 0)
            {
                response = productBusiness.Delete(new Product() { Id = id });
            }

            if (!response)
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}
