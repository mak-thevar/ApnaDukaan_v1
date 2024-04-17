using ApnaDukaan_v1.DAL.DBContext;
using ApnaDukaan_v1.DAL.Entities;
using ApnaDukaan_v1.DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace ApnaDukaan_v1.DAL.Repositories.Impl
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        private readonly ApnaDukaanContext dbContext;

        public OrderRepository(ApnaDukaanContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<IEnumerable<Order>> GetOrders()
        {
            var result = dbContext.Orders.Include(x => x.Address).Include(x => x.OrderDetails).ThenInclude(x => x.Product).AsEnumerable();
            return Task.FromResult(result);
        }
    }
}
