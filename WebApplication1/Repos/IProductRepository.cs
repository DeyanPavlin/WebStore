using WebApplication1.Models;

namespace WebApplication1.Repos
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        IEnumerable<Product> GetAllProducts();
        Product GetProductByName(string name);
        void DeleteProduct(string name);
    }
}
