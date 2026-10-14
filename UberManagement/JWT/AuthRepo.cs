using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UberManagement.Data;
using UberManagement.DTOs.Auth;
using UberManagement.Models;

namespace UberManagement.JWT
{
    public class AuthRepo : IAuthRepo
    {
        private readonly AppDbContext context;
        private readonly IConfiguration config;
        public AuthRepo(AppDbContext context, IConfiguration config)
        {
            this.context = context;
            this.config = config;
        }

        public async Task<string> Login(LoginDTO dto)
        {
            var existUser = await context.Users.FirstOrDefaultAsync(c => c.Email == dto.Email);
            if (existUser == null)
            {
                return null;
            }
            if(existUser.Password == dto.Password)
            {
                return GenerateToken(dto.Email);
            }
            return null;
        }

        private string GenerateToken(string Email)
        {
            #region claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, Email),
                new Claim(ClaimTypes.Name, Email),
                new Claim("Phone", "010123456789")
            };
            #endregion

            #region key
            var Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config["JWT:Key"]));
            var signingCredentials = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            #endregion
            var TokenObj = new JwtSecurityToken(
                issuer: config["JWT:Issuer"],
                audience: config["JWT:Audiences"],
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddHours(Convert.ToDouble(config["JWT:ExpiredInHours"]))
                );

            var token = new JwtSecurityTokenHandler().WriteToken(TokenObj);
            return token;
        }
        public async Task<bool> Register(User user)
        {
            var existUser = await context.Users.AnyAsync(c => c.Email ==  user.Email);
            if (existUser)
            {
                return false;
            }
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
