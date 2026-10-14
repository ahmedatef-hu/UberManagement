using UberManagement.Models;

namespace UberManagement.Repos.Interfaces
{
    public interface IUserRepo : IGenericRepo<User>
    {
        Task<List<User>> GetByRole(string Role);
        Task<List<User>> Search(string RiderName);
    }
}
