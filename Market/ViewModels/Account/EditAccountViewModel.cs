using System.ComponentModel.DataAnnotations;

namespace Market.ViewModels
{
    public class EditAccountViewModel
    {
        [Required]
        [Display(Name ="Username")]
        public string UserName { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        public string Phone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name ="Current password")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Display(Name ="New paswword")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
       
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmNewPassword { get; set; }
    }
}
