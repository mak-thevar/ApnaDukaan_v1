using ApnaDukaan_v1.DAL.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace ApnaDukaan_v1.BLL.DTOs
{
    public class OrderRequestDTO
    {
        public List<OrderDetailsDTO>  OrderDetails { get; set; }
        public int AddressId { get; set; }
    }

    public class OrderDetailsDTO
    {
      
        public int ProductId { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        public double Price { get; set; }

    }
}
