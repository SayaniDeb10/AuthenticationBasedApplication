using FirstMVCWebApp.Data;
using FirstMVCWebApp.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCWebApp.Controllers
{
    public class DashboardController(AppDbContext context) : Controller
    {
        public IActionResult Index()
        {
            //We use .Select() to project or map Entity objects into DTO objects.
            //This allows us to send only the required data to the View instead of exposing the entire database entity.
            //ToList() executes the query and returns the result as a List<ProductDto>, which is then passed to the Razor View as the Model.
            var list = context.Products.Select(x => new ProductDto { Id = x.Id, Colour = x.Colour, 
                Description = x.Description, Price = x.Price, ProductName = x.ProductName}).ToList();
            return View(list);
        }
        public IActionResult ProductForm() => View();
      
        //It was for create or Add product (Old)
        public async Task<IActionResult> CreateProduct(ProductDto dto)
        {
            if(dto == null)
            {
                ViewBag.ErrorMessage = "please Fill All Details.";
                return View("ProductForm");
            }
            try
            {
                context.Products.Add(new Models.Product
                {
                    Price = dto.Price,
                    Description = dto.Description,
                    ProductName = dto.ProductName,
                    Colour = dto.Colour
                });

                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return Content(
                   $"Message: {ex.Message}\n\n" +
                   $"Inner Exception: {ex.InnerException?.Message}"
   );
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == productId);
            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditProduct(int productId)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == productId);

            if(product == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var dto = new ProductDto
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    Description = product.Description,
                    Price = product.Price,
                    Colour = product.Colour
                };
                return View("ProductForm", dto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveProduct(ProductDto dto)
        {
            if (dto == null)
            {
                ViewBag.ErrorMessage = "please Fill All Details.";
                return View("ProductForm");
            }
            try
            {
                if(dto.Id == 0)
                {
                    //Add Product
                    context.Products.Add(new Models.Product
                    {
                        ProductName = dto.ProductName,
                        Description = dto.Description,
                        Price = dto.Price,
                        Colour = dto.Colour
                    });
                }
                else
                {
                    //Edit Product
                    var product = await context.Products.FirstOrDefaultAsync(
                        x=>x.Id == dto.Id);

                    if(product == null)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        product.ProductName = dto.ProductName;
                        product.Description = dto.Description;
                        product.Price = dto.Price;
                        product.Colour = dto.Colour;
                    }
                }
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception ex) { return Content($"Message : {ex.Message}"); }
            
        }
    }
}
