using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApi.Data
{
    public class ChatMessage
    {
        [Key, Column(Order = 0), ForeignKey("Chat")]
        public Guid chatId { get; set; }

        [Key, Column(Order = 1), ForeignKey("Message")]
        public Guid messageId { get; set; }
    }
}
