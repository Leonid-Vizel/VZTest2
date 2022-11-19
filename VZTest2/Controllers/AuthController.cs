using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VZTest2.Data.UnitOfWorks;
using VZTest2.Filters;
using VZTest2.Instruments;
using VZTest2.Models.Data;
using VZTest2.Models.View;

namespace VZTest2.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthUnitOfWork _unitOfWork;
        public AuthController(IAuthUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region Register
        [AuthLoader]
        public IActionResult Register() => View();
        [HttpPost]
        [AuthLoader]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (await _unitOfWork.UserRepository.AnyAsync(x=>x.Login.ToLower().Equals(model.Login)))
            {
                ModelState.AddModelError("Login","Этот логин уже занят");
                return View(model);
            }
            model.Login = model.Login.ToLower();
            model.Password = Hasher.ComputeHash(model.Login, model.Password);
            await _unitOfWork.UserRepository.AddAsync(new User()
            {
                Login = model.Login,
                Name = model.Name,
                PasswordHash = model.Password,
                RegisterTime = DateTime.Now,
                Admin = false,
                AllowCreate = false
            });
            await _unitOfWork.SaveAsync();
            return RedirectToAction("Login","Auth");
        }
        #endregion
        #region Login
        [AuthLoader]
        public IActionResult Login() => View();
        [HttpPost]
        [AuthLoader]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            User? foundUser = await _unitOfWork.UserRepository.FirstOrDefaultAsync(x=>x.Login.Equals(model.Login.ToLower()));
            if (foundUser == null)
            {
                ModelState.AddModelError("Password", "Неверный пароль или почта!");
                return View(model);
            }
            foundUser.WriteToSession(HttpContext.Session);
            return RedirectToAction("Index", "Home");
        }
        #endregion
        #region Logout
        [AuthFilter]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }
        #endregion
        #region Migate
        public async Task<IActionResult> Migrate()
        {
            await _unitOfWork.MigrateAsync();
            return RedirectToAction("Login","Auth");
        }
        #endregion
        #region Profile
        [AuthFilter]
        public async Task<IActionResult> Profile(int id)
        {
            User? foundUser = await _unitOfWork.UserRepository.FirstOrDefaultAsync(x=>x.Id == id);
            if (foundUser == null || foundUser.Id == 0)
            {
                return NotFound();
            }
            ProfileModel model = new ProfileModel()
            {
                User = foundUser,
                Achievements = new List<Achievement>(),
                Self = (HttpContext.Session.GetInt32("id") ?? 0) == foundUser.Id
            };
            return View(model);
        }
        #endregion
        #region Change Password
        [AuthFilter]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        [AuthFilter]
        [ValidateAntiForgeryToken]
        public IActionResult ChangePassword(object model)
        {
            return View();
        }
        #endregion
    }
}
