using System.ComponentModel.DataAnnotations;
using UberManagement.Models;

namespace UberManagement.DTOs.User
{
    public class GetUserDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
    }
}
