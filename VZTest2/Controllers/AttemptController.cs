using Microsoft.AspNetCore.Mvc;

namespace VZTest2.Controllers
{
    public class AttemptController : Controller
    {
        public IActionResult Take()
        {
            return View();
        }
        public IActionResult Check()
        {
            return View();
        }
    }
}
