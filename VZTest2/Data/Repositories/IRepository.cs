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
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        IQueryable<TResult> Select<TResult>(Expression<Func<T, int, TResult>> selector);
        IOrderedQueryable<T> OrderBy<TKey>(Expression<Func<T, TKey>> keySelector);
        IOrderedQueryable<T> OrderByDescending<TKey>(Expression<Func<T, TKey>> keySelector);
        IQueryable<T> GetSet();
        void Update(T value);
        void UpdateRange(IEnumerable<T> value);
    }
}
