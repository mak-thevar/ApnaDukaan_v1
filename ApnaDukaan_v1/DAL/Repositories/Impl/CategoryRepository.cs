using ApnaDukaan_v1.DAL.DBContext;
using ApnaDukaan_v1.DAL.Entities;
using ApnaDukaan_v1.DAL.Repositories.Interface;

namespace ApnaDukaan_v1.DAL.Repositories.Impl
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(ApnaDukaanContext dbContext) : base(dbContext)
        {
        }
    }
}
