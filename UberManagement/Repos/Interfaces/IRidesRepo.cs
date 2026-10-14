using UberManagement.DTOs.Ride;
using UberManagement.Models;

namespace UberManagement.Repos.Interfaces
{
    public interface IRidesRepo : IGenericRepo<Ride>
    {
        Task<List<Ride>> GetPagenation(int PageNumber, int PageSize);
        Task<Ride> Accept(int id);
        Task<List<Ride>> Search(string Pickup);
        Task<List<Ride>> Filter(string Status, decimal MinFare, decimal MaxFare);
        Task<List<ReportDTO>> Report(); 
    }
}
