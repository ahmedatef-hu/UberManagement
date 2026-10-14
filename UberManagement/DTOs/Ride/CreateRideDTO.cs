using System.ComponentModel.DataAnnotations;
using UberManagement.Models;

namespace UberManagement.DTOs.Ride
{
    public class CreateRideDTO
    {
        [Required, MaxLength(150)]
        public string PickupLocation { get; set; }
        [Required, MaxLength(150)]
        public string DropOffLocation { get; set; }
        [Range(20, 5000)]
        public decimal Fare { get; set; }
        [Required]
        public string Status { get; set; }
        public int RiderId { get; set; }
        public int? DriverId { get; set; }
    }
}
