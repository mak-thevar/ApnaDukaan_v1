using System.Linq.Expressions;

namespace ApnaDukaan_v1.DAL.Repositories.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<bool> DeleteAsync(T entity);

        Task<IEnumerable<T>> GetAllAsync(params string[] navsToInclude);

        Task<T?> GetById(int id);

        Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> condition);
    }
}
