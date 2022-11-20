using Microsoft.AspNetCore.Mvc;

namespace VZTest2.Controllers
{
    public class StarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
