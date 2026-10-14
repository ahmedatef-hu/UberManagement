using UberManagement.DTOs.Auth;
using UberManagement.Models;

namespace UberManagement.JWT
{
    public interface IAuthRepo
    {
        Task<string> Login(LoginDTO dto);
        Task<bool> Register(User user); 
    }
}
