using ChatApi.Data;
using ChatApi.Repository.IRepositry;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.Controllers
{
    [EnableCors("CorsRules")]
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("GetMessegeById")]
        public IActionResult GetMessegeById(Guid messageId)
        {
            Message message = _messageRepo.GetMessage(messageId);

            if (message == null) return NotFound();

            return Ok(message);
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("EditMessageContent")]
        public IActionResult EditMessageContent(Guid messageId, string newContent)
        {

            if (newContent == null) return BadRequest();

            Message message = _messageRepo.GetMessage(messageId);

            if (message == null) return NotFound();

            message.content = newContent;
            _messageRepo.EditMessage(message);

            return Ok(message);
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("DeleteMessageById")]
        public IActionResult DeleteMessageById(Guid messageId)
        {
            Message message = _messageRepo.GetMessage(messageId);
            if (message == null) return NotFound();
            _messageRepo.DeleteMessage(message);
            return Ok(message);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("GetMessagesByChatId")]
        public IActionResult GetMessagesByChatId(Guid chatId)
        {
            var messagesList = _messageRepo.GetMessages(chatId);
            return Ok(messagesList);
        }
    }
}
