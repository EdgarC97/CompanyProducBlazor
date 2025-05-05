using System.ComponentModel.DataAnnotations;

namespace CompanyProductBlazor.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "El stock es obligatorio")]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        [Required(ErrorMessage = "La compañía es obligatoria")]
        public int CompanyId { get; set; }

        public Company? Company { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
