using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApi.Data
{
    public class Chat
    {
        [Key]
        [Required]
        public Guid ChatId { get; set; }

        [ForeignKey("User")]
        public Guid originUserId { get; set; }
        [ForeignKey("User")]
        public Guid recipientUserId { get; set; }

    }
}
