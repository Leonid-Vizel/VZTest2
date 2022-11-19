using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VZTest2.Data.UnitOfWorks;
using VZTest2.Filters;
using VZTest2.Models.Data;
using VZTest2.Models.View;
using VZTest2.Models.View.Theme;

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
        public async Task<IActionResult> List(bool unlock = false, bool mine = false)
        {
            if (unlock && mine)
            {
                return BadRequest();
            }
            List<Theme> themes = new List<Theme>();
            if (mine)
            {
                int userId = HttpContext.Session.GetInt32("id") ?? 0;
                themes = await _unitOfWork.ThemeRepository.Where(x => x.OwnerId == userId).OrderBy(x => x.Id).ToListAsync();
            }
            else if (unlock)
            {
                //AllLinked
                //themes = await _unitOfWork.ThemeRepository.Where(x => x.OwnerId == userId).OrderBy(x => x.Id).ToListAsync();
            }
            else
            {
                themes = await _unitOfWork.ThemeRepository.Where(x => x.Public).OrderBy(x => x.Id).ToListAsync();
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
            ThemeModel models = new ThemeModel(foundTheme)
            {
                Self = self,
                Questions = await (from question in _unitOfWork.QuestionRepository.GetSet().Where(x => x.ThemeId == id)
                                   select new QuestionModel(question)
                                   {
                                       Options = _unitOfWork.OptionRepository.Where(x => x.QuestionId == question.Id).ToList()
                                   }).ToListAsync()
            };
            return View();
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
