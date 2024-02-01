using System.ComponentModel.DataAnnotations;

namespace ApnaDukaan_v1.BLL.DTOs
{
    public class ProductRequestDTO
    {
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [Range(1, double.MaxValue)]
        public double Price { get; set; }

        [StringLength(2000)]
        public string Description { get; set; } = null!;

        public int StockAvailable { get; set; }
        public int CategoryId { get; set; }
    }
}
