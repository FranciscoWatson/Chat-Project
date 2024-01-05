using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApi.Data
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid messageId { get; set; }
        [ForeignKey("Chat")]
        public Guid chatId { get; set; }
        [ForeignKey("User")]
        public Guid userId { get; set; }
        public string content { get; set; }
        public DateTime sentDate { get; set; }
        public DateTime receivedDate { get; set; }
    }
}
