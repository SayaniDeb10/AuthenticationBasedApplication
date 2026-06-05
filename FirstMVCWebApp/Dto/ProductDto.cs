using System.ComponentModel.DataAnnotations;

namespace FirstMVCWebApp.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product Name Is Required")]
        public string ProductName { get; set; } = null!;

        [Required(ErrorMessage = "Product Description Is Required")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Product Price Is Required")]
        public decimal Price { get; set; } = 0.00m;

        [Required(ErrorMessage = "Product Colour Is Required")]
        public string Colour { get; set; } = null!;
    }
}
