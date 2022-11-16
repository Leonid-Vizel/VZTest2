using System.Linq.Expressions;

namespace VZTest2.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T value);
        Task AddRangeAsync(IEnumerable<T> values);
        void Remove(T value);
        void RemoveRange(IEnumerable<T> value);
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> filter);
        IQueryable<T> GetSet();
        void Update(T value);
        void UpdateRange(IEnumerable<T> value);
    }
}
