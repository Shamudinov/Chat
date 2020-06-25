using Microsoft.EntityFrameworkCore;

namespace Chat.Models.Context
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options) {}
    }
}
