using System.ComponentModel.DataAnnotations;

namespace EducationalCenter.Common.Dtos.User
{
    public class UserForAuthenticationDto
    {
        [Required(ErrorMessage = "EMail is required.")]
        public string EMail { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
