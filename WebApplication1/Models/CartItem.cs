using WebApplication1.Controllers;

namespace WebApplication1.Models
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => Product.Price * Quantity;
    }
}
