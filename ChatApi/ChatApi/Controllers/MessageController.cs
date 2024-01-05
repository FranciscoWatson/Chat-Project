using ChatApi.Data;
using ChatApi.Repository.IRepositry;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository _messageRepo;

        public MessageController(IMessageRepository messageRepo)
        {
            _messageRepo = messageRepo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("GetMessages")]
        public IActionResult GetMessages()
        {
            var messagesList = _messageRepo.GetMessages();
            return Ok(messagesList);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("CreateMessage")]
        public IActionResult CreateMessage([FromBody] Message message)
        {
            _messageRepo.CreateMessage(message);
            return Ok(message);
        }
    }
}
