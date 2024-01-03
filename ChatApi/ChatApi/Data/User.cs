using System.ComponentModel.DataAnnotations;

namespace ChatApi.Data
{
    public class User
    {
        [Key]
        public Guid userId {  get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
