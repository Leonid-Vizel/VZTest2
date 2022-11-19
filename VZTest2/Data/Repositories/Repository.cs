using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VZTest2.Data.Repositories;

namespace VZTest2.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> Set { get; set; }
        protected ApplicationDbContext DataBase { get; set; }

        public Repository(ApplicationDbContext db)
        {
            DataBase = db;
            Set = DataBase.Set<T>();
        }

        public async Task AddAsync(T value)
            => await Set.AddAsync(value);
        public async Task AddRangeAsync(IEnumerable<T> values)
            => await Set.AddRangeAsync(values);
        public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> filter)
            => await Set.FirstOrDefaultAsync(filter);
        public IQueryable<T> GetSet()
            => Set;
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
            => await Set.AnyAsync(predicate);
        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
            => Set.Where(predicate);
        public IQueryable<TResult> Select<TResult>(Expression<Func<T, int, TResult>> selector)
            => Set.Select(selector);
        public IOrderedQueryable<T> OrderBy<TKey>(Expression<Func<T, TKey>> keySelector)
        => Set.OrderBy(keySelector);
        public IOrderedQueryable<T> OrderByDescending<TKey>(Expression<Func<T, TKey>> keySelector)
        => Set.OrderByDescending(keySelector);
        public void Remove(T value)
            => Set.Remove(value);
        public void Update(T value)
            => Set.Update(value);
        public void RemoveRange(IEnumerable<T> value)
            => Set.RemoveRange(value);
        public void UpdateRange(IEnumerable<T> value)
            => Set.UpdateRange(value);
    }
}
