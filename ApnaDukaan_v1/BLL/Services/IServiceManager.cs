namespace ApnaDukaan_v1.BLL.Services
{
    public interface IServiceManager
    {
        public IProductService ProductService { get;  }
        public IOrderService OrderService { get;  }
        public IAuthService AuthService { get;  }
        
    }
}
