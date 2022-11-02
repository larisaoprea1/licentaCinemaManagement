using System.ComponentModel.DataAnnotations;

namespace CinemaManagement.ViewModels.UserViewModels
{
    public class ChangePasswordViewModel
    {
        [DataType(DataType.Password), Required(ErrorMessage = "Old Password Required")]
        public string oldPassword { get; set; }

        [DataType(DataType.Password), Required(ErrorMessage = "New Password Required")]
        public string newPassword { get; set; }
    }
}
