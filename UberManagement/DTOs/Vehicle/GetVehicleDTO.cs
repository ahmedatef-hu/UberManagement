using System.ComponentModel.DataAnnotations;

namespace UberManagement.DTOs.Vehicle
{
    public class GetVehicleDTO
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public string Color { get; set; }
        public int DriverId { get; set; }
    }
}
