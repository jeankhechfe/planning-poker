using System;
using Microsoft.AspNetCore.Mvc;
using planningpoker.Models;
using planningpoker.TOs;
using System.Collections.Generic;
using planningpoker.Controllers.Exceptions;

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

        [Route("api/users")]
        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return _userService.GetAll();
        }

        [Route("api/register")]
        [HttpPost]
        public ActionResult<LoginTO> Register(UserRegistrationTO userRegistrationTo)
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
            catch (AccessForbiddenException)
            {
                return Unauthorized();
            }
            catch (InvalidOperationException)
            {
                return BadRequest();
            }
        }
    }
}