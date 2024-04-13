using Microsoft.AspNetCore.Mvc;
using SeniorProject_Backend.Models;
using SeniorProject_Backend.Repositories;

namespace SeniorProject_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public AuthController( IUserRepository userRepository)
        {

            _userRepository = userRepository;

        }

        [HttpGet("login")]
        public ActionResult<User> Login(string username,string password)
        {
            var user= _userRepository.GetUser(username,password);

            if(user == null)
            {
                return NotFound();
            }
            else { 
                return Ok(user);
            }
        }

        [HttpPost("register")]
        public ActionResult<bool> Register([FromBody]User request)
        {
            if (_userRepository.UserExist(request.UserName))
            {
                return BadRequest("User Already Exists");
            }
            var retVal = _userRepository.Register(request);

            if (retVal)
            {
                return Ok(true);
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong while registering user.");
                return StatusCode(500, ModelState);
            }
        }

    }
}
