using Microsoft.AspNetCore.Mvc;

namespace VZTest2.Controllers
{
    public class ImageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
