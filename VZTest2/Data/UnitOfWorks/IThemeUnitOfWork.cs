using VZTest2.Data.Repositories;
using VZTest2.Models.Data;

namespace VZTest2.Data.UnitOfWorks
{
    public interface IThemeUnitOfWork : IDefaultUnitOfWork
    {
        IRepository<Theme> ThemeRepository { get; set; }
        IRepository<Question> QuestionRepository { get; set; }
        IRepository<Option> OptionRepository { get; set; }
        IRepository<StarLink> StarLinkRepository { get; set; }
        IRepository<AccessLink> AccessLinkRepository { get; set; }
    }
}
