using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeniorProject_Backend.Models;
using SeniorProject_Backend.Repositories;

namespace SeniorProject_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        public AuthController(IConfiguration configuration, IUserRepository userRepository)
        {

            _configuration = configuration;
            _userRepository = userRepository;

        }


        //[HttpPost("register")]
        //[AllowAnonymous]
        //public async Task<ActionResult<bool>> Register(RegisterRequest request)
        //{
        //    if (_authRepository.UserExists(request.Email))
        //    {
        //        return BadRequest("User Already Exists");
        //    }

        //    CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

        //    User user = new User();
        //    user.Name = request.Name;
        //    user.Email = request.Email;
        //    user.Surname = request.Surname;
        //    user.PasswordHash = passwordHash;
        //    user.PasswordSalt = passwordSalt;

        //    if (!await _authRepository.RegisterUser(user))
        //    {
        //        ModelState.AddModelError("", "Something went wrong while registering user.");
        //        return StatusCode(500, ModelState);
        //    }

        //    return Ok(true);
        //}


        //[HttpPost("login")]
        //[AllowAnonymous]
        //public async Task<ActionResult<string>> Login(LoginDto request)
        //{
        //    if (!_authRepository.UserExists(request.Email))
        //    {
        //        return NotFound();
        //    }

        //    var user = await _authRepository.GetUserByEmail(request.Email);


        //    if (!VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt))
        //    {
        //        return BadRequest("Wrong password");
        //    }

        //    string token = CreateToken(user);

        //    return Ok(token);
        //}
        [HttpGet("getUser")]
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

        //[HttpGet("allUsers")]
        //public async Task<ActionResult<List<User>>> GetAllUsers()
        //{
        //    var userList = await _authRepository.GetAllUsers();
        //    return Ok(userList);
        //}
    }
}
