using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UberManagement.Data;
using UberManagement.DTOs.Ride;
using UberManagement.Models;
using UberManagement.Repos.Interfaces;

namespace UberManagement.Repos.Implementation
{
    public class RidesRepo : GenericRepo<Ride>, IRidesRepo
    {
        public RidesRepo(AppDbContext context) : base(context)
        {
        }

        private async Task SortBY(string SortType)
        {
            switch(SortType)
            {
                case "Fare":
                    await context.Rides.OrderBy(c => c.Fare).ToListAsync();
                    break;

            }
        }
        public Task<Ride> Accept(int id)
        {
            var s = GetById(id);
            return s;
        }

        public async Task<List<Ride>> Filter(string Status, decimal MinFare, decimal MaxFare)
        {
            return await context.Rides.Where(c => c.Status == Status && c.Fare < MinFare && c.Fare > MaxFare).OrderBy(d => d.Fare).ToListAsync();

        }

        public Task<List<Ride>> GetPagenation(int PageNumber, int PageSize)
        {
            var pag = context.Rides
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
            return pag;
        }

        public Task<List<ReportDTO>> Report()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Ride>> Search(string Pickup)
        {
            return await context.Rides.Where(e => e.PickupLocation.Contains(Pickup)).ToListAsync();
        }
    }
}
