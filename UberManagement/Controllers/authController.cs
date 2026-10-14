using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UberManagement.Data;
using UberManagement.DTOs.Auth;
using UberManagement.JWT;
using UberManagement.Models;

namespace UberManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class authController : ControllerBase
    {
        private readonly IAuthRepo repo;
        public authController(IAuthRepo repo)
        {
            this.repo = repo;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var user = await repo.Login(dto);
            if (user == null)
            {
                return Unauthorized("Email Or Password Not Valid");
            }
            return Ok(user);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            var u = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Password = dto.Password,
                Phone = dto.Phone,
                Role = dto.Role,
            };
            var s = await repo.Register(u);
            return Created();
        }
    }
}
