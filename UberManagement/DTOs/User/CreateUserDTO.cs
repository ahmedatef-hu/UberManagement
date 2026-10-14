using System.ComponentModel.DataAnnotations;
using UberManagement.Models;

namespace UberManagement.DTOs.User
{
    public class CreateUserDTO
    {
        [Required, Range(3, 100)]
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
