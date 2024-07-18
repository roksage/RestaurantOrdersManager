using Microsoft.AspNetCore.Mvc;

namespace RestaurantOrdersManager.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
