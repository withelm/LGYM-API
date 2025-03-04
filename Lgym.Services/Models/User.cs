using System.ComponentModel.DataAnnotations;

namespace Lgym.Services.Models
{
    public class User : BaseModel
    {

        [Required]
        [MinLength(5)]
        public string Login { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
