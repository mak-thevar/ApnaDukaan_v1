using ApnaDukaan_v1.DAL.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace ApnaDukaan_v1.BLL.DTOs
{
    public class OrderRequestDTO
    {
        public List<OrderDetailsDTO>  OrderDetails { get; set; }
        public int AddressId { get; set; }
        public int UserId { get; set; }
    }

    public class OrderDetailsDTO
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Range(1, int.MaxValue)]
        public double Price { get; set; }
    }
}
