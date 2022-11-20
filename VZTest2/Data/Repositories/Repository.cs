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
        public int Count(Expression<Func<T, bool>> predicate)
            => Set.Count(predicate);
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
