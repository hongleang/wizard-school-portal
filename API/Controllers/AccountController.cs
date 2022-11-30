using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolPortalApi.Core.Interfaces.IAauthManager;

using SchoolPortalAPI.DTOs.UserDtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SchoolPortalAPI.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAuthManager _authManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAuthManager authManager, ILogger<AccountController> logger)
        {
            _authManager = authManager;
            _logger = logger;
        }

        // GET: api/account
        [HttpGet("users")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            _logger.LogInformation($"admin requests list of users");
            return Ok(await _authManager.GetUsersAsync());
        }

        // GET api/account/example@gamil.com
        [HttpGet("users/{userEmail}")]
        public async Task<ActionResult<UserDto>> GetUser(string userEmail)
        {
            _logger.LogInformation($"admin requests a user details");
            return await _authManager.GetUserAsync(userEmail);
        }

        // POST api/account/login
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto loginDto)
        {
            return Ok(await _authManager.Login(loginDto));
        }

        // POST api/account/register
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] RegisterDto registerDto)
        {
            var errors = await _authManager.Register(registerDto);
            if (errors != null)
            {
                foreach (var error in errors.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return CreatedAtAction("Register", new { }, new { UserName = registerDto.UserName, Message = "Successful register!"});
        }
    }
}

