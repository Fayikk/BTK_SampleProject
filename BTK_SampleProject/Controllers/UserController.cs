using BTK_SampleProject_Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BTK_SampleProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        public UserController(IConfiguration config)
        {
            _config = config;
        }


        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDTO loginDTO)
        {
            if (loginDTO.UserName == "admin" && loginDTO.Password=="123")
            {
                return Ok(GenerateJwtToken(loginDTO.UserName));
            }

            return Unauthorized();
        }






        private string GenerateJwtToken(string username)
        {
            var jwtSettings = _config.GetSection("JwtSettings");
            var secretKey = Encoding.UTF8.GetBytes(jwtSettings["Secret"]);

            var claims = new List<Claim>
 {
     new Claim(ClaimTypes.Name, username),
     new Claim(ClaimTypes.Role, "Admin"),
     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // Token ID
 };

            var key = new SymmetricSecurityKey(secretKey);
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpirationInMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }




    }
}
