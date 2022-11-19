namespace VZTest2.Data.UnitOfWorks
{
    public class DefaultUnitOfWork : IDefaultUnitOfWork
    {
        public ApplicationDbContext Context { get; set; }
        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
