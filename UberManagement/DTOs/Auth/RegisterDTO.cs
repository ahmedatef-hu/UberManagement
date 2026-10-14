using System.ComponentModel.DataAnnotations;

namespace UberManagement.DTOs.Auth
{
    public class RegisterDTO
    {
        public string FullName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required, Phone]
        public string Phone { get; set; }
        [Required]
        public string Role { get; set; } = "Rider";
    }
}
