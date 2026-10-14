using Microsoft.EntityFrameworkCore;
using UberManagement.Data;
using UberManagement.Models;
using UberManagement.Repos.Interfaces;

namespace UberManagement.Repos.Implementation
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        public UserRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<List<User>> GetByRole(string Role)
        {
            return await context.Users.Where(e => e.Role.Contains(Role)).ToListAsync();
        }

        public async Task<List<User>> Search(string RiderName)
        {
            return await context.Users.Where(e => e.FullName.Contains(RiderName)).ToListAsync();
        }
    }
}
