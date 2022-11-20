using VZTest2.Data.Repositories;
using VZTest2.Models.Data;

namespace VZTest2.Data.UnitOfWorks
{
    public class ThemeUnitOfWork : DefaultUnitOfWork, IThemeUnitOfWork
    {
        public IRepository<User> UserRepository { get; set; }
        public IRepository<Theme> ThemeRepository { get; set; }
        public IRepository<Question> QuestionRepository { get; set; }
        public IRepository<Option> OptionRepository { get; set; }
        public IRepository<StarLink> StarLinkRepository { get; set; }
        public IRepository<AccessLink> AccessLinkRepository { get; set; }

        public ThemeUnitOfWork(ApplicationDbContext db) : base(db)
        {
            UserRepository = new Repository<User>(Context);
            ThemeRepository = new Repository<Theme>(Context);
            QuestionRepository = new Repository<Question>(Context);
            OptionRepository = new Repository<Option>(Context);
            StarLinkRepository = new Repository<StarLink>(Context);
            AccessLinkRepository = new Repository<AccessLink>(Context);
        }
    }
}
