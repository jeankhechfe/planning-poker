using System;
using Microsoft.AspNetCore.Mvc;
using planningpoker.Models;
using planningpoker.TOs;

namespace planningpoker.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [Route("api/register")]
        [HttpPost]
        public ActionResult<UserTO> Register(UserRegistrationTO userRegistrationTo)
        {
            return _userService.Register(userRegistrationTo);
        }
        
        [Route("api/login")]
        [HttpPost]
        public ActionResult<LoginTO> Login(UserLoginTO userLoginTo)
        {
            try
            {
                return _userService.Login(userLoginTo);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest();
            }
        }
    }
}