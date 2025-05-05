using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompanyProductBlazor.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria")]
        [StringLength(200)]
        public string Address { get; set; }

        public string? Phone { get; set; }

        [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
        public string? Email { get; set; }
        public string? WebSite { get; set; }
        public DateTime? CreatedAt { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
