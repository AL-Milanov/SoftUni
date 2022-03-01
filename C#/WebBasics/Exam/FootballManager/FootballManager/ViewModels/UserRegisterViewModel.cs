using FootballManager.Common;
using System.ComponentModel.DataAnnotations;

namespace FootballManager.Models
{
    public class UserRegisterViewModel
    {
        [Required]
        [StringLength(Constraints.USER_USERNAME_MAX_LENGTH,
            MinimumLength = Constraints.USER_USERNAME_MIN_LENGTH,
            ErrorMessage = "{0} must contains characters in range {2} - {1}!")]
        public string Username { get; set; }

        [Required]
        [StringLength(Constraints.USER_EMAIL_MAX_LENGTH,
            MinimumLength = Constraints.USER_EMAIL_MIN_LENGTH,
            ErrorMessage = "{0} is to long, must not exceed {1} characters!")]

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(Constraints.USER_PASSWORD_MAX_LENGTH,
            MinimumLength = Constraints.USER_PASSWORD_MIN_LENGTH,
            ErrorMessage = "{0} must be in between {2} and {1} characters!")]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password),
            ErrorMessage = "{0} and {1} must match!")]
        public string ConfirmPassword { get; set; }
    }
}
