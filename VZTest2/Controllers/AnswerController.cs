using Microsoft.AspNetCore.Mvc;

namespace VZTest2.Controllers
{
    public class AnswerController : Controller
    {
        public IActionResult SaveText(int asnwerId, string? value)
        {
            return View();
        }
        public IActionResult SaveInt(int asnwerId, int? value)
        {
            return View();
        }
        public IActionResult SaveDouble(int asnwerId, double? value)
        {
            return View();
        }
        public IActionResult SaveDate(int asnwerId, DateTime? value)
        {
            if (value != null)
            {
                value = value.Value.Date;
            }
            return View();
        }
        public IActionResult SaveRadio(int asnwerId, int? value)
        {
            return View();
        }
        public IActionResult SaveSelect(int asnwerId, int? value)
        {
            return View();
        }
        public IActionResult SaveCheck(int asnwerId, List<int> values)
        {
            return View();
        }
    }
}
