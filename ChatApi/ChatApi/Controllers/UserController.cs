using ChatApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.XPath;

namespace ChatApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly ChatDBContext _dbContext;
        public UserController(ChatDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateUser([FromBody] User user)
        {
            try
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetUserByID")]
        public IActionResult GetUserById(Guid userId) 
        {
            User user = _dbContext.Users.Find(userId);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            try
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = user });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = user });
            }
        }

        [HttpGet]
        [Route("GetUserByEmail")]
        public IActionResult GetUserByEmail(string userEmail)
        {
            User user = _dbContext.Users.FirstOrDefault(u => u.email == userEmail);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            try
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = user });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = user });
            }
        }

    }
}
