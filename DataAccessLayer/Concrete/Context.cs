using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AdminUser, AdminRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("*");
        }
        public DbSet<Expenditure> Expenditures { get; set; }

        public DbSet<BotSetting> BotSettings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LogEntry> LogEntries { get; set; }

        public DbSet<SafeBox> SafeBoxes { get; set; }

        public DbSet<Product> Products { get; set; }

    
    }
}
