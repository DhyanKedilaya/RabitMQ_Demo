using Microsoft.EntityFrameworkCore;
using RabitMqProductAPI.Data;
using RabitMqProductAPI.Models;

namespace RabitMqProductAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly DbContextClass _dbContext;

        public ProductService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        //public IEnumerable<Product> GetProductList()
        //{
        //    return _dbContext.Products.ToList();
        //}

        public async Task<IEnumerable<Product>> GetProductList()
        {
            return await _dbContext.Products.ToListAsync();
        }
        //public Product GetProductById(int id)
        //{
        //    return (Product)_dbContext.Products.Where(x => x.ProductId == id);
        //    //return _dbContext.Products.Where(x => x.ProductId == id);
        //}
        public Product GetProductById(int productId)
        {
             
            var product = _dbContext.Products.FirstOrDefault(p => p.ProductId == productId);
            return product;
        }

        public Product AddProduct(Product product)
        {
            var result = _dbContext.Products.Add(product);
            _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public Product UpdateProduct(Product product)
        {
            var result = _dbContext.Products.Update(product);
            _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public bool DeleteProduct(int Id)
        {
            var filteredData = _dbContext.Products.Where(x => x.ProductId == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }

    }
}
