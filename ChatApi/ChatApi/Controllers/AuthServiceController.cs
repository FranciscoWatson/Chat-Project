using ChatApi.Data;
using ChatApi.Repository.IRepositry;
using ChatApi.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Controllers
{
    [EnableCors("CorsRules")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthServiceController : ControllerBase
    {
        private readonly IAuthServiceRepository _authServiceRepo;

        public AuthServiceController(IAuthServiceRepository authServiceRepo)
        {
            _authServiceRepo = authServiceRepo;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("Login")]
        public IActionResult Login([FromBody] UserLoginDto userDto)
        {
            User user = _authServiceRepo.Authenticate(userDto.email, userDto.password);

            if (user == null) return NotFound();

            return Ok(user);
        }
    }
}
