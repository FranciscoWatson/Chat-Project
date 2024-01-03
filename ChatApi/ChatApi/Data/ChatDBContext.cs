using Microsoft.EntityFrameworkCore;

namespace ChatApi.Data
{
    public class ChatDBContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DbContext");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<Chat> Chats { get; set;}
        public DbSet<User> Users { get; set;}
        //public DbSet<ChatMessage> ChatMessages { get; set;}
        public DbSet<Message> Messages { get; set;}

    }
}
