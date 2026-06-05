using System.ComponentModel.DataAnnotations;

namespace FirstMVCWebApp.Models
{
    public class Product
    {
        [Key]
        public string Id { get; set; }
        public string ProductName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; } = 0.00m;
        public string Colour { get; set; } = null!;
    }
}
