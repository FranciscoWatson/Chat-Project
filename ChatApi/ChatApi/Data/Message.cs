using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApi.Data
{
    public class Message
    {
        [Key]
        [Required]
        public Guid messageId { get; set; }
        [ForeignKey("Chat")]
        public Guid chatId { get; set; }
        public string content { get; set; }
        public DateTime sentDate { get; set; }
        public DateTime receivedDate { get; set; }
    }
}
