using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApi.Data
{
    public class Chat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid chatId { get; set; }

      //  [ForeignKey("User")]
      //  public Guid originUserId { get; set; }
      //  [ForeignKey("User")]
      //  public Guid recipientUserId { get; set; }
        public string chatName { get; set; }

    }
}
