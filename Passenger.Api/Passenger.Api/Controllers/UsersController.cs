using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public UserDto Get(string email)
        {
            var model = _userService.Get(email);
            return model;
        }
    }
}
