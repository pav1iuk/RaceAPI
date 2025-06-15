namespace RaceInfoApi.Controller
{
    using BCrypt.Net;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using RaceInfoApi.Application.DTOs;
    using RaceInfoApi.Core.Entities;
    using RaceInfoApi.Infrastructure.Data;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly RaceDbContext _context;
        private readonly IConfiguration _config;
        public AuthController(RaceDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == dto.Username);
            if (existingUser != null)
                return BadRequest("Username already exists");


            string passwordHash = BCrypt.HashPassword(dto.Password);


            var user = new User
            {
                Username = dto.Username,
                PasswordHash = passwordHash,
                Role = "User" 
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User registered successfully");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == dto.Username);
            if (user == null)
                return Unauthorized("Invalid username or password");

            bool passwordValid = BCrypt.Verify(dto.Password, user.PasswordHash);
            if (!passwordValid)
                return Unauthorized("Invalid username or password");

            var token = GenerateJwtToken(user);

            
            return Ok(new { token });
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["JwtSettings:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
        }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        [Authorize]
        [HttpGet("secure")]
        public IActionResult GetSecret()
        {
            return Ok("Ти авторизований, доступ дозволено!");
        }

    }
}
