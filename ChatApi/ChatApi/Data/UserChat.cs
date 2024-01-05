using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.Data
{
    public class UserChat
    {
     //   [Key, Column(Order = 0), ForeignKey("User")]
      //  public Guid userId { get; set; }

     //   [Key, Column(Order = 1), ForeignKey("Chat")]
      //  public Guid chatId { get; set; }

        [Key]
        [Column(Order = 0)]
        public Guid userId { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid chatId { get; set; }

        [ForeignKey("userId")]
        public User User { get; set; }

        [ForeignKey("chatId")]
        public Chat chat { get; set; }



    }

}
