using ApnaDukaan_v1.DAL.DBContext;
using ApnaDukaan_v1.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApnaDukaan_v1.DAL.Repositories
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

    public abstract class RepositoryBase<T> : IBaseRepository<T> where T : class
    {
        private readonly ApnaDukaanContext dbContext;

        private readonly DbSet<T> dbSet;

        public RepositoryBase(ApnaDukaanContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            var result = await this.dbSet.AddAsync(entity);
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(T entity)
        {

            var result = this.dbSet.Remove(entity);

            return await Task.FromResult(result.Entity is not null);
        }

        public async Task<IEnumerable<T>> GetAllAsync(params string[] navsToInclude)
        {
            IQueryable<T> query = this.dbSet;
            if(navsToInclude.Length> 0)
            {
                foreach (var item in navsToInclude)
                {
                   query =  query.Include(item);
                }
            }
            var result = query.AsEnumerable();
            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> condition)
        {
            var result = this.dbSet.Where(condition);
            return await Task.FromResult(result.AsEnumerable());
        }

        public async Task<T?> GetById(int id)
        {
            return await this.dbSet.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var result = this.dbSet.Update(entity);
            return await Task.FromResult(result.Entity);
        }
    }

    public interface ICategoryRepository : IBaseRepository<Category> { }


    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(ApnaDukaanContext dbContext) : base(dbContext)
        {
        }
    }


    public interface IRoleRepository : IBaseRepository<Role> { }


    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(ApnaDukaanContext dbContext) : base(dbContext)
        {
        }
    }



    public interface IProductRepository : IBaseRepository<Product>
    {
    }


    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrders();
    }


    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        private readonly ApnaDukaanContext dbContext;

        public OrderRepository(ApnaDukaanContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<IEnumerable<Order>> GetOrders()
        {
            var result = this.dbContext.Orders.Include(x => x.Address).Include(x => x.OrderDetails).ThenInclude(x => x.Product).AsEnumerable();
            return Task.FromResult(result);
        }
    }


    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ApnaDukaanContext dbContext) : base(dbContext) { }
    }

    public interface IRepositoryWrapper
    {
        public IRoleRepository RoleRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }

        Task<int> SaveAsync();
    }

    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly ApnaDukaanContext dbContext;

        public IRoleRepository RoleRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }

        public RepositoryWrapper(ApnaDukaanContext dbContext)
        {
            this.dbContext = dbContext;

            RoleRepository = new RoleRepository(dbContext);
            CategoryRepository = new CategoryRepository(dbContext);
            ProductRepository = new ProductRepository(dbContext);
            OrderRepository = new OrderRepository(dbContext);
        }

        public async Task<int> SaveAsync()
        {

            dbContext.Categories.Where(x => true).AsEnumerable();

            return await this.dbContext.SaveChangesAsync();
        }
    }
}
