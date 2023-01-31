using System.ComponentModel.DataAnnotations;

namespace Playin.ViewModels
{
    public class Login
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
