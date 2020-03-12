using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.Dto;
using Passenger.Infrastructure.Services;

namespace Passenger.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ApiControllerBase
    {
        private readonly ILogger<UserController> _logger;   //FOR WHAT IS IT THAT LOGGER?
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService, ICommandDispatcher commandDispatcher) : base(commandDispatcher)
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
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return Created($"users/{command.Email}", new object());
        }
    }
}
