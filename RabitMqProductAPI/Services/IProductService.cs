using RabitMqProductAPI.Models;

namespace RabitMqProductAPI.Services
{
    public interface IProductService
    {
        //public IEnumerable< Product > GetProductList();
        //to read the data in the collection, but they cannot be used to modify the underlying collection.

        public interface IProductService
        {
            Task<IEnumerable<Product>> GetProductList();
        }

        public Product GetProductById(int id );
        public Product AddProduct( Product product );
        public Product UpdateProduct( Product product );
        public bool DeleteProduct(int id );
        Task<IEnumerable<Product>> GetProductList();
    }
}
