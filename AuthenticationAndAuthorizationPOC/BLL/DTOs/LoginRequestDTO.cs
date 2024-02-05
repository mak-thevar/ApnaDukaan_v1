using System.ComponentModel.DataAnnotations;

namespace AuthenticationAndAuthorizationPOC.BLL.DTOs
{
    public class LoginRequestDTO
    {
        [StringLength(50)]
        [Required]
        public string Username { get; set; }

        [StringLength(100)]
        [Required]
        public string Password { get; set; }
    }
}
