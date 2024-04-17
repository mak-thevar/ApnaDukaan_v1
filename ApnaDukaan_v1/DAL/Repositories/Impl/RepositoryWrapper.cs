using ApnaDukaan_v1.DAL.DBContext;
using ApnaDukaan_v1.DAL.Repositories.Interface;

namespace ApnaDukaan_v1.DAL.Repositories.Impl
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly ApnaDukaanContext dbContext;

        public IRoleRepository RoleRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        public IUserRepository UserRepository { get; set; }

        public RepositoryWrapper(ApnaDukaanContext dbContext)
        {
            this.dbContext = dbContext;

            RoleRepository = new RoleRepository(dbContext);
            CategoryRepository = new CategoryRepository(dbContext);
            ProductRepository = new ProductRepository(dbContext);
            OrderRepository = new OrderRepository(dbContext);
            UserRepository = new UserRepository(dbContext);
        }

        public async Task<int> SaveAsync()
        {

            dbContext.Categories.Where(x => true).AsEnumerable();

            return await dbContext.SaveChangesAsync();
        }
    }
}
