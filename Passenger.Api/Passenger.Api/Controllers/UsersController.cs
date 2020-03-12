using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.Dto;
using Passenger.Infrastructure.Services;

namespace Passenger.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;   //FOR WHAT IS IT THAT LOGGER?
        private readonly IUserService _userService;

        public UsersController(ILogger<UsersController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet("{email}")]
        public IActionResult Get(string email)
        {
            var model = _userService.Get(email);
            if(model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public IActionResult Post([FromBody]CreateUser request)
        {
            _userService.Register(request.Email, request.Username, request.Password);

            return Created($"users/{request.Email}", new object());
        }
    }
}
