using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationUltimatum.Data;
using WebApplicationUltimatum.Models;

namespace WebApplicationUltimatum.Controllers
{
    public class ProductsController : ApiController
    {
        private NorthwindEntitiesDBContext db = new NorthwindEntitiesDBContext();
        private Dictionary<string, string> products = new Dictionary<string, string>();
        // GET: api/Products
       

        public List<Product> GetProducts()
        {
           return ProductData.List();
        }

        // GET: api/Products/5
        public Product GetProduct(int id)
        {
            return ProductData.Get(id);
        }


        // POST: api/Products
        //ADD
        public bool Post([FromBody]Product product)
        {
            ///Sumary
            ///I need to programmer a read string for add to products key
            ///Necesito programar una lectura de string para adicionar a las variables y llaves de productos
            ///Sumary end
            return ProductData.Register(product); 
          
        }
       

        // PUT: api/Products/5
        public bool Put([FromBody]Product product)        
        {
            return ProductData.Update(product);
        }

        // DELETE: api/Products/5

        public bool Delete(int id)
        {
            return ProductData.Delete(id);

        }

    }
}
