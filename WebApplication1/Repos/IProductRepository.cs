using System.Collections.Generic;
using WebApplication1.Controllers;

namespace WebApplication1.Repos
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        IEnumerable<Product> GetAllProducts();
    }
}
