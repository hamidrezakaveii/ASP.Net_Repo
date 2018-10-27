using Demo_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Demo_WebAPI.Controllers
{
    public class ProductsController : ApiController
    {

        Product[] products = new Product[]
        {
            new Product {Id = 1, Name="Tomato Soup", Category="Groceries", Price = 1 },
            new Product {Id = 2, Name="Yo-yo", Category="Toys", Price = 3.75M },
            new Product {Id = 3, Name="Hammer", Category="Hardware", Price = 16.99M }
        };
        
        
        
        // [Route("/all")]
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }



        //Products/GetProduct/id
        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault( (p) => p.Id == id);

            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
            
        }



    }
}