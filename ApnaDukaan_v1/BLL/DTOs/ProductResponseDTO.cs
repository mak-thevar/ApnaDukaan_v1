using System.Text.Json.Serialization;

namespace ApnaDukaan_v1.BLL.DTOs
{
    public class ProductResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public string Description { get; set; } = null!;
        public int StockAvailable { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
