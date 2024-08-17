using WebApplication1.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Repos
{
    public class ProductRepository : IProductRepository
    {
        private static readonly List<Product> Products = new List<Product>();

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return Products;
        }
    }
}
