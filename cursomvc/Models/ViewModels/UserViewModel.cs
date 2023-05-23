using System.ComponentModel.DataAnnotations;

namespace cursomvc.Models.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracteres ", MinimumLength = 1)]
        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Confirmar Contraseña ")]
        [Compare("Password", ErrorMessage = "Las contraseñas no son iguales ")]
        public string ConfirmPassword { get; set; }

        [Required]
        public int Edad { get; set; }
    }

    public class EditUserViewModel
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracteres ", MinimumLength = 1)]
        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Confirmar Contraseña ")]
        [Compare("Password", ErrorMessage = "Las contraseñas no son iguales ")]
        public string ConfirmPassword { get; set; }

        [Required]
        public int Edad { get; set; }
    }
}