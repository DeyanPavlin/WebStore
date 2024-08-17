using WebApplication1.Models;

namespace WebApplication1.Repos
{
    public class ProductRepository : IProductRepository
    {
        private static readonly List<Product> Products = new List<Product>();

        static ProductRepository()
        {
            //store
            Products = new List<Product>
            {
                new Product { Name = "H. Potter Mystery Box", Info = "This is the perfect gift for a \"Harry Potter Fan\"!", Price = 22.02m, ImageUrl = "/images/box.png" },
                new Product { Name = "P. Jackson Mystery Box", Info = "This is the perfect gift for a \"Percy Jackson Fan\"!", Price = 56.00m, ImageUrl = "/images/box.png" },
                new Product { Name = "GOT Mystery Box", Info = "This is the perfect gift for a fan of \"Game of Thrones!\"", Price = 30.99m, ImageUrl = "/images/box.png" },
                new Product { Name = "Manga Mystery Box", Info = "This is the perfect gift for manga fans", Price = 14.00m, ImageUrl = "/images/box.png" }
            };
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return Products;
        }

        public Product GetProductByName(string name)
        {
            return Products.FirstOrDefault(p => p.Name == name);
        }

        public void DeleteProduct(string name)
        {
            var product = Products.FirstOrDefault(p => p.Name == name);
            if (product != null)
            {
                Products.Remove(product);
            }
        }
    }
}
