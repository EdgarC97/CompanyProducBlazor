using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompanyProductBlazor.Models

{
    public class Company
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria")]
        [StringLength(200, ErrorMessage = "La dirección no puede exceder los 200 caracteres")]
        public string Address { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
