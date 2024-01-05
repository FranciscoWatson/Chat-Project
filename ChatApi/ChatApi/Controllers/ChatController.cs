using ChatApi.Data;
using ChatApi.Repository.IRepositry;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatRepository _chatRepo;

        public ChatController(IChatRepository chatRepo)
        {
            _chatRepo = chatRepo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("GetChats")]
        public IActionResult GetChats()
        {
            var chatsList = _chatRepo.GetChats();
            return Ok(chatsList);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("CreateChat")]
        public IActionResult CreateChat([FromBody] Chat chat)
        {
            _chatRepo.CreateChat(chat);
            return Ok(chat);
        }
    }
}
