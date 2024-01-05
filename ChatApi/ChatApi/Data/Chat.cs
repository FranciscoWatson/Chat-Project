using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ChatApi.Data
{
    public class Chat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public Guid chatId { get; set; }

      //  [ForeignKey("User")]
      //  public Guid originUserId { get; set; }
      //  [ForeignKey("User")]
      //  public Guid recipientUserId { get; set; }
        public string chatName { get; set; }

    }
}
