using EF.UsingDbContextPooling.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF.UsingDbContextPooling.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Wallet> Wallets { get; set; } = null!;
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

    }
}
