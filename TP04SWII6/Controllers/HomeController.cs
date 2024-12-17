using Microsoft.AspNetCore.Mvc;

namespace TP04SWII6.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
