using Microsoft.AspNetCore.Mvc;
using VZTest2.Filters;

namespace VZTest2.Controllers
{
    public class QuestionController : Controller
    {
        #region Preview
        [AuthFilter]
        public IActionResult Preview(int id)
        {
            return View();
        }
        #endregion
        #region Create
        [AuthFilter]
        public IActionResult Create(int theme)
        {
            return View();
        }
        #endregion
        #region Edit
        [AuthFilter]
        public IActionResult Edit(int id)
        {
            return View();
        }
        #endregion
    }
}
