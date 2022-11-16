using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VZTest2.Filters;
using VZTest2.Models;

namespace VZTest2.Controllers
{
    public class HomeController : Controller
    {
        [AuthLoader]
        public IActionResult Index()
        {
            return View();
        }
        [AuthLoader]
        public IActionResult Privacy()
        {
            return View();
        }
        [AuthLoader]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}