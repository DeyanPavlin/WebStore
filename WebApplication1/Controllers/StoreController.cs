using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repos;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StoreController : Controller
    {
        private readonly IProductRepository _productRepository;

        public StoreController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Store()
        {
            var products = _productRepository.GetAllProducts();
            return View(products);
        }

        [HttpPost]
        public IActionResult AddProduct(string productName, string productInfo, decimal productPrice, IFormFile productImage)
        {
            try
            {
                if (productImage != null && productImage.Length > 0)
                {
                    var fileName = Path.GetFileName(productImage.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        productImage.CopyTo(fileStream);
                    }

                    var newProduct = new Product
                    {
                        Name = productName.ToUpper(),
                        Info = productInfo,
                        Price = productPrice,
                        ImageUrl = $"/images/{fileName}"
                    };

                    _productRepository.AddProduct(newProduct);

                    return Json(new { success = true });
                }

                return Json(new { success = false, message = "Invalid image file." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
