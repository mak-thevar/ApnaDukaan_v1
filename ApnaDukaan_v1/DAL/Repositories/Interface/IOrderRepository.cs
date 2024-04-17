using ApnaDukaan_v1.DAL.Entities;

namespace ApnaDukaan_v1.DAL.Repositories.Interface
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrders();
    }
}
