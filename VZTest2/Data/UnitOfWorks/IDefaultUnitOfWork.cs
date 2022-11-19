namespace VZTest2.Data.UnitOfWorks
{
    public interface IDefaultUnitOfWork
    {
        ApplicationDbContext Context { get; set; }
        Task SaveAsync();
    }
}
