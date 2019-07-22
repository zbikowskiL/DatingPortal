using System.Threading.Tasks;
using DatingPortal.API.Models.Iterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatingPortal.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private readonly IUserRepository repository;

        public UsersController(IUserRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await repository.GetUsers();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await repository.GetUser(id);

            return Ok(user);
        }
    }
}