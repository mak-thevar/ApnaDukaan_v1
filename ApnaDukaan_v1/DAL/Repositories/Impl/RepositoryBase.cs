using ApnaDukaan_v1.DAL.DBContext;
using ApnaDukaan_v1.DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApnaDukaan_v1.DAL.Repositories.Impl
{
    public abstract class RepositoryBase<T> : IBaseRepository<T> where T : class
    {
        private readonly ApnaDukaanContext dbContext;

        private readonly DbSet<T> dbSet;

        public RepositoryBase(ApnaDukaanContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = this.dbContext.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            var result = await dbSet.AddAsync(entity);
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(T entity)
        {

            var result = dbSet.Remove(entity);

            return await Task.FromResult(result.Entity is not null);
        }

        public async Task<IEnumerable<T>> GetAllAsync(params string[] navsToInclude)
        {
            IQueryable<T> query = dbSet;
            if (navsToInclude.Length > 0)
            {
                foreach (var item in navsToInclude)
                {
                    query = query.Include(item);
                }
            }
            var result = query.AsEnumerable();
            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> condition)
        {
            var result = dbSet.Where(condition);
            return await Task.FromResult(result.AsEnumerable());
        }

        public async Task<T?> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var result = dbSet.Update(entity);
            return await Task.FromResult(result.Entity);
        }
    }
}
