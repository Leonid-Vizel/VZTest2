using Microsoft.AspNetCore.Mvc;

namespace VZTest2.Controllers
{
    public class QuestionController : Controller
    {
        public IActionResult Create(int theme)
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            return View();
        }
    }
}
