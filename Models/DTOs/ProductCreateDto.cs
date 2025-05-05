// Models/DTOs/ProductCreateDto.cs
using System.ComponentModel.DataAnnotations;

namespace CompanyProductBlazor.Models.DTOs
{
    public class ProductCreateDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        [Required]
        public int CompanyId { get; set; }
    }
}
