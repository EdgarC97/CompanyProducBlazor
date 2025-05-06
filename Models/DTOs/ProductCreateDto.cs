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
        [Range(0, 999999999)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 999999999)]
        public int Stock { get; set; }

        [Required]
        public int CompanyId { get; set; }
    }
}
