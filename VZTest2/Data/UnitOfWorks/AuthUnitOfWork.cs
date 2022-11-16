using Microsoft.EntityFrameworkCore;
using VZTest2.Data.Repositories;
using VZTest2.Models.Data;

namespace VZTest2.Data.UnitOfWorks
{
    public class AuthUnitOfWork : IAuthUnitOfWork
    {
        public ApplicationDbContext Context { get; set; }
        public IRepository<User> UserRepository { get; set; }

        public AuthUnitOfWork(ApplicationDbContext db)
        {
            Context = db;
            UserRepository = new Repository<User>(db);
        }
        public async Task MigrateAsync()
        {
            if ((await Context.Database.GetPendingMigrationsAsync()).Count() > 0)
            {
                await Context.Database.MigrateAsync();
            }
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
