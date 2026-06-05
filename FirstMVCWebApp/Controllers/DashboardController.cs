using FirstMVCWebApp.Data;
using FirstMVCWebApp.Dto;
using Microsoft.AspNetCore.Mvc;

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
    }
}
