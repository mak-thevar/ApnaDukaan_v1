using ApnaDukaan_v1.DAL.DBContext;
using ApnaDukaan_v1.DAL.Entities;
using ApnaDukaan_v1.DAL.Repositories.Interface;

namespace ApnaDukaan_v1.DAL.Repositories.Impl
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApnaDukaanContext dbContext) : base(dbContext)
        {
        }
    }
}
