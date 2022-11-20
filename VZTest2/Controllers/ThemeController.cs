using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using VZTest2.Data.UnitOfWorks;
using VZTest2.Filters;
using VZTest2.Instruments;
using VZTest2.Models.Data;
using VZTest2.Models.View.Theme;
using X.PagedList;

namespace VZTest2.Controllers
{
    public class ThemeController : Controller
    {
        private readonly IThemeUnitOfWork _unitOfWork;
        public ThemeController(IThemeUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [AuthFilter]
        public async Task<IActionResult> List(int page = 1, int amount = 20, bool unlock = false, bool mine = false)
        {
            if (page <= 0)
            {
                page = 1;
            }
            if (unlock && mine)
            {
                unlock = mine = true;
            }
            IPagedList<ThemeListModel> themes;
            int userId = HttpContext.Session.GetInt32("id") ?? 0;
            if (mine)
            {
                themes = await _unitOfWork.ThemeRepository.GetSet().Where(x => x.OwnerId == userId).OrderBy(x => x.Id).Select(x => new ThemeListModel(x)
                {
                    QuestionCount = _unitOfWork.QuestionRepository.GetSet().Count(x => x.ThemeId == x.Id)
                }).ToPagedListAsync(page, amount);
                ViewData["Mode"] = "mine";
            }
            else if (unlock)
            {
                themes = await (from link in _unitOfWork.AccessLinkRepository.GetSet().Where(x => x.Type == AccessLinkType.Theme && x.UserId == userId)
                                join theme in _unitOfWork.ThemeRepository.GetSet() on link.EntityId equals theme.Id
                                select new ThemeListModel(theme)
                                {
                                    QuestionCount = _unitOfWork.QuestionRepository.GetSet().Count(x => x.ThemeId == x.Id)
                                }).ToPagedListAsync(page, amount);
                ViewData["Mode"] = "unlock";
            }
            else
            {
                themes = await _unitOfWork.ThemeRepository.GetSet().Where(x => x.Public).OrderBy(x => x.Id).Select(x => new ThemeListModel(x)
                {
                    QuestionCount = _unitOfWork.QuestionRepository.GetSet().Count(x => x.ThemeId == x.Id)
                }).ToPagedListAsync(page, amount);
                ViewData["Mode"] = "default";
            }
            return View(themes);
        }
        [AuthFilter]
        public async Task<IActionResult> Details(int id, int page = 1, int amount = 20)
        {
            Theme? foundTheme = await _unitOfWork.ThemeRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (foundTheme == null)
            {
                return NotFound();
            }
            int userId = HttpContext.Session.GetInt32("id") ?? 0;
            bool self = userId == foundTheme.OwnerId || (bool)(ViewData["admin"] ?? false || await _unitOfWork.AccessLinkRepository.AnyAsync(x => x.EntityId == foundTheme.Id && x.Type == AccessLinkType.Theme && x.UserId == userId));
            if (!self && !foundTheme.Public)
            {
                return StatusCode(403);
            }
            ThemeModel model = new ThemeModel(foundTheme)
            {
                Self = self,
                OwnerName = _unitOfWork.UserRepository.GetSet().Where(x=>x.Id == foundTheme.OwnerId).Select(x=>x.Name).FirstOrDefault() ?? "Пользователь не найден",
                Questions = await _unitOfWork.QuestionRepository.GetSet().Where(x => x.ThemeId == id).ToPagedListAsync(page, amount)
            };
            return View(model);
        }
        [AuthFilter]
        public IActionResult Create()
        {
            if (!(HttpContext.Session.GetBoolean("admin") ?? false) || (HttpContext.Session.GetBoolean("create") ?? false))
            {
                return StatusCode(403);
            }
            return View();
        }
        [AuthFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateThemeModel model)
        {
            if (!(HttpContext.Session.GetBoolean("admin") ?? false) || (HttpContext.Session.GetBoolean("create") ?? false))
            {
                return StatusCode(403);
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Theme theme = new Theme(model)
            {
                OwnerId = HttpContext.Session.GetInt32("id") ?? 0
            };
            await _unitOfWork.ThemeRepository.AddAsync(theme);
            await _unitOfWork.SaveAsync();
            return RedirectToAction("Details", "Theme", new { Id = theme.Id });
        }
        [AuthFilter]
        public async Task<IActionResult> Edit(int id)
        {
            bool admin = HttpContext.Session.GetBoolean("admin") ?? false;
            bool create = HttpContext.Session.GetBoolean("create") ?? false;
            if (!(admin || create))
            {
                return StatusCode(403);
            }
            Theme? foundTheme = await _unitOfWork.ThemeRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (foundTheme == null)
            {
                return NotFound();
            }
            int userId = HttpContext.Session.GetInt32("id") ?? 0;
            if (!admin && foundTheme.OwnerId != userId)
            {
                return StatusCode(403);
            }
            return View(new EditThemeModel(foundTheme));
        }
        [AuthFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditThemeModel model)
        {
            bool admin = HttpContext.Session.GetBoolean("admin") ?? false;
            bool create = HttpContext.Session.GetBoolean("create") ?? false;
            if (!(admin || create))
            {
                return StatusCode(403);
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Theme? foundTheme = await _unitOfWork.ThemeRepository.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (foundTheme == null)
            {
                return NotFound();
            }
            int userId = HttpContext.Session.GetInt32("id") ?? 0;
            if (!admin && foundTheme.OwnerId != userId)
            {
                return StatusCode(403);
            }
            foundTheme.Name = model.Name;
            foundTheme.Description = model.Description;
            foundTheme.Public = model.Public;
            foundTheme.EditTime = DateTime.Now;
            _unitOfWork.ThemeRepository.Update(foundTheme);
            await _unitOfWork.SaveAsync();
            return RedirectToAction("Details", "Theme", new { Id = foundTheme.Id });
        }
        [AuthFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            bool admin = HttpContext.Session.GetBoolean("admin") ?? false;
            bool create = HttpContext.Session.GetBoolean("create") ?? false;
            if (!(admin || create))
            {
                return StatusCode(403);
            }
            Theme? foundTheme = await _unitOfWork.ThemeRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (foundTheme == null)
            {
                return NotFound();
            }
            int userId = HttpContext.Session.GetInt32("id") ?? 0;
            if (!admin && foundTheme.OwnerId != userId)
            {
                return StatusCode(403);
            }
            _unitOfWork.ThemeRepository.Remove(foundTheme);
            await _unitOfWork.SaveAsync();
            return RedirectToAction("List", "Theme");
        }
    }
}
