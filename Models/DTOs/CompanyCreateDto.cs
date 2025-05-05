using System.ComponentModel.DataAnnotations;

namespace CompanyProductBlazor.Models.DTOs
{
    public class CompanyCreateDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria")]
        [StringLength(200)]
        public string Address { get; set; }

        [RegularExpression(@"^\d{0,10}$", ErrorMessage = "El teléfono debe contener solo números (0 a 10 dígitos)")]
        public string? Phone { get; set; }

        [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
        public string? Email { get; set; }

        public string? WebSite { get; set; }
    }
}
