using ApnaDukaan_v1.BLL.DTOs;

namespace ApnaDukaan_v1.BLL.Services
{
    public interface IOrderService : IBaseService<OrderRequestDTO, OrderResponseDTO>
    {
        Task<OrderResponseDTO> Add(int userId, OrderRequestDTO requestDTO);
    }
}
