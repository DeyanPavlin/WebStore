using WebApplication1.Models;

namespace WebApplication1.Repos
{
    public class CartService : ICartRepository
    {
        private readonly List<CartItem> _cartItems = new List<CartItem>();

        public CartService()
        {
        }

        public void AddToCart(Product product, int quantity)
        {
            var existingItem = _cartItems.FirstOrDefault(item => item.Product.Name == product.Name);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _cartItems.Add(new CartItem { Product = product, Quantity = quantity });
            }
        }

        public void ClearCart()
        {
            _cartItems.Clear();
        }

        public IEnumerable<CartItem> GetCartItems()
        {
            return _cartItems;
        }

        public decimal GetTotalPrice()
        {
            return _cartItems.Sum(item => item.TotalPrice);
        }

        public void RemoveFromCart(string productName)
        {
            var item = _cartItems.FirstOrDefault(cartItem => cartItem.Product.Name == productName);
            item.Quantity--;
            if (item != null && item.Quantity <= 0)
            {
                _cartItems.Remove(item);
            }
        }
    }
}
