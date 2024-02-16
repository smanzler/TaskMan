using Microsoft.AspNetCore.Mvc;

namespace TaskMan.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
