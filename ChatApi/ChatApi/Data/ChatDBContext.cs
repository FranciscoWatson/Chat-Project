using Microsoft.EntityFrameworkCore;

namespace ChatApi.Data
{
    public class ChatDBContext : DbContext
    {
        public ChatDBContext(DbContextOptions<ChatDBContext> options) : base(options)
        {
        }
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserChat>()
                .HasKey(c => new { c.userId, c.chatId });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserChat> UsersChats { get; set; }
        public DbSet<Chat> Chats { get; set;}
        public DbSet<Message> Messages { get; set;}

    }
}
