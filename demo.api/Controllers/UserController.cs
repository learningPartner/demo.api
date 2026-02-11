using demo.api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;

namespace demo.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IConfiguration _config;
        private readonly StudentDbContext _context;
        public UserController(IConfiguration config, StudentDbContext context)
        {
            _config = config;
            _context = context;
        }


        [HttpPost("login")]
        public IActionResult Login(StudentLoginModel obj)
        {
            var isUserPresent = _context.StudentMasters.SingleOrDefault(x => x.userName == obj.userName && x.password == obj.password);
            if (isUserPresent != null)
            {
               
                var token = GenerateJwtToken(isUserPresent.email);
                LoginResponseModel returnModel = new LoginResponseModel()
                {
                    email = isUserPresent.email,
                    mobile = isUserPresent.mobile,
                    studId = isUserPresent.studId,
                    studName = isUserPresent.studName,
                    token = token
                };
                return Ok(returnModel);
            }
            return Unauthorized();
        }

        private string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
