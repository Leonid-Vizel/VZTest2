using VZTest2.Data.Repositories;
using VZTest2.Models.Data;

namespace VZTest2.Data.UnitOfWorks
{
    public interface IAuthUnitOfWork : IDefaultUnitOfWork
    {
        IRepository<User> UserRepository { get; set; }
        Task MigrateAsync();
    }
}
