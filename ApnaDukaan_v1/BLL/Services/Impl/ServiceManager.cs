using ApnaDukaan_v1.DAL.Repositories.Interface;
using AutoMapper;

namespace ApnaDukaan_v1.BLL.Services.Impl
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IOrderService> _orderService;
        private readonly Lazy<IAuthService> _authService;

        public ServiceManager(IRepositoryWrapper repositoryWrapper, IMapper mapper, IConfiguration configuration)
        {
            _productService = new Lazy<IProductService>(() => new ProductService(repositoryWrapper, mapper));
            _orderService = new Lazy<IOrderService>(() => new OrderService(repositoryWrapper, mapper));
            _authService = new Lazy<IAuthService>(() => new AuthService(repositoryWrapper, configuration));
        }

        public IProductService ProductService => _productService.Value;

        public IOrderService OrderService => _orderService.Value;
        public IAuthService AuthService => _authService.Value;


    }
}
