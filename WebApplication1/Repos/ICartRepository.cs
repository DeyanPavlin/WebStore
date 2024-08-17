using WebApplication1.Models;

namespace WebApplication1.Repos
{
    public interface ICartRepository
    {
        void AddToCart(Product product, int quantity);
        void RemoveFromCart(string productName);
        public IEnumerable<CartItem> GetCartItems();
        public decimal GetTotalPrice();
        public void ClearCart();

    }
}
