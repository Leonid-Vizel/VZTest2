using VZTest2.Data.Repositories;
using VZTest2.Models.Data;

namespace VZTest2.Data.UnitOfWorks
{
    public interface IAuthUnitOfWork
    {
        ApplicationDbContext Context { get; set; }
        IRepository<User> UserRepository { get; set; }
        Task SaveAsync();
    }
}
