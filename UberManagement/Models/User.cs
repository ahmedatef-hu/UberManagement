using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace UberManagement.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required,Range(3, 100)]
        public string FullName { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required, Phone]
        public string Phone { get; set; }
        [Required]
        public string Role { get; set; } = "Rider";
        public Vehicle? Vehicle { get; set; }

        public List<Ride> RideDrivers { get; set; } = new List<Ride>();
        public List<Ride> RideRiders { get; set; } = new List<Ride>();

    }
}
