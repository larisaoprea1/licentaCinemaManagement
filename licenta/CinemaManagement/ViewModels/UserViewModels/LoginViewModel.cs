using System.ComponentModel.DataAnnotations;

namespace CinemaManagement.ViewModels.UserViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(20)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
