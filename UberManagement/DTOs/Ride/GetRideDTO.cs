using System.ComponentModel.DataAnnotations;
using UberManagement.Models;

namespace UberManagement.DTOs.Ride
{
    public class GetRideDTO
    {
        public int Id { get; set; }
        public string PickupLocation { get; set; }
        public string DropOffLocation { get; set; }
        public decimal Fare { get; set; }
        public string Status { get; set; }
        public int RiderId { get; set; }
        public int? DriverId { get; set; }
    }
}
