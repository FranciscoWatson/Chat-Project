using ChatApi.Data;
using ChatApi.Repository.IRepositry;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.XPath;

namespace ChatApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        
        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            var usersList = _userRepo.GetUsers();
            return Ok(usersList);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("CreateUser")]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (_userRepo.UserExists(user.email)) return BadRequest(user);

            _userRepo.CreateUser(user);
            return Ok(user);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("GetUserByID")]
        public IActionResult GetUserById(Guid userId) 
        {
           User user = _userRepo.GetUser(userId);

           if (user == null) return NotFound();

           return Ok(user);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("GetUserByEmail")]
        public IActionResult GetUserByEmail(string userEmail)
        {
            User user = _userRepo.GetUser(userEmail);

            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("EditUserById")]
        public IActionResult EditUserById(Guid userId, [FromBody] User user)
        {
            if(user == null ) return BadRequest();
  
            User oUser = _userRepo.GetUser(userId);
            if (oUser == null) return NotFound();

            oUser.userId = userId;
            oUser.email = user.email != null ? user.email : oUser.email;
            oUser.password = user.password != null ? user.password : oUser.password;
            oUser.name = user.name != null ? user.name : oUser.name;
            _userRepo.EditUser(oUser);

            return Ok(oUser);
        }

    }
}
