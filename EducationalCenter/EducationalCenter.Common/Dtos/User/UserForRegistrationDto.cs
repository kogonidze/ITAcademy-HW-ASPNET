using System.ComponentModel.DataAnnotations;

namespace EducationalCenter.Common.Dtos.User
{
    public class UserRegistrationDto
    {
        [Required(ErrorMessage = "EMail is required.")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The password and confirmation password does not match")]
        public string ConfirmPassword { get; set; }
    }
}
