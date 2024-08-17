using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repos;

namespace WebApplication1.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public CartController(ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public IActionResult Cart()
        {
            var cartItems = _cartRepository.GetCartItems();
            var totalPrice = _cartRepository.GetTotalPrice();

            ViewBag.CartItems = cartItems;
            ViewBag.TotalPrice = totalPrice;

            return View(cartItems); 
        }


        [HttpPost]
        public IActionResult AddToCart([FromBody] CartItem request)
        {
            if (request?.Product?.Name != null)
            {
                var product = _productRepository.GetProductByName(request.Product.Name);
                if (product != null)
                {
                    _cartRepository.AddToCart(product, request.Quantity);
                    return Json(new { success = true });
                }
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public IActionResult RemoveFromCart([FromBody] string productName)
        {
            _cartRepository.RemoveFromCart(productName);
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult ClearCart()
        {
            _cartRepository.ClearCart();
            return RedirectToAction("Cart");
        }
    }
}
