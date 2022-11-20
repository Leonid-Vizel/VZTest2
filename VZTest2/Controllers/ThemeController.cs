using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using VZTest2.Data.UnitOfWorks;
using VZTest2.Filters;
using VZTest2.Models.Data;
using VZTest2.Models.View;
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
                themes = await _unitOfWork.ThemeRepository.Where(x => x.OwnerId == userId).OrderBy(x => x.Id).Select(x=> new ThemeListModel(x)
                {
                    QuestionCount = _unitOfWork.QuestionRepository.GetSet().Count(x=>x.ThemeId == x.Id)
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
                themes = await _unitOfWork.ThemeRepository.Where(x => x.Public).OrderBy(x => x.Id).Select(x => new ThemeListModel(x)
                {
                    QuestionCount = _unitOfWork.QuestionRepository.GetSet().Count(x => x.ThemeId == x.Id)
                }).ToPagedListAsync(page, amount);
                ViewData["Mode"] = "default";
            }
            return View(themes);
        }
        [AuthFilter]
        public async Task<IActionResult> Details(int id)
        {
            Theme? foundTheme = await _unitOfWork.ThemeRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (foundTheme == null)
            {
                return NotFound();
            }
            bool self = false;
            int userId = HttpContext.Session.GetInt32("id") ?? 0;
            if (userId == foundTheme.OwnerId)
            {
                self = true;
            }
            if (!foundTheme.Public && !self)
            {
                self = await _unitOfWork.AccessLinkRepository.AnyAsync(x => x.EntityId == foundTheme.Id && x.Type == AccessLinkType.Theme && x.UserId == userId);
                if (!self)
                {
                    return Forbid();
                }
            }
            ThemeModel model = new ThemeModel(foundTheme)
            {
                Self = self,
                Questions = await (from question in _unitOfWork.QuestionRepository.GetSet().Where(x => x.ThemeId == id)
                                   select new QuestionModel(question)
                                   {
                                       Options = _unitOfWork.OptionRepository.Where(x => x.QuestionId == question.Id).ToList()
                                   }).ToListAsync()
            };
            return View(model);
        }
        [AuthFilter]
        public IActionResult Create()
        {
            return View();
        }
        [AuthFilter]
        public IActionResult Edit(int id)
        {
            return View();
        }
    }
}
