using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RabitMqProductAPI.Models;
using RabitMqProductAPI.RabitMQ;
using RabitMqProductAPI.Services;
using System.ComponentModel;

namespace RabitMqProductAPI.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IRabitMQProducer _rabitMQProducer;
         
        public ProductController(IProductService _productService, IRabitMQProducer rabitMQProducer)
        {
            productService = _productService;
            _rabitMQProducer = rabitMQProducer;
        }
        //The ProductController class declares dependencies as constructor parameters.
        //When an instance of ProductController is created, the DI container automatically resolves these dependencies and injects them into the constructor.
        //This is how Dependency Injection(DI) is achieved via constructor injection

        [HttpGet("productlist")]
        //public IEnumerable<Product> ProductList()
        //{
        //    var productList =  productService.GetProductList();
        //    return productList;
        //}

        public async Task<IEnumerable<Product>> ProductList()
        {
            var productList = await productService.GetProductList();
            return productList;
        }
        [HttpGet("getproductbyid")]
        public Product GetProductById(int Id)
        {
            return productService.GetProductById(Id);
        }
        [HttpPost("addproduct")]
        public Product AddProduct(Product product)
        {
            var productData = productService.AddProduct(product);
            //send the inserted product data to the queue and consumer will listening this data from queue
            _rabitMQProducer.SendProductMessage(productData);
            //sendproductmessage is the method that we defined in the rabitmqproducer, so when that is called, it gets sent to the queue
            return productData;

            //so when we add a product, it must be sent to the queue, and the console opplication must read from the queue
        }
        [HttpPut("updateproduct")]
        public Product UpdateProduct(Product product)
        {
            return productService.UpdateProduct(product);
        }
        [HttpDelete("deleteproduct")]
        public bool DeleteProduct(int Id)
        {
            return productService.DeleteProduct(Id);
        }
    }
}
