namespace VZTest2.Data.UnitOfWorks
{
    public class DefaultUnitOfWork : IDefaultUnitOfWork
    {
        public ApplicationDbContext Context { get; set; }
        public DefaultUnitOfWork(ApplicationDbContext context)
        {
            Context = context;
        }
        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
