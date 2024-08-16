using System.ComponentModel.DataAnnotations;

namespace IFATC_PROYECT.Models
{
    public class LoginViewModel
    {
        [Required]
        // Removed the [EmailAddress] attribute to allow any format for the "email" field.
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
