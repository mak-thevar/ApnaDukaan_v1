using ApnaDukaan_v1.DAL.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace ApnaDukaan_v1.BLL.DTOs
{
    public class OrderResponseDTO
    {
        public double TotalAmount { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressPincode { get; set; }

        public string AddressStreetAddress { get; set; } = null!;
        public string AddressLandmark { get; set; } = null!;

        [EnumDataType(typeof(OrderStatusEnum))]
        public string OrderStatus { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<OrderDetailResponseDTO> OrderDetails { get; set; }
    }

    public class OrderDetailResponseDTO
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
