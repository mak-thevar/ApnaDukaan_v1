namespace ApnaDukaan_v1.DAL.Repositories.Interface
{
    public interface IRepositoryWrapper
    {
        public IRoleRepository RoleRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        public IUserRepository UserRepository { get; set; }

        Task<int> SaveAsync();
    }
}
