using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DatingPortal.API.Dtos;
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
        private readonly IMapper mapper;

        public UsersController(IUserRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await repository.GetUsers();

            var usersToReturn = mapper.Map<IEnumerable<UserForListDto>>(users);

            return Ok(usersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await repository.GetUser(id);

            var userToReturn = mapper.Map<UserForDetalisDto>(user);

            return Ok(userToReturn);
        }
    }
}