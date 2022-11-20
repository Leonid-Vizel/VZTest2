using Microsoft.AspNetCore.Mvc;

namespace VZTest2.Controllers
{
    public class AccessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
