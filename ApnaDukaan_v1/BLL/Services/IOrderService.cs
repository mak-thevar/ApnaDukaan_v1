using ApnaDukaan_v1.BLL.DTOs;
using ApnaDukaan_v1.DAL.Entities;
using ApnaDukaan_v1.DAL.Entities.Enums;
using ApnaDukaan_v1.DAL.Repositories;
using AutoMapper;

namespace ApnaDukaan_v1.BLL.Services
{
    public interface IOrderService : IBaseService<OrderRequestDTO, OrderResponseDTO>
    {
        Task<OrderResponseDTO> Add(int userId, OrderRequestDTO requestDTO);
    }

    public class OrderService : IOrderService
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly IMapper mapper;

        public OrderService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }

        public Task<OrderResponseDTO> Add(OrderRequestDTO requestDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderResponseDTO> Add(int userId, OrderRequestDTO requestDTO)
        {

            //Fetch the price of each products from the database
            foreach (var orderDetail in requestDTO.OrderDetails)
            {
                var product = await this.repositoryWrapper.ProductRepository.GetById(orderDetail.ProductId);
                if (product is null)
                    throw new Exception($"Product with id {orderDetail.ProductId} not found.");

                var price = product.Price * orderDetail.Quantity;
                orderDetail.Price  = price;
            }


            var order = new Order
            {
                AddressId = requestDTO.AddressId,
                UserId = userId,
                CreatedAt = DateTime.Now,
                OrderDetails = requestDTO.OrderDetails.Select(x => new OrderDetail { ProductId = x.ProductId, Quantity = x.Quantity, Price = x.Price }).ToList(),
                OrderStatus = (int)OrderStatusEnum.PENDING,
                TotalAmount = requestDTO.OrderDetails.Sum(x => x.Price),
            };

            var result = await this.repositoryWrapper.OrderRepository.CreateAsync(order);
            await this.repositoryWrapper.SaveAsync();

            var orderFromDB = (await this.repositoryWrapper.OrderRepository.GetAllAsync("Address", "OrderDetails")).SingleOrDefault(x=>x.Id == result.Id);

            var orderResponse = mapper.Map<OrderResponseDTO>(orderFromDB);

            return orderResponse;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderResponseDTO>> GetAll()
        {
            var orders = await this.repositoryWrapper.OrderRepository.GetOrders();
            var orderResponse = mapper.Map<IEnumerable< OrderResponseDTO>>(orders);

            return orderResponse;
        }

        public Task<OrderResponseDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderResponseDTO> Update(OrderRequestDTO requestDTO)
        {
            throw new NotImplementedException();
        }
    }
}
