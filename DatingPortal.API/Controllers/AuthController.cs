using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DatingPortal.API.Dtos;
using DatingPortal.API.Models;
using DatingPortal.API.Models.Iterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DatingPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository repository;
        private readonly IConfiguration config;
        public AuthController(IAuthRepository repository, IConfiguration config)
        {
            this.config = config;
            this.repository = repository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await repository.UserExists(userForRegisterDto.Username))
                return BadRequest("User with that name already exists.");

            User userToCreated = new User()
            {
                Username = userForRegisterDto.Username
            };

            var createdUser = await repository.Register(userToCreated, userForRegisterDto.Password);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userForomRepo = await repository.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);

            if (userForomRepo == null)
                return Unauthorized();

            // create token
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userForomRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userForomRepo.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(12),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { token = tokenHandler.WriteToken(token) });
        }
    }
}