using Microsoft.AspNetCore.Mvc;

namespace VZTest2.Controllers
{
    public class ThemeController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
        public IActionResult Details(int id) 
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            return View();
        }
    }
}
